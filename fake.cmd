SET TOOL_PATH=.fake

REM Works: 5.13.7
REM Fails: 5.14

IF NOT EXIST "%TOOL_PATH%\fake.exe" (
  dotnet tool install fake-cli --tool-path ./%TOOL_PATH% --version 5.14
)

"%TOOL_PATH%/fake.exe" %*