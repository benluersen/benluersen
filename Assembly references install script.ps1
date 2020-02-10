#this finds and inherits the variables from VS DEV CONSOLE
pushd 'C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\Tools'    
cmd /c "vsvars32.bat&set" |
foreach {
  if ($_ -match "=") {
    $v = $_.split("="); set-item -force -path "ENV:\$($v[0])"  -value "$($v[1])"
  }
}
popd

#Just confirmation that the above worked. You should now be able to use VS 2015 dev console commands in powershell
write-host "`nVisual Studio 2015 Command Prompt variables set." -ForegroundColor Green

#The function uses msbuild.exe to rebuild individual files. Just plug in the path to the sln or proj and you're all set.
function buildVS
{
    param
    (
        [parameter(Mandatory=$true)]
        [String] $path
    )
    process
    {
        $msBuildExe = 'C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe'
        Write-Host "Building $($path)" -foregroundcolor green
        & "$($msBuildExe)" "$($path)" /t:Build /m
    }
}

#this shows how to start the function and give it the proper parameters.
buildVS -path C:\VSTS2016\TQL.BZT\Solutions\TQL.BZT.DAL\TQL.BZT.DAL.sln

#As you can see we can now just run any of the vs dev console commands
cd C:\VSTS2016\TQL.BZT\Common\Assemblies
gacutil /i TQL.BZT.Logger.dll

buildVS -path C:\VSTS2016\TQL.BZT\Solutions\TQL.BZT.AppTracking\TQL.BZT.AppTracking\TQL.BZT.AppTracking.sln

buildVS -path C:\VSTS2016\TQL.BZT\Solutions\TQL.BZT.DAL\TQL.BZT.DAL.sln

cd C:\VSTS2016\TQL.BZT\Solutions\TQL.BZT.AppTracking\TQL.BZT.AppTracking\bin\Debug
gacutil /i TQL.BZT.AppTracking.dll

#Opens solution where user input is required
C:\VSTS2016\TQL.BZT\Solutions\TQL.BZT.DAL\TQL.BZT.DAL.sln

#gives instructions for user to update newtonsoft. There is probably a better way to do this but i'm not sure what it is. Also need to figure out line breaks in choice prompt.
$title    = 'Please read'
$question = 'To continue right click TQL.BZT.Services and select "Manage NuGet Packeges". 
Then Update Newtonsoft.Json. Find the "Newtonsoft.Json.dll" file on your pc and place it into C:\VSTS2016\TQL.BZT\Common\Assemblies.
Close Visual Studio. If you have done all the steps press yes to continue?'
$choices = New-Object Collections.ObjectModel.Collection[Management.Automation.Host.ChoiceDescription]
$choices.Add((New-Object Management.Automation.Host.ChoiceDescription -ArgumentList '&Yes'))
$choices.Add((New-Object Management.Automation.Host.ChoiceDescription -ArgumentList '&No'))
$decision = $Host.UI.PromptForChoice($title, $question, $choices, 1)
if ($decision -eq 0) {
    Write-Host 'confirmed'
} else {
    Write-Host 'cancelled'
}

buildVS -path C:\VSTS2016\TQL.BZT.DAL\TQL.BZT.DAL.Services\TQL.BZT.DAL.Services.csproj

buildVS -path C:\VSTS2016\TQL.BZT\Solutions\TQL.BZT.DAL\TQL.BZT.DAL.Services.AutoAccept\TQL.BZT.DAL.Services.Async.csproj

cd C:\VSTS2016\TQL.BZT\Common\Assemblies
gacutil /i Newtonsoft.Json.dll
gacutil /i TQL.BZT.Logger.dll
cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.LoggingUtils

buildVS -path C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.BLL.sln

cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.LoggingUtils\bin\Debug
gacutil /i TQL.BZT.LoggingUtils.dll
cd C:\VSTS2016\TQL.BZT.DAL\TQL.BZT.DAL.EDI\bin\Debug
gacutil /i TQL.BZT.DAL.dll

buildVS -path C:\VSTS2016\TQL.BZT.DAL\TQL.BZT.DAL.Services\TQL.BZT.DAL.Services.csproj

cd C:\VSTS2016\TQL.BZT.DAL\TQL.BZT.DAL.Services\bin\Debug
gacutil /i TQL.BZT.DAL.Services.dll

buildVS -path C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.BLL.sln

buildVS -path C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.DataContracts\TQL.BZT.DataContracts.csproj

cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.DataContracts.AutoAccept\bin\Debug
gacutil /i TQL.BZT.DataContracts.AutoAccept.dll

buildVS -path C:\VSTS2016\TQL.BZT\Solutions\TQL.BZT.DAL\TQL.BZT.DAL.Services.AutoAccept\TQL.BZT.DAL.Services.Async.csproj

buildVS -path C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Repositories\TQL.BZT.Repositories.sln

cd C:\VSTS2016\TQL.BZT\Solutions\TQL.BZT.DAL\TQL.BZT.DAL.Services.AutoAccept\bin\Debug
gacutil /i TQL.BZT.DAL.Services.Async.dll
cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.DataContracts\bin\Debug
gacutil /i TQL.BZT.DataContracts.dll
cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.DataContracts.AutoAccept\bin\Debug
gacutil /i TQL.BZT.DataContracts.AutoAccept.dll
cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.DataContracts.ContractRates\bin\Debug
gacutil /i TQL.BZT.DataContracts.ContractRates.dll
cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.DataContracts.CustOrgRel\bin\Debug
gacutil /i TQL.BZT.DataContracts.CustOrgRel.dll
cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.DataContracts.FTP\bin\Debug
gacutil /i TQL.BZT.DataContracts.FTP.dll
cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.DataContracts.Status\bin\Debug
gacutil /i TQL.BZT.DataContracts.Status.dll
cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.EDIOverridesService.DataContracts\bin\Debug
gacutil /i TQL.BZT.EDIOverridesService.DataContracts.dll
cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.LMDataContracts\bin\Debug
gacutil /i TQL.BZT.LMDataContracts.dll
cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Repositories\bin\Debug
gacutil /i TQL.BZT.Repositories.dll

buildVS -path C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.BLL.sln

#The following does a find and replace for the hintpaths that need to be altered
(Get-Content C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Repositories\TQL.BZT.Repositories.csproj).Replace('<HintPath>..\..\..\..\TQL.BZT.DAL\TQL.BZT.DAL.EDI\bin\Debug\TQL.BZT.DAL.dll</HintPath>', '<HintPath>..\..\..\TQL.BZT.DAL\TQL.BZT.DAL.EDI\bin\Debug\TQL.BZT.DAL.dll</HintPath>') | Set-Content C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Repositories\TQL.BZT.Repositories.csproj

(Get-Content C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Repositories\TQL.BZT.Repositories.csproj).Replace('<HintPath>..\..\TQL.BZT.DAL\TQL.BZT.DAL.Services\bin\Debug\TQL.BZT.DAL.Services.dll</HintPath>', '<HintPath>..\..\..\TQL.BZT.DAL\TQL.BZT.DAL.Services\bin\Debug\TQL.BZT.DAL.Services.dll</HintPath>') | Set-Content C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Repositories\TQL.BZT.Repositories.csproj

(Get-Content C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Repositories\TQL.BZT.Repositories.csproj).Replace('<HintPath>..\..\..\..\TQL.BZT\Common\Assemblies\TQL.BZT.Logger.dll</HintPath>', '<HintPath>..\..\..\TQL.BZT\Common\Assemblies\TQL.BZT.Logger.dll</HintPath>') | Set-Content C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Repositories\TQL.BZT.Repositories.csproj

buildVS -path C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Repositories\TQL.BZT.Repositories.sln

buildVS -path C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Repositories\TQL.BZT.Repositories.csproj

cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Repositories\bin\Debug
gacutil /i TQL.BZT.Repositories.dll

C:\VSTS2016\TQL.BZT\Solutions\TQL.BZT.DAL\TQL.BZT.DAL.sln

buildVS -path C:\VSTS2016\Projects\Rules\TQL.BZT.Rules.Utils\TQL.BZT.Rules.Utils.csproj

$title    = 'Please read'
$question = 'right click on AutoAcceptAsync add build rules from "C:\VSTS2016\Projects\Rules\TQL.BZT.Rules.Utils\bin\Debug" Then click yes to continue'
$choices = New-Object Collections.ObjectModel.Collection[Management.Automation.Host.ChoiceDescription]
$choices.Add((New-Object Management.Automation.Host.ChoiceDescription -ArgumentList '&Yes'))
$choices.Add((New-Object Management.Automation.Host.ChoiceDescription -ArgumentList '&No'))
$decision = $Host.UI.PromptForChoice($title, $question, $choices, 1)
if ($decision -eq 0) {
    Write-Host 'confirmed'
} else {
    Write-Host 'cancelled'
}

buildVS -path C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Repositories.AutoAcceptAsync\TQL.BZT.Repositories.AutoAcceptAsync.csproj

$title    = 'Please read'
$question = 'Add repositories.dll reference to async from "C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Repositories\bin\Debug\" Then click yes to continue'
$choices = New-Object Collections.ObjectModel.Collection[Management.Automation.Host.ChoiceDescription]
$choices.Add((New-Object Management.Automation.Host.ChoiceDescription -ArgumentList '&Yes'))
$choices.Add((New-Object Management.Automation.Host.ChoiceDescription -ArgumentList '&No'))
$decision = $Host.UI.PromptForChoice($title, $question, $choices, 1)
if ($decision -eq 0) {
    Write-Host 'confirmed'
} else {
    Write-Host 'cancelled'
    }

buildVS -path C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Repositories.AutoAcceptAsync\TQL.BZT.Repositories.AutoAcceptAsync.csproj
builVS -path C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Controllers\TQL.BZT.Controllers.sln
buildVS -path C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Controllers.EDIBilling\TQL.BZT.Controllers.EDIBilling.csproj

cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Repositories.AutoAcceptAsync\bin\Debug
gacutil /i TQL.BZT.Repositories.AutoAcceptAsync.dll
cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Repositories.EDIBilling\bin\Debug
gacutil /i TQL.BZT.Repositories.EDIBilling.dll
cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Repositories.FTP\bin\Debug
gacutil /i TQL.BZT.Repositories.FTP.dll
cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Repositories.Status\bin\Debug
gacutil /i TQL.BZT.Repositories.Status.dll
cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Repositories.Validation\bin\Debug
gacutil /i TQL.BZT.Repositories.Validation.dll
cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Controllers\WCFController\bin\Debug
gacutil /i TQL.BZT.Controllers.dll
cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Controllers.EDIBilling\bin\Debug
gacutil /i TQL.BZT.Controllers.EDIBilling.dll
cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Controllers.Loads.DataContracts\bin\Debug
gacutil /i TQL.BZT.Controllers.Loads.DataContracts.dll
cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Controllers.Overrides\bin\Debug
gacutil /i TQL.BZT.Controllers.Overrides.dll
cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Controllers.Validation\bin\Debug
gacutil /i TQL.BZT.Controllers.Validation.dll
cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Utils\bin\Debug
gacutil /i TQL.BZT.Utils.dll

buildVS -path C:\VSTS2016\Projects\Imaging\TQL.BZT.Imaging\TQL.BZT.Imaging.sln

cd C:\VSTS2016\Projects\Imaging\TQL.BZT.Imaging\TQL.BZT.DAL.Imaging\bin\Debug
gacutil /i TQL.BZT.DAL.Imaging.dll
cd C:\VSTS2016\Projects\Imaging\TQL.BZT.Imaging\TQL.BZT.DataContracts.Imaging\bin\Debug
gacutil /i TQL.BZT.DataContracts.Imaging.dll
cd C:\VSTS2016\Projects\Imaging\TQL.BZT.Imaging\TQL.BZT.DataContracts.Imaging.Conversion\bin\Debug
gacutil /i TQL.BZT.DataContracts.Imaging.Conversion.dll
cd C:\VSTS2016\Projects\Imaging\TQL.BZT.Imaging\TQL.BZT.Repositories.Imaging\bin\Debug
gacutil /i TQL.BZT.Repositories.Imaging.dll
cd C:\VSTS2016\Projects\Imaging\TQL.BZT.Imaging\TQL.BZT.EDIPlus.Imaging.Utils.Converter\bin\Debug
gacutil /i TQL.BZT.EDIPlus.Imaging.Utils.Converter.dll
cd C:\VSTS2016\Projects\Imaging\TQL.BZT.Imaging\TQL.BZT.Rules.Utils.Imaging\bin\Debug
gacutil /i TQL.BZT.Rules.Utils.Imaging.dll
cd C:\VSTS2016\Projects\Imaging\TQL.BZT.Imaging\TQL.BZT.EDIPlus.Imaging.Utils\TQL.BZT.EDIPlus.Imaging.Utils\bin\Debug
gacutil /i TQL.BZT.EDIPlus.Imaging.Utils.dll

buildVS -path C:\VSTS2016\Projects\Rules\TQL.BZT.Rules\TQL.BZT.Rules.sln

cd C:\VSTS2016\Projects\Rules\TQL.BZT.Rules.LM\bin\Debug
gacutil /i TQL.BZT.Rules.LM.dll
cd C:\VSTS2016\Projects\Rules\TQL.BZT.Rules.Utils\bin\Debug
gacutil /i TQL.BZT.Rules.Utils.dll
cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.DataContracts\bin\Debug
gacutil /i TQL.BZT.DataContracts.dll
cd C:\VSTS2016\Projects\Rules\TQL.BZT.Rules.Interface\bin\Debug
gacutil /i TQL.BZT.Rules.Interface.dll
cd C:\VSTS2016\Projects\Rules\TQL.BZT.Rules\bin\Debug
gacutil /i TQL.BZT.Rules.dll

buildVS -path C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.BLL.sln

cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Controllers.Loads\bin\Debug
gacutil /i TQL.BZT.Controllers.Loads.dll
cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Utils.EDI210\bin\Debug
gacutil /i TQL.BZT.Utils.EDI210.dll
cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Utils.EDI210AutoBill\bin\Debug
gacutil /i TQL.BZT.Utils.EDI210AutoBill.dll
cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Utils.EDI214\bin\Debug
gacutil /i TQL.BZT.Utils.EDI214.dll
cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Utils.EDI214_Legacy\bin\Debug
gacutil /i TQL.BZT.Utils.EDI214_Legacy.dll
cd C:\VSTS2016\Projects\BLL\TQL.BZT.BLL\TQL.BZT.Utils.EDI990\bin\Debug
gacutil /i TQL.BZT.Utils.EDI990.dll

cd C:\VSTS2016\TQL.BZT\Common\Assemblies\Schemas	
gacutil /i TQL.BZT.API.Schemas.MercuryGate.dll	
gacutil /i TQL.BZT.EDI.FTPSchemas.dll
gacutil /i TQL.BZT.EDI.Schemas.AcctWF.dll
gacutil /i TQL.BZT.EDI.Schemas.Common.Inbound.3040.dll
gacutil /i TQL.BZT.EDI.Schemas.Common.Inbound.8XX.5010.dll
gacutil /i TQL.BZT.EDI.Schemas.Common.Inbound.dll
gacutil /i TQL.BZT.EDI.Schemas.Common.Outbound.dll
gacutil /i TQL.BZT.EDI.Schemas.Common.TPConnections.dll
gacutil /i TQL.BZT.EDI.Schemas.EDIBilling.dll
gacutil /i TQL.BZT.EDI.Schemas.EDIProcess.dll
gacutil /i TQL.BZT.EDI.Schemas.EDIProcess210.dll
gacutil /i TQL.BZT.EDI.Schemas.EDIProcess214.dll
gacutil /I TQL.BZT.EDI.Schemas.EDIProcessStatus.dll
gacutil /i TQL.BZT.EDI.Schemas.Properties.dll
gacutil /i TQL.BZT.EDI.Schemas.X12.3040.Inbound.dll
gacutil /i TQL.BZT.EDI.Schemas.X12.3040.Outbound.dll	
gacutil /i TQL.BZT.EDI.Schemas.X12.4030.Outbound.dll
gacutil /i TQL.BZT.EDI.Schemas.X12.Inbound.8XX.4060.dll
gacutil /i TQL.BZT.EDI.Schemas.X12.Inbound.8XX.dll
gacutil /i TQL.BZT.EDI.Schemas.X12.Inbound.dll
gacutil /i TQL.BZT.EDI.Schemas.X12.Outbound.dll
gacutil /i TQL.BZT.EDIPreprocessor.Schemas.dll
gacutil /i TQL.BZT.LTL.Schemas.dll
gacutil /i TQL.BZT.Project44.Schemas.dll	
gacutil /i TQL.BZT.Schemas.AcctWF.Validation.dll
gacutil /i TQL.BZT.Schemas.AcctWF.ValidationNoEDI.dll
gacutil /i TQL.BZT.Status.Schemas.dll