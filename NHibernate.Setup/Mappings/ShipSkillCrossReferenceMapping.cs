using Models;
using NHibernate.Setup.Mappings.BaseMappings;

namespace NHibernate.Setup.Mappings;

public class ShipSkillCrossReferenceMapping : BaseMap<ShipSkillCrossReferenceModel>
{
    public ShipSkillCrossReferenceMapping() : base("ShipSkillCrossReference")
    {
        CompositeId()
        .KeyReference(x => x.Ship, "ShipId")
        .KeyReference(x => x.Skill, "SkillId");
        Map(x => x.Proficiency);
    }
}
