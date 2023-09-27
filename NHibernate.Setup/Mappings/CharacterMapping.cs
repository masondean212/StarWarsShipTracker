using Models;
using NHibernate.Setup.Mappings.BaseMappings;

namespace NHibernate.Setup.Mappings;

public class CharacterMapping : BaseMapWithName<CharacterModel>
{
    public CharacterMapping() : base("Characters")
    {
    }
}
