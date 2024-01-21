
// Models
type DataSet = {};
type DataRecord = {};
type Relationship = {};
type Permission = {};
type User = {};
type Watcher = {};
type AlertNotification = {};

// Events
type ProcessCreated = {};
type ProcessStarted = {};
type ProcessFinished = {};

type DataSetCreated = {};
type DataSetChanged = {};
type DataSetDeleted = {};

type RecordCreated = {};
type RecordChanged = {};
type RecordDeleted = {};

type RelationshipCreated = {};
type RelationshipDeleted = {};

type WatcherCreated = {};
type WatcherEnabled = {};
type WatcherDisabled = {};

type NotificationSent = {}

type UserCreated = {};
type UserAuthenticated = {};
type UserDeleted = {};

type DataSetPermissionsChanged = {};

// Commands

// Errors

// Infrastructure

type Query = {};
type Command = {};

type DomainEvent =
    ProcessCreated |
    ProcessStarted | 
    ProcessFinished |

    DataSetCreated |
    DataSetChanged |
    DataSetDeleted |

    RelationshipCreated |
    RelationshipDeleted |

    WatcherCreated |
    WatcherEnabled |
    WatcherDisabled |

    NotificationSent |

    UserCreated |
    UserAuthenticated |
    UserDeleted |

    DataSetPermissionsChanged
    ;



type Error = {};

