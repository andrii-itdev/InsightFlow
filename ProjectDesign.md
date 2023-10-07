
# Design

## Technology Stack

* Backend: C#, Python
* Frontend: Typesript, Angular 


*gRPC (RPC)* - Used as a lightweight and efficient way for communication between microservices. Used for bi-directional, high-performance, real-time data streaming.
Client-Server communication.

*Web Sockets* - Used for sending notifications and alerting of the client applications. Used for updating the dash board and monitoring.

*Webhook* - Used for push event-notifications as well as triggering actions, processes and workflows. 

*Message Broker (Service Bus)* - Used for load-balancing across multiple processing sevices for parallel distributed task execution, and data processing. 

*Client-Side Rendering (CSR)* - Used for Rich User Interface with complex interaction (Dashboard, Data Visualization) 

*WebRTC* - Used for File Transfer and Data Uploding to the server and File Sharing.

*Server-Sent Events (SSE)* - Used for Real-Time notifications on the client's feed.

*Docker, Kubernetes* - Used for containers orchestration that allows efficient management, deplayment, scaling, and monitoring across infrastracture. 

## Architecture 

Each feature is a distinct microservice that is autonomous, independently deployable that represents a container, and responsible for its own data.




