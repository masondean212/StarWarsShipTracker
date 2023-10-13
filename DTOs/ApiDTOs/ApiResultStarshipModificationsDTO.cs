namespace DTOs.ApiDTOs;

public class ApiResultStarshipModificationsDTO
{
    public string name { get; set; }
    public int typeEnum { get; set; }
    public string type { get; set; }
    public List<string> prerequisites { get; set; }
    public string prerequisitesJson { get; set; }
    public int grade { get; set; }
    public string content { get; set; }
    public int contentTypeEnum { get; set; }
    public string contentType { get; set; }
    public int contentSourceEnum { get; set; }
    public string contentSource { get; set; }
    public string partitionKey { get; set; }
    public string rowKey { get; set; }
    public DateTime timestamp { get; set; }
    public string eTag { get; set; }
}
