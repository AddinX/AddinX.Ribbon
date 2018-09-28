
@echo CSharp Command-Line Compile
@echo off
@echo Usage:
@echo  build.cmd @Config @Platform
@echo 		@Config: Release or Debug. The default value is Release
@echo  		@Platform: x64 or x86. The default value is x64
@echo  build.cmd clear to remove all previous build for this solution
@Set PATH="%ProgramFiles(x86)%\MSBuild\14.0\Bin";%PATH%
set config=Release
set platform="Any Cpu"
set solution = AddinX.Ribbon.sln

IF [%1] EQU [clean]  GOTO CleanAll 
IF [%1] EQU [clear]  GOTO CleanAll

IF [%1] EQU [] GOTO RunCmd
set config=%1
:CheckPlatform
IF [%2] EQU [] GOTO RunCmd
set platform=%2


IF [%1] NEQ "Release" IF [%1] NEQ "Debug" GOTO RunCmd
goto RunCmd

:CleanAll
msbuild.exe %solution% /property:Configuration=Debug /property:Platform=x86 /t:clean
msbuild.exe %solution% /property:Configuration=Debug /property:Platform=x64 /t:clean
msbuild.exe %solution% /property:Configuration=Release /property:Platform=x86 /t:clean
msbuild.exe %solution% /property:Configuration=Release /property:Platform=x64 /t:clean

goto finish

:RunCmd
@echo %config%
@echo %platform%
msbuild.exe %solution% /property:Configuration=%config% /property:Platform=%platform% /t:rebuild  
rem /verbosity:quiet 

:finish
@echo on