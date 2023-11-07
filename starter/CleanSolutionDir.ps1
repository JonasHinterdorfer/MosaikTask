Get-ChildItem -Path $PSScriptroot -Recurse -Force  -Include '.vs', '.git', 'bin', 'obj',  '*.Dotsettings' | ForEach-Object {
    Remove-Item -Recurse -Force -LiteralPath $_.FullName >$null
}
