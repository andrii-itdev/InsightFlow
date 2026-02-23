# InsightFlow DataAgent

`DataAgent` is a Python/LangGraph conversational orchestrator that gives all the capabilities in conversational manner.

It is designed to:

- provide a single conversational entrypoint for issue-driven operations,
- call currently available APIs in `DataManagement`,
- generate guided implementation/research workflows for the issues that are not yet implemented in backend services.

## Project Layout

- `data_agent/issue_capabilities.py` - canonical issue registry and capability metadata.
- `data_agent/router.py` - intent-to-capability routing.
- `data_agent/tools.py` - adapters for API calls and planning workflows.
- `data_agent/graph.py` - LangGraph state machine.
- `data_agent/api.py` - FastAPI endpoint for chat.
- `data_agent/cli.py` - local terminal chat loop.

## Covered Issue Set

Capabilities fall into three categories:

- `api_operation`: executes live HTTP operations against existing InsightFlow services.
- `workflow`: generates implementation plans/checklists for platform features.
- `research`: generates structured research outputs (decision matrices, trade-off analysis, architecture notes).

## Quick Start

1. Create and activate a Python virtual environment.
2. Install dependencies:
   - `pip install -e .`
3. Configure environment variables:
   - `copy .env.example .env` (Windows)
4. Start API:
   - `uvicorn data_agent.api:app --reload --port 8090`
5. Or run CLI:
   - `python -m data_agent.cli`

## Environment

See `.env.example` for all supported variables.

Important:

- If `OPENAI_API_KEY` and `OPENAI_MODEL` are set, the agent uses an LLM to produce richer conversational responses.
- Without LLM credentials, the agent still runs in deterministic mode and returns structured responses.

## Current Service Endpoints Used

- Data Management:
  - `GET /Records/{recordId}`
  - `POST /Records`
  - `PUT /Records/{recordId}`
  - `DELETE /Records/{recordId}`

## Notes

This project is intentionally issue-first and extensible.
As additional services (Identity, Notification, Search, Configuration) are implemented in InsightFlow, add concrete HTTP adapters in `tools.py` and switch issue capabilities from `workflow/research` to `api_operation`.
