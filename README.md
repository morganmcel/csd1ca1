# bp
Blood Pressure Calculator
ASP.Net Core

# Prerequisites

###### Azure CLI Setup
Windows WSL has an outdated version of Azure CLI installed. To remove this and install the latest, we need to run the following: 
	
	sudo apt remove azure-cli -y && sudo apt autoremove -y
	curl -sL https://aka.ms/InstallAzureCLIDeb | sudo bash


###### Create Azure Resource Group

	az login
	az group create --name {resource-group-name} --location {resource-group-location}

Alternatively, specifying the template/parameters: 

	az deployment group create --resource-group CA1 --template-file template.json --parameters parameters.json
		or
	az deployment group create --resource-group testrg --name rollout01 --template-file azuredeploy.json --parameters '{ \"policyName\": { \"value\": \"policy2\" } }'

###### Preparing for CICD integration will need creation of credentials:
 
	az ad sp create-for-rbac --name "{service-principal-name}" --sdk-auth --role contributor --scopes /subscriptions/{subscription-id}


