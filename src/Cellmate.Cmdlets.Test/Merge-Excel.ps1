Import-Module .\bin\Debug\net47\Cellmate.Cmdlets.dll
$books = @(
    "spec1.xlsx",
    "spec2.xlsx"
)

$pdf = $pwd.Path + "\merged.pdf"

Get-Item $books |
    Import-Excel -Verbose -Visible |
    Merge-Excel -Verbose -PageNumber -Path $pdf |
    Out-Null