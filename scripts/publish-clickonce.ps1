param(
	[string]$ProjectPath = "Hospital_Management.csproj",
	[string]$PublishProfile = "Properties\PublishProfiles\ReleaseClickOnce.pubxml",
	[string]$FtpHost = "148.72.90.17",
	[int]$FtpPort = 21,
	[string]$FtpUser = "virender",
	[string]$FtpPassword = "Nimansh@2026"
)

if (-not (Test-Path $ProjectPath)) { Write-Error "Project file not found: $ProjectPath"; exit 1 }

Write-Host "Publishing ClickOnce using profile $PublishProfile to FTP $FtpHost:$FtpPort"

# Build publish command
$pubUrl = "ftp://$FtpHost/"
$msbuildArgs = "/t:Publish /p:PublishProfile=$PublishProfile /p:PublishUrl=$pubUrl /p:Configuration=Release /p:Password=$FtpPassword /p:UserName=$FtpUser"

Write-Host "Running msbuild $ProjectPath $msbuildArgs"

& msbuild $ProjectPath $msbuildArgs

if ($LASTEXITCODE -ne 0) { Write-Error "msbuild publish failed with exit code $LASTEXITCODE"; exit $LASTEXITCODE }

Write-Host "ClickOnce publish completed."
