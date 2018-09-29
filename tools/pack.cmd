
Set Configuration=Release
set YYYYmmdd=%date:~0,4%%date:~5,2%%date:~8,2%
Set suffix=build%YYYYmmdd%

Set version-suffix=--version-suffix "%suffix%"

cd ../src

call dotnet pack  ExcelDna.RibbonFluent  --force  -c %Configuration%  %version-suffix%

cd ../tools