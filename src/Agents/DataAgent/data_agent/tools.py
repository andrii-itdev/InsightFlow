from __future__ import annotations

import json
from typing import Any

import httpx

from data_agent.config import settings


class DataAgentTools:
    def __init__(self) -> None:
        self.timeout = settings.request_timeout_seconds
        self.data_management_base_url = settings.data_management_base_url.rstrip("/")

    async def execute(self, issue_number: int, user_text: str) -> str:
        if issue_number in (18, 27):
            return await self._run_data_management_flow(user_text)
        return self._build_guidance(issue_number, user_text)

    async def _run_data_management_flow(self, user_text: str) -> str:
        lowered = user_text.lower()
        if "list" in lowered or "all records" in lowered:
            return "DataManagement API currently exposes item-level operations in this repo. Use GET by record id."

        if "create" in lowered or "post" in lowered or "new record" in lowered:
            payload = {"data": self._extract_data_payload(user_text)}
            return await self._request("POST", f"{self.data_management_base_url}/Records", json_body=payload)

        if "delete" in lowered:
            record_id = self._extract_guid_like_token(user_text)
            if not record_id:
                return "Please provide a record id (GUID) to delete."
            return await self._request("DELETE", f"{self.data_management_base_url}/Records/{record_id}")

        if "update" in lowered or "put" in lowered:
            record_id = self._extract_guid_like_token(user_text)
            if not record_id:
                return "Please provide a record id (GUID) to update."
            return await self._request("PUT", f"{self.data_management_base_url}/Records/{record_id}")

        record_id = self._extract_guid_like_token(user_text)
        if not record_id:
            return "For data retrieval, provide a record id (GUID)."
        return await self._request("GET", f"{self.data_management_base_url}/Records/{record_id}")

    def _build_guidance(self, issue_number: int, user_text: str) -> str:
        base_plan = [
            f"Issue #{issue_number} is mapped as a planning/research capability.",
            "Recommended output format:",
            "1) Context and constraints",
            "2) Architecture decision options",
            "3) Chosen approach with trade-offs",
            "4) Delivery plan with milestones",
            "5) Risks, observability, and test strategy",
        ]
        if "checklist" in user_text.lower():
            base_plan.append("6) Execution checklist with owner and due date placeholders")
        return "\n".join(base_plan)

    async def _request(self, method: str, url: str, json_body: Any | None = None) -> str:
        try:
            async with httpx.AsyncClient(timeout=self.timeout) as client:
                response = await client.request(method=method, url=url, json=json_body)
                content_type = response.headers.get("content-type", "")
                if "application/json" in content_type:
                    payload = response.json()
                    pretty = json.dumps(payload, indent=2, ensure_ascii=True)
                else:
                    pretty = response.text.strip()
                return f"{method} {url}\nHTTP {response.status_code}\n{pretty}"
        except Exception as exc:  # noqa: BLE001
            return f"{method} {url}\nRequest failed: {exc}"

    @staticmethod
    def _extract_guid_like_token(text: str) -> str | None:
        for token in text.replace(",", " ").split():
            if token.count("-") == 4 and len(token) >= 32:
                return token.strip()
        return None

    @staticmethod
    def _extract_data_payload(text: str) -> str:
        marker = "data:"
        lower = text.lower()
        if marker in lower:
            idx = lower.index(marker)
            return text[idx + len(marker) :].strip() or "sample-data"
        return "sample-data"
