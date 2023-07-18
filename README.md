# AutoCrudAPI
Demonstrate how to generate CRUD controllers automatically in a .NET Web API

Inject assemblies and see the controllers appear. 
(Use ControllerMap.cs to tell the app which assemblies to pick)

From this one class:
![image](https://github.com/orlodax/AutoCrudAPI/assets/34894690/272139bc-eb9e-4c3f-8682-7b0713cbb8e8)
To all the controllers at runtime:
![controllersGeneration](https://github.com/orlodax/AutoCrudAPI/assets/34894690/25032d74-3181-47d3-90ca-0f46724fa481)

The real life scenario based on this code includes a generic DbContext, async Task<ActionResult>, JWT authorization, API versioning etc...
