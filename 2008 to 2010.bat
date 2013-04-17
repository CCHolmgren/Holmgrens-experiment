REM Tool from: http://www.programmersheaven.com/download/41236/download.aspx

for /f "tokens=*" %%a IN ('dir /b /s *.sln') do ssr.exe 0 "Format Version 10.00" "Format Version 11.00" %%a
for /f "tokens=*" %%a IN ('dir /b /s *.sln') do ssr.exe 0 "# Visual Studio 2008" "# Visual Studio 2010" %%a

for /f "tokens=*" %%a IN ('dir /b /s *.csproj') do ssr.exe 0 "ToolsVersion=''3.5''" "ToolsVersion=''4.0''" %%a
for /f "tokens=*" %%a IN ('dir /b /s *.csproj') do ssr.exe 0 "v9.0" "v10.0"  %%a
