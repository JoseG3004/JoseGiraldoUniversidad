@echo off
echo Iniciando backend ManejoDeCultivos...

:: Inicia la API de .NET en segundo plano para no bloquear el script
start /b cmd /c "dotnet run --project ManejoDeCultivos"

echo Esperando a que el API levante y compile...
timeout /t 5 /nobreak >nul

echo Abriendo la interfaz...
if exist "GranjaFront\index.html" (
    start GranjaFront\index.html 
) else (
    echo No se encontro la carpeta del frontend.
)

pause