@if exist "%ProgramFiles%\MSBuild\14.0\bin" set PATH=%ProgramFiles%\MSBuild\14.0\bin;%PATH%
@if exist "%ProgramFiles(x86)%\MSBuild\14.0\bin" set PATH=%ProgramFiles(x86)%\MSBuild\14.0\bin;%PATH%

@rmdir /S /Q CQL
@mkdir CQL

@msbuild %~dp0..\CQL.sln /p:Configuration=Debug /p:DocumentationFile=${SolutionDir}\docs\CQL\source.xml
@java -jar ..\Tools\saxon\saxon9he.jar CQL.doc.xml doc2mds.xsl outputDir=./CQL