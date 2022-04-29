Add-Type -AssemblyName 'System.Drawing'

$ImagePath = $PSScriptRoot
$Images = Get-ChildItem $ImagePath
$ImageResizedPath = $ImagePath + "\resized"

Remove-Item -Path $ImageResizedPath -Recurse
mkdir -Path $ImageResizedPath 

$Width = 50
$Height = 50

ForEach($Image in $Images) {
    if($Image.Name -eq 'resized') { continue }
    if($Image.Name -eq $MyInvocation.MyCommand) { continue }

    $OldImage =  New-Object -TypeName System.Drawing.Bitmap -ArgumentList (Resolve-Path $Image.FullName).Path

    $Bitmap = New-Object -TypeName System.Drawing.Bitmap -ArgumentList $Width, $Height
    $NewImage = [System.Drawing.Graphics]::FromImage($Bitmap)
    $NewImage.DrawImage($OldImage, $(New-Object -TypeName System.Drawing.Rectangle -ArgumentList 0, 0, $Width, $Height))
    $Bitmap.Save($ImageResizedPath + "\Resized_" + $Image.Name)    
}
