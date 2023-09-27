using Models;
using NHibernate.Setup.Mappings.BaseMappings;

namespace NHibernate.Setup.Mappings;

public class SkillMapping : BaseMapWithName<SkillModel>
{
    public SkillMapping() : base("Skills")
    {
        Map(x => x.Ability);
    }
}
