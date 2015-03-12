@echo off
cls
IF NOT EXIST "packages\FAKE\tools\Fake.exe" (
".nuget\NuGet.exe" "Install" "FAKE" "-OutputDirectory" "packages" "-ExcludeVersion"
)
"packages\FAKE\tools\Fake.exe" build.fsx
pause