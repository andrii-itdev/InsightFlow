from __future__ import annotations

from fastapi import FastAPI
from pydantic import BaseModel
from langchain_core.messages import HumanMessage

from data_agent.graph import agent_graph

app = FastAPI(title="InsightFlow DataAgent", version="0.1.0")


class ChatRequest(BaseModel):
    message: str


class ChatResponse(BaseModel):
    routed_issue: int
    routed_title: str
    routed_kind: str
    response: str


@app.get("/health")
def health() -> dict[str, str]:
    return {"status": "ok"}


@app.post("/chat", response_model=ChatResponse)
async def chat(request: ChatRequest) -> ChatResponse:
    state = await agent_graph.ainvoke({"messages": [HumanMessage(content=request.message)]})
    return ChatResponse(
        routed_issue=state["routed_issue"],
        routed_title=state["routed_title"],
        routed_kind=state["routed_kind"],
        response=state["final_response"],
    )
