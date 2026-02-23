from data_agent.router import route_user_intent


def test_routes_by_issue_number():
    capability = route_user_intent("Please help with issue #30 localization")
    assert capability.issue_number == 30


def test_routes_data_management_keywords():
    capability = route_user_intent("create dataset record with data: sample")
    assert capability.issue_number in (18, 27)
