namespace ArchitectureChallange.Services;
using ArchitectureChallange.Entities;
using Azure.Data.Tables;
public interface ITableStorageService
{
    Task<string> Id();
}

public class TableStorageService : ITableStorageService
{
    private const string TableName = "history";
    private readonly IConfiguration? configuration;
    public TableStorageService(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    async Task<string> ITableStorageService.Id()
    {
        var stringConection = string.Empty;
        try
        {
            if (configuration is null)
                throw new Exception("invalid configuration settings");
            stringConection = configuration["storageConnectionString"];
            if (stringConection is null) {
                stringConection = "Don't implemented the table azure storage integration";
                return stringConection;
            }
        }
        catch
        {
            stringConection = "Don't implemented the table azure storage integration";
            return stringConection;
        }

        var serviceClient = new TableServiceClient(stringConection);
        var tableClient = serviceClient.GetTableClient(TableName);
        await tableClient.CreateIfNotExistsAsync();
        var hist1 = new History()
        {
            RowKey = "68719518388",
            PartitionKey = "historico one",
            Id = "234"
        };
        var queryResults = tableClient.QueryAsync<History>(filter: $"PartitionKey eq '{hist1.PartitionKey}'");
        int count = 0;
        await foreach (History qEntity in queryResults) {
            count++;
        }
        if (count==0) {
            await tableClient.AddEntityAsync<History>(hist1);
        }
        var histo2 = await tableClient.GetEntityAsync<History>(
            rowKey: "68719518388",
            partitionKey: "historico one"
        );
        var idReturned = string.Empty;
        if (histo2.Value.Id == null)
            idReturned = "invalid ID";
        else
            idReturned = histo2.Value.Id;
        return idReturned;
    }
}