from __future__ import annotations

from dataclasses import dataclass


@dataclass(frozen=True)
class Capability:
    issue_number: int
    title: str
    kind: str
    summary: str
    keywords: tuple[str, ...]


CAPABILITIES: tuple[Capability, ...] = (
    Capability(2, "Create Authentication & Authorization mechanism", "workflow", "Design and rollout authentication and authorization.", ("authentication", "authorization", "identity", "access")),
    Capability(3, "Expose API to third-parties to consume", "workflow", "Define external API exposure model and contracts.", ("third-party", "external api", "partner", "public api")),
    Capability(4, "Implement Load balancing mechanism", "workflow", "Design service load balancing and traffic distribution.", ("load balancing", "traffic", "availability")),
    Capability(5, "Implement monitoring mechanism", "workflow", "Define monitoring strategy and alerting standards.", ("monitoring", "metrics", "alerts", "observability")),
    Capability(6, "Introduction of the logging mechanism", "research", "Research logging strategy and structured logging standards.", ("logging", "serilog", "logs")),
    Capability(7, "Create a Feedback form", "workflow", "Design and integrate a user feedback collection flow.", ("feedback", "form", "ui feedback")),
    Capability(8, "Investigate and Design ETL process", "research", "Compare ETL vs ELT and propose architecture.", ("etl", "elt", "pipeline", "ingestion")),
    Capability(9, "Implement a Configuration service", "workflow", "Plan centralized configuration service.", ("configuration", "config service", "settings")),
    Capability(10, "Add API versioning", "workflow", "Design backward-compatible API versioning.", ("versioning", "api version", "v1", "v2")),
    Capability(11, "Add API health checks", "workflow", "Plan health checks and readiness/liveness strategy.", ("health", "health checks", "readiness", "liveness")),
    Capability(12, "Event Notification System", "research", "Research event triggers, channels, and guarantees.", ("notification", "event", "email", "sms", "push")),
    Capability(13, "Define Domains. Events. Subdomains", "research", "Create DDD map of domains, events, and bounded contexts.", ("domain", "event", "subdomain", "bounded context")),
    Capability(14, "Compare authorization systems", "research", "Evaluate authorization models and pick recommendation.", ("rbac", "abac", "policy", "claims")),
    Capability(15, "Add Anti-Corruption Layer", "workflow", "Design anti-corruption boundaries between contexts.", ("anti-corruption", "acl", "translation")),
    Capability(16, "Consider InsightFlow extension ideas", "research", "Evaluate extension opportunities and prioritization.", ("extension", "enhancement", "ideas")),
    Capability(17, "Add tests for DataManagement", "workflow", "Plan integration and functional tests expansion.", ("tests", "integration", "functional", "quality")),
    Capability(18, "Data Sets Management", "api_operation", "Operate data set/record management flows.", ("dataset", "record", "data management", "crud")),
    Capability(19, "Determine databases used by global companies", "research", "Build comparative study for data platforms.", ("database", "architecture", "benchmark")),
    Capability(20, "Designing the Notification Service", "research", "Define notification service architecture.", ("notification service", "delivery")),
    Capability(21, "Determine caching strategy", "research", "Evaluate caching patterns per service.", ("cache", "caching", "redis")),
    Capability(22, "Design Searching Engine", "research", "Design search architecture and indexing strategy.", ("search", "index", "query")),
    Capability(23, "Add Serilog to existing projects", "workflow", "Plan and sequence Serilog integration.", ("serilog", "logging setup")),
    Capability(24, "Determine database per bounded context", "research", "Propose database strategy per service context.", ("database strategy", "bounded context", "storage")),
    Capability(25, "Build Identity service", "workflow", "Design and implementation plan for identity service.", ("identity", "auth service", "token")),
    Capability(26, "Add Exception handling middleware", "workflow", "Define global exception handling policy.", ("exception", "middleware", "errors")),
    Capability(27, "Implement Data Management API", "api_operation", "Operate DataManagement API resources.", ("records", "api", "datamanagement")),
    Capability(28, "Add Validation middleware", "workflow", "Define request validation and error semantics.", ("validation", "middleware", "400")),
    Capability(29, "Add Request logging middleware", "workflow", "Define request logging middleware behavior.", ("request logging", "middleware", "audit")),
    Capability(30, "Add Localization", "workflow", "Plan localization for API/user-facing messages.", ("localization", "i18n", "messages")),
)

CAPABILITY_BY_ISSUE = {item.issue_number: item for item in CAPABILITIES}
