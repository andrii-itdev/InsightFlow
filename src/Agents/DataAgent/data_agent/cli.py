from __future__ import annotations

import asyncio

from langchain_core.messages import HumanMessage

from data_agent.graph import agent_graph


async def _chat_loop() -> None:
    print("InsightFlow DataAgent CLI. Type 'exit' to quit.")
    while True:
        user_input = input("\nYou: ").strip()
        if user_input.lower() in {"exit", "quit"}:
            print("Goodbye.")
            break
        result = await agent_graph.ainvoke({"messages": [HumanMessage(content=user_input)]})
        print(f"\nAgent:\n{result['final_response']}")


def main() -> None:
    asyncio.run(_chat_loop())


if __name__ == "__main__":
    main()
