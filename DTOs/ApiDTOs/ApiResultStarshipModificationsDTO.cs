namespace DTOs.ApiDTOs;

public class ApiResultStarshipModificationsDTO
{
    public string Name { get; set; }
    public int TypeEnum { get; set; }
    public string Type { get; set; }
    public IEnumerable<string> Prerequisites { get; set; }
    public string PrerequisitesJson { get; set; }
    public int Grade { get; set; }
    public string Content { get; set; }
    public int ContentTypeEnum { get; set; }
    public string ContentType { get; set; }
    public int ContentSourceEnum { get; set; }
    public string ContentSource { get; set; }
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public string Timestamp { get; set; }
    public string ETag { get; set; }
}
