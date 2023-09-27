using FluentNHibernate.Mapping;
using Models.BaseModels;

namespace NHibernate.Setup.Mappings.BaseMappings;

public abstract class BaseMap<T> : ClassMap<T> where T : BaseModel
{
    public BaseMap(string tableName)
    {
        Table(tableName);
        Id(x => x.Id);
    }
}
