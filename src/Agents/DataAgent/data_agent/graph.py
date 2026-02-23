from __future__ import annotations

from langchain_core.messages import AIMessage, HumanMessage
from langchain_openai import ChatOpenAI
from langgraph.graph import END, START, StateGraph

from data_agent.config import settings
from data_agent.models import AgentState
from data_agent.router import route_user_intent
from data_agent.tools import DataAgentTools

tools = DataAgentTools()


def _route_node(state: AgentState) -> AgentState:
    user_message = next(msg for msg in reversed(state["messages"]) if isinstance(msg, HumanMessage))
    routed = route_user_intent(user_message.content)
    return {
        "routed_issue": routed.issue_number,
        "routed_title": routed.title,
        "routed_kind": routed.kind,
    }


async def _tool_node(state: AgentState) -> AgentState:
    user_message = next(msg for msg in reversed(state["messages"]) if isinstance(msg, HumanMessage))
    result = await tools.execute(state["routed_issue"], user_message.content)
    return {"tool_result": result}


async def _respond_node(state: AgentState) -> AgentState:
    system_summary = (
        f"Issue #{state['routed_issue']} - {state['routed_title']} ({state['routed_kind']}).\n"
        f"Execution result:\n{state['tool_result']}"
    )
    if settings.openai_api_key:
        llm = ChatOpenAI(api_key=settings.openai_api_key, model=settings.openai_model, temperature=0.2)
        prompt = [
            HumanMessage(
                content=(
                    "You are InsightFlow DataAgent. Respond concisely and actionably.\n"
                    f"{system_summary}"
                )
            )
        ]
        answer = await llm.ainvoke(prompt)
        return {
            "final_response": answer.content,
            "messages": [AIMessage(content=answer.content)],
        }

    deterministic = (
        "LLM credentials are not configured. Returning deterministic response.\n\n"
        f"{system_summary}"
    )
    return {
        "final_response": deterministic,
        "messages": [AIMessage(content=deterministic)],
    }


def build_graph():
    graph = StateGraph(AgentState)
    graph.add_node("route_intent", _route_node)
    graph.add_node("execute_capability", _tool_node)
    graph.add_node("respond", _respond_node)

    graph.add_edge(START, "route_intent")
    graph.add_edge("route_intent", "execute_capability")
    graph.add_edge("execute_capability", "respond")
    graph.add_edge("respond", END)
    return graph.compile()


agent_graph = build_graph()
