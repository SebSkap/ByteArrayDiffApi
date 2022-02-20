# DescartesDiffApi
Api defines difference between byte arrays

1. Clone repository "git clone https://github.com/SebSkap/DescartesDiffApi"

2. In Package Manager Console in Visual Studio
locate to DescartesDiffApi project location by running "cd [DescartesDiffApi path]", example "C:\repos\DescartesDiffApi\DescartesDiffApi"
- delete existing database by running: "dotnet ef database update 0"
- create fresh database by running: "dotnet ef database update"

3. Run application (F5) by executing DescartesDiffApi

4. Run All Tests to run unit test for difference calculation method

5. Open Postman
- Add global variable by opening Evironments, selecting Globals and adding a new variable "base-url", 
with initial value as localhost (example: "localhost:14931"), press Save in the upper right corner

6. Import Postman integration test collection by using File - Import... and selecting "DescartesDiffApiTest.postman_collection.json" file 
from root project folder

7. Go to Collections, select DescartesDiffApiTest and press "Run" in the upper right corner to execute integration test steps
