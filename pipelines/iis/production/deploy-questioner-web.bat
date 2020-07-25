REM Clean
rmdir "C:\Temp\questioner\" /S /Q

REM Download repository
git clone https://github.com/henriq-toledo/questioner.git "C:\Temp\questioner\build"

REM Publish
dotnet publish --configuration Release --runtime win10-x64 /p:EnvironmentName=Production --no-self-contained --output "C:\Temp\questioner\publish" "C:\Temp\questioner\build\src\Questioner\Questioner.Web\Questioner.Web.csproj"

REM Stop apppool
%systemroot%\system32\inetsrv\appcmd stop apppool /apppool.name:DefaultAppPool

del "C:\inetpub\wwwroot\questioner\**" /S /Q

REM Copy publish to web app folder
xcopy "C:\Temp\questioner\publish\**" "C:\inetpub\wwwroot\questioner" /E /Q

REM Start apppool
%systemroot%\system32\inetsrv\appcmd start apppool /apppool.name:DefaultAppPool

start firefox "http://localhost/questioner/"

pause