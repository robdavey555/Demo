# Introduction 
Demo project for Eintech 

# Getting Started
1.	Open Solution in Visual Studio
2.	Ensure Eintech.App is your startup project
3.	If you have SQL Express installed then run the app and the database will create automatically with seed data. If database did not create, read step 4
4.	Update the connection string in \EintechDemo\Eintech.App\appsettings.json
5.	A database backup can be downloaded from https://rjdstaticstorage.blob.core.windows.net/sql-backup/demo-eintech-db-2020-7-1-11-40.bacpac (username and password for database can be found in variables.tf)

# Key areas
1.	Eintech.App - The MVC application. Services include sqlServer dbContext, Application Insights and Health endpoint for monitoring
2.	Eintech.Data - Project for EFCore dbContext
3.	Terraform - Infrastructure as code to setup the required resources for the project
4.	Data setup - Uses the Bogus Nuget package to create dummy data for Unit Tests and seeding data for Entity Framework

# Build and Test
YAML build file (build-ci.yaml) includes 
*	Validation for any changes made to Terraform
*	Code coverage report in Azure Devops
*	Test report in Azure Devops

Current build status  
[![Build Status](https://tfsprodweu3.visualstudio.com/A5b3e0cee-e9d7-40f8-a5d9-363233840da6/RockShow/_apis/build/status/Eintech-CI?branchName=master)](https://tfsprodweu3.visualstudio.com/A5b3e0cee-e9d7-40f8-a5d9-363233840da6/RockShow/_build/latest?definitionId=10&branchName=master)

# With more time
1.	Add application logging using ILogger wired up to Application insights
2.	Change the spec to separate the front-end and backend to a Blazor SPA with one or more .Net Core API's
3.	Update to build YAML to fail builds where code coverage falls below a certain percentage
4.	Add Selenium tests
5.	Enable Azure key vault to store secrets e.g. connection string
6.	Add paging and sorting for the results