# Challenge for Azure students

Create a web project and up in git to deploy in azure app service from git repository

> Note:

Consider build with the below commands, if you do change in the code and want to deploy it:

```bash
dotnet publish  --configuration Release --output out
Compress-Archive -Path .\out\* -DestinationPath ArchitectureChallange.zip.zip -Force
```

> Deploy to Azure with (whether you have changed the code or not):

```
az webapp deployment source config-zip --resource-group [ResourceGroup Name] --src .\ ArchitectureChallange.zip --name [webappservicename]
```