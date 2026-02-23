from __future__ import annotations

from typing import TypedDict

from langchain_core.messages import BaseMessage


class AgentState(TypedDict, total=False):
    messages: list[BaseMessage]
    routed_issue: int
    routed_title: str
    routed_kind: str
    tool_result: str
    final_response: str
