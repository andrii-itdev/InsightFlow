
// Basic types

type Id = number;
type RecordData = string | number;

// Models
type DataSet = {};
type DataRecord = {};
type Relationship = {};
type Permission = {};
type User = {};
type Watcher = {};
type AlertNotification = {};

type DataEntity = DataRecord | DataSet;
type DataType = {};


type ReadPermission = {};
type CreatePermission = {};
type UpdatePermission = {};
type DeletePermission = {};

type PermissionType = ReadPermission | CreatePermission | UpdatePermission | DeletePermission ;

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
type DataRecordPermissionsChanged = {};

// Commands

type CreateProcess = { processName : string };
type StartProcess = { processId : Id };
type CancelProcess = { processId : Id };

type CreateDataSet = { dataSetName : string };
type DeleteDataSet = { dataSetId : Id };
type AddRecordDataSet = { dataSetId : Id, recordId : Id };
type RemoveRecordDataSet = { dataSetId : Id, recordId : Id };

type ShareDataSet = { dataSetId : Id, userId : Id };

type CreateRecord = { recordData : RecordData, dataType : DataType };
type UpdateRecord = { recordId : Id, recordData : RecordData };
type DeleteRecord = { record : Id };

type CreateRelationship = { first : DataEntity, second : DataEntity, name : string };
type RemoveRelationship = { relationshipId : Id };

type SetupWatcher = { watcherName : string, configuration : string };
type SwitchWatcher = { watcherId : Id, flag : boolean };

type GrantPermission = { userId : Id, what : DataEntity, permissionType : PermissionType};
type RemovePermission = { userId : Id, what : DataEntity, permissionType : PermissionType};

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

    DataSetPermissionsChanged |
    DataRecordPermissionsChanged
    ;



type ErrorType = {};

