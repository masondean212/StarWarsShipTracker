using Models.BaseModels;

namespace Models;

public class SkillModel : BaseModelWithName
{
    public virtual string Ability { get; set; } = string.Empty;
}
