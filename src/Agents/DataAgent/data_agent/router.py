from __future__ import annotations

from data_agent.issue_capabilities import CAPABILITIES, Capability


def route_user_intent(user_text: str) -> Capability:
    message = user_text.lower()
    scored: list[tuple[int, Capability]] = []

    for capability in CAPABILITIES:
        score = 0
        if f"#{capability.issue_number}" in message:
            score += 100
        if capability.title.lower() in message:
            score += 40
        for keyword in capability.keywords:
            if keyword in message:
                score += 10
        scored.append((score, capability))

    scored.sort(key=lambda item: item[0], reverse=True)
    top_score, top_capability = scored[0]
    if top_score == 0:
        # Default to Data Sets Management because it is immediately executable.
        return next(item for item in CAPABILITIES if item.issue_number == 18)
    return top_capability
