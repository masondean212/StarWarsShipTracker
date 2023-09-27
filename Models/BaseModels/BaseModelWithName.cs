namespace Models.BaseModels;

public abstract class BaseModelWithName : BaseModel
{
    public virtual string Name { get; set; } = string.Empty;
}