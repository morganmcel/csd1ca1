# bp
Blood Pressure Calculator
ASP.Net Core

# Prerequisites

###### Azure CLI Setup
Windows WSL has an outdated version of Azure CLI installed. To remove this and install the latest, we need to run the following: 
	
	sudo apt remove azure-cli -y && sudo apt autoremove -y
	curl -sL https://aka.ms/InstallAzureCLIDeb | sudo bash

##### Azure PowerShell Setup
On Windows 10, PowerShell 7.2 needed to be installed from <https://docs.microsoft.com/en-us/powershell/scripting/install/installing-powershell> prior to installing Azure tools
	Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser
	Install-Module -Name Az -Scope CurrentUser -Repository PSGallery -Force -AllowClobber
	Connect-AzAccount

###### Azure ARM Template validation

	Set-ExecutionPolicy -ExecutionPolicy Unrestricted -Scope CurrentUser
	Import-Module .\arm-ttk.psd1
	Test-AzTemplate -TemplatePath .\resources.json

Further information from: <https://docs.microsoft.com/en-us/azure/azure-resource-manager/templates/test-toolkit>

###### Create Azure Resource Group

	az login
	az group create --name {resource-group-name} --location {resource-group-location}
	az group create --name CSDCA1v2 --location "North Europe"

###### Options for creating resources from ARM Template: 

	az deployment group create --resource-group CA1 --template-file template.json --parameters parameters.json

or
	
	templateFile="IAC/resources.json"
	az deployment group create --name blanktemplate --resource-group CSDCA1v2 --template-file $templateFile	

or
	
	az deployment group create --resource-group testrg --name rollout01 --template-file azuredeploy.json --parameters '{ \"policyName\": { \"value\": \"policy2\" } }'


###### Preparing for CICD integration will need creation of credentials:
 
	az ad sp create-for-rbac --name "{service-principal-name}" --sdk-auth --role contributor --scopes /subscriptions/{subscription-id}
		or more specifically:
	az ad sp create-for-rbac --name {myApp} --role contributor --scopes /subscriptions/{subscription-id}/resourceGroups/{MyResourceGroup} --sdk-auth

	az ad sp create-for-rbac --name CSD --role contributor --scopes /subscriptions/bf62df4b-3ac0-4f1d-9671-14a98c945779/resourceGroups/CSDCA1v2 --sdk-auth

###### Random useful commands: 

	templateFile="IAC-Templates/mstemplate.json"
	az deployment group create --name addAppService --resource-group CSDCA1v2 --template-file $templateFile
	az webapp deployment list-publishing-profiles --name webApp-xfroiewir2rhs --resource-group CSDCA1v2
	az deployment group list --resource-group CSDCA1v2
	az deployment group delete --resource-group CSDCA1v2 --name addAppService

Powershell: 
	
	Get-AzWebAppSlotPublishingProfile -ResourceGroupName "CSDCA1v2" -Name "morganmc-bmi2Portal" -Slot "Dev"

Further review needed, but possible steps to pull publish-profile in GitHub action programatically for specific slot
	$Profile=Get-AzWebAppSlotPublishingProfile -ResourceGroupName "CSDCA1v2" -Name "morganmc-bmi2Portal" -Slot "Dev"
	$profile = $profile.Replace("`r", "").Replace("`n", "")
	Write-Output "::set-output name=profile::$profile"


##### Final set of steps

	az group create --name CSDCA1v2 --location "North Europe"
	az ad sp create-for-rbac --name CSD --role contributor --scopes /subscriptions/bf62df4b-3ac0-4f1d-9671-14a98c945779/resourceGroups/CSDCA1v2 --sdk-auth


