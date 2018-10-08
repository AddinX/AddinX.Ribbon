Set Configuration=Release

cd ../src

call dotnet build  ExcelDna.RibbonFluent  --force  -c %Configuration%

cd ../tools
pause