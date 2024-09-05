# Challenge for Azure students

## Deployment on Azure App Service from a published content and zipped ☁️

1. Create a web project in dotnet
2. Create a App Service on Azure

> [!IMPORTANT]
>
> Consider use the commands bellow, if you do changes in the code and want to re-deploy it:
>
> ```powershell
> dotnet publish  --configuration Release --output publish
> Compress-Archive -Path .\publish\* -DestinationPath ArchitectureChallange.zip -Force
> ```

3. Deploy to Azure (whether you have changed the code or not):

   ```powershell
   az webapp deploy --resource-group [ResourceGroup name] --name [webappservicename] --src-path ArchitectureChallange.zip 
   ```

**Happy Coding!**

> 😉 **Remember to connect to Azure**

```
az account set --subscription [Subscription ID]
az login
az group list --output table
```