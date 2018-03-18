@rmdir /S /Q CQL
@mkdir CQL

@MsBuild %~dp0MarkdownGenerator\MarkdownGenerator.sln /p:Configuration=Debug
@MsBuild %~dp0..\CQL.sln /p:Configuration=Debug

@MarkdownGenerator\bin\Debug\MarkdownGenerator.exe ..\CQL\bin\Debug\CQL.dll CQL