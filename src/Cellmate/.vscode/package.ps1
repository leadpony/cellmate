$xml = [xml](Get-Content Cellmate.csproj)
$name = "Cellmate"
$version = $xml.Project.PropertyGroup.version[0]
$outdir = "bin\$name\$version"

dotnet publish -c Release -o $outdir

Copy-Item -Path ..\..\LICENSE -Destination $outdir
Copy-Item -Path ..\..\CHANGELOG.md -Destination $outdir
Copy-Item -Path .\Cellmate.psd1 -Destination $outdir

Compress-Archive -Path bin\$name -DestinationPath bin\$name-$version.zip