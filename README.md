# Questioner
Questioner is a web application that test using questions and answers about a theme to help studying. Developed to be responsive to run in the PC web browser or mobile web browser.

## Badge Status
[![Build Status](https://dev.azure.com/htapps/GitHub/_apis/build/status/henriq-toledo.questioner?branchName=master)](https://dev.azure.com/htapps/GitHub/_build/latest?definitionId=1&branchName=master)

## Setup

### Development environment

- [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet-core/3.1)
- [Visual Studio Code](https://code.visualstudio.com/download)
- [SQL Server Express (optional)](https://go.microsoft.com/fwlink/?linkid=866658)

### IIS

- [Host ASP.NET Core on Windows with IIS](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/iis/?view=aspnetcore-3.1)
- [Install the .NET Core Hosting Bundle](https://dotnet.microsoft.com/download/dotnet-core/thank-you/runtime-aspnetcore-3.1.6-windows-hosting-bundle-installer)
- [ASP.NET Core Runtime 3.1.6](https://dotnet.microsoft.com/download/dotnet-core/thank-you/runtime-aspnetcore-3.1.6-windows-x64-installer)

## Screenshots

### IOS

<img src="screenshots/ios/01-questioner-home-page.png" alt="Questioner Home Page" width="200"> <img src="screenshots/ios/02-questioner-topics-page-1.png" alt="Questioner Topics Page" width="200"> <img src="screenshots/ios/03-questioner-topics-page-2.png" alt="Questioner Topics Page" width="200"> <img src="screenshots/ios/04-questioner-questions-page-1.png" alt="Questioner Questions Page" width="200"> <img src="screenshots/ios/05-questioner-questions-page-2.png" alt="Questioner Questions Page" width="200"> <img src="screenshots/ios/06-questioner-result-page-1.png" alt="Questioner Result Page" width="200"> <img src="screenshots/ios/07-questioner-result-page-2.png" alt="Questioner Result Page" width="200"> <img src="screenshots/ios/08-questioner-result-report-download.png" alt="Questioner Result Report Download" width="200"> <img src="screenshots/ios/09-questioner-result-report.png" alt="Questioner Result Report" width="355" height="200"  style="vertical-align:top">

### PC

#### Questioner Home Page
<img src="screenshots/pc/01-questioner-home-page.png" alt="Questioner Home Page">

#### Questioner Topics Page
<img src="screenshots/pc/02-questioner-topics-page.png" alt="Questioner Topics Page">

#### Questioner Questions Page
<img src="screenshots/pc/03-questioner-questions-page.png" alt="Questioner QUestions Page">

#### Questioner Result Page
<img src="screenshots/pc/04-questioner-result-page.png" alt="Questioner Result Page">

#### Questioner Result Report Download
<img src="screenshots/pc/05-questioner-result-report-download.png" alt="Questioner Result Report Download">

#### Questioner Result Report
<img src="screenshots/pc/06-questioner-result-report.png" alt="Questioner Result Report">

## Pipelines

### Azure DevOps

- [Build](https://github.com/henriq-toledo/questioner/blob/master/pipelines/azure-devops/azure-pipelines.yml)
- [Release](https://github.com/henriq-toledo/questioner/blob/master/pipelines/azure-devops/azure-release-pipeline.yml)

### Jenkins

#### [Web App Jenkins Pipeline](https://github.com/henriq-toledo/questioner/tree/master/pipelines/jenkins/web-app/Jenkinsfile)
<img src="screenshots/jenkins/web-app-pipeline.png" alt="Web App Jenkins Pipeline">

#### [Web Api Jenkins Pipeline](https://github.com/henriq-toledo/questioner/tree/master/pipelines/jenkins/web-api/Jenkinsfile)
<img src="screenshots/jenkins/web-api-pipeline.png" alt="Web Api Jenkins Pipeline">