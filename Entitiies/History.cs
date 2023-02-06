
using Azure;
using Azure.Data.Tables;
namespace ArchitectureChallange.Entities;
public class History : ITableEntity
{
    public string? PartitionKey {get; set;}
    public string? RowKey {get; set;}
    public DateTimeOffset? Timestamp {get; set;}
    public ETag ETag {get; set;}
    public string? Name {get; set;}
    public string? Id {get; set;}
}
