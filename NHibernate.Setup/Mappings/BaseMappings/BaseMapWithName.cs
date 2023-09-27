using FluentNHibernate.Mapping;
using Models.BaseModels;

namespace NHibernate.Setup.Mappings.BaseMappings;

public abstract class BaseMapWithName<T> : BaseMap<T> where T : BaseModelWithName
{
    public BaseMapWithName(string tableName) : base(tableName)
    {
        Map(x => x.Name);
    }
}
