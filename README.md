# bp
Blood Pressure Calculator
ASP.Net Core

# Prerequisites

Create Azure Resource Group

	az group create --name {resource-group-name} --location {resource-group-location}

Alternatively, specifying the template/parameters: 

	az deployment group create --resource-group NAMEOFGROUP --template-file template.json --parameters parameters.json
		or
	az deployment group create --resource-group testrg --name rollout01 --template-file azuredeploy.json --parameters '{ \"policyName\": { \"value\": \"policy2\" } }'

Preparing for CICD integration will need creation of credentials:
 
	az ad sp create-for-rbac --name "{service-principal-name}" --sdk-auth --role contributor --scopes /subscriptions/{subscription-id}


