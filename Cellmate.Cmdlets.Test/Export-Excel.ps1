Import-Module .\bin\Debug\net47\Cellmate.Cmdlets.dll

Get-Item *.xlsx |
    Import-Excel |
    ConvertFrom-Excel -Format pdf