# DescartesDiffApi
Api defines difference between byte arrays

1. Clone repository "git clone https://github.com/SebSkap/DescartesDiffApi"

2. In Package Manager Console in Visual Studio
delete existing database by running: "dotnet ef database update 0"
create fresh database by running: "dotnet ef database update"

3. Run application by executing DescartesDiffApi

4. Open Postman
- Add global variable by opening Evironments, selecting Globals and adding a new variable "base-url", 
with initial value as localhost (example: "localhost:14931", press Save in the upper right corner

5. Import Postman integration test collection by using File - Import... and selecting "DescartesDiffApiTest.postman_collection.json" file

6. Go to Collections, select DescartesDiffApiTest and press "Run" in the upper right corner to execute test steps
