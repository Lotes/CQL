@if exist "%ProgramFiles%\MSBuild\14.0\bin" set PATH=%ProgramFiles%\MSBuild\14.0\bin;%PATH%
@if exist "%ProgramFiles(x86)%\MSBuild\14.0\bin" set PATH=%ProgramFiles(x86)%\MSBuild\14.0\bin;%PATH%

@msbuild %~dp0..\..\CQL.sln /p:Configuration=Release
@nuget pack CQL.nuspec

@echo NOW PUSH WITH:
@echo  ./nuget push CQL.x.x.x.nupkg

pause