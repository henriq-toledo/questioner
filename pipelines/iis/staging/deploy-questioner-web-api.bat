REM Clean
rmdir "C:\Temp\questioner-api\" /S /Q

REM Download repository
git clone https://github.com/henriq-toledo/questioner.git "C:\Temp\questioner-api\build"

REM Publish
dotnet publish --configuration Release --runtime win10-x64 /p:EnvironmentName=Staging --no-self-contained --output "C:\Temp\questioner-api\publish" "C:\Temp\questioner-api\build\src\Questioner\Questioner.WebApi\Questioner.WebApi.csproj"

REM Stop apppool
%systemroot%\system32\inetsrv\appcmd stop apppool /apppool.name:QuestionerApiAppPool

del "C:\inetpub\wwwroot\questioner-api\**" /S /Q

REM Copy publish to web app folder
xcopy "C:\Temp\questioner-api\publish\**" "C:\inetpub\wwwroot\questioner-api" /E /Q

REM Start apppool
%systemroot%\system32\inetsrv\appcmd start apppool /apppool.name:QuestionerApiAppPool

start firefox "http://localhost/questioner-api/"

pause