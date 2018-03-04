@if exist "%ProgramFiles%\MSBuild\14.0\bin" set PATH=%ProgramFiles%\MSBuild\14.0\bin;%PATH%
@if exist "%ProgramFiles(x86)%\MSBuild\14.0\bin" set PATH=%ProgramFiles(x86)%\MSBuild\14.0\bin;%PATH%

@msbuild %~dp0..\..\CQL.sln /p:Configuration=Release
@nuget pack CQL.nuspec

@echo AND NOW EXECUTE AND TEST:
@echo  ./nuget push CQL.0.1.0.nupkg -source /c/Users/Markus/.nuget/

pause