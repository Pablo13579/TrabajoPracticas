#
# Script.ps1
#
$scriptPath=$PSScriptRoot
#$scriptPath="C:\Users\practicas36\Desktop\ImagenesRandomResizeOld"

cd $scriptPath
Remove-Item -Recurse -Force "resized"
mkdir "resized"
Write-Host $scriptPath
$files = Get-ChildItem $scriptPath -Filter *.jfif

foreach ($file in $files) {
	$oldPath=$file.FullName
	$baseName=$file.BaseName
	$ext=$file.Extension
	$newPath="$scriptPath\resized\$baseName-1x1$ext"
	#Copy-Item $oldPath $newPath
	magick "$oldPath" -resize 1x1 -background white -gravity center -extent 1x1 "$newPath"
}

Write-Host "Press any key to continue ..."
$x = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")