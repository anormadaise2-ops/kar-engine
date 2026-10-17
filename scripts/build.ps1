$ErrorActionPreference = "Stop"

$Root = Split-Path $PSScriptRoot -Parent
$Project = Join-Path $Root "src\KarEngine\KarEngine.csproj"
$Release = Join-Path $Root "release"
$Logs = Join-Path $Root "logs"
$Log = Join-Path $Logs "build.log"

New-Item -ItemType Directory -Path $Release -Force | Out-Null
New-Item -ItemType Directory -Path $Logs -Force | Out-Null

Start-Transcript -Path $Log -Append

try {
    Write-Host "`n=== KAR ENGINE BUILD SYSTEM ===" -ForegroundColor Cyan

    if (!(Get-Command dotnet -ErrorAction SilentlyContinue)) {
        throw ".NET SDK introuvable. Installe le SDK .NET 8."
    }

    if (!(Test-Path $Project)) {
        throw "Fichier projet introuvable : $Project"
    }

    Write-Host "`n[1/4] Vérification du SDK"
    dotnet --info
    if ($LASTEXITCODE -ne 0) {
        throw "Impossible de lire les informations .NET."
    }

    Write-Host "`n[2/4] Restauration des dépendances"
    dotnet restore $Project
    if ($LASTEXITCODE -ne 0) {
        throw "Échec de restauration. Voir logs\build.log."
    }

    Write-Host "`n[3/4] Compilation Release"
    dotnet build $Project -c Release --no-restore
    if ($LASTEXITCODE -ne 0) {
        throw "Échec de compilation. Voir logs\build.log."
    }

    Write-Host "`n[4/4] Publication EXE autonome"
    dotnet publish $Project `
        -c Release `
        -r win-x64 `
        --self-contained true `
        -p:PublishSingleFile=true `
        -p:IncludeNativeLibrariesForSelfExtract=true `
        -o $Release

    if ($LASTEXITCODE -ne 0) {
        throw "Échec de publication de l'EXE."
    }

    $Exe = Join-Path $Release "kar.exe"

    if (!(Test-Path $Exe)) {
        throw "La publication est terminée, mais kar.exe est introuvable."
    }

    Write-Host "`n=== BUILD RÉUSSI ===" -ForegroundColor Green
    Write-Host "EXE : $Exe"
    Write-Host "Taille : $([math]::Round((Get-Item $Exe).Length / 1MB, 2)) Mo"

    Write-Host "`n=== TESTS ===" -ForegroundColor Cyan

    & $Exe --version
    if ($LASTEXITCODE -ne 0) {
        throw "Le test --version a échoué."
    }

    & $Exe doctor
    if ($LASTEXITCODE -ne 0) {
        throw "Le test doctor a échoué."
    }

    Write-Host "`nBuild et tests terminés." -ForegroundColor Green
}
catch {
    Write-Host "`nERREUR : $($_.Exception.Message)" -ForegroundColor Red
    Write-Host "Consulte le journal : $Log"
    exit 1
}
finally {
    Stop-Transcript
}
