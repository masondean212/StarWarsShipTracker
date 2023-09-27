using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using NHibernate.Setup.Mappings;

namespace Configuration;

public static class NHibernateConfiguration
{
    public static void Configure(IServiceCollection services, string connectionString)
    {
        services.AddSingleton(x => Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2012
                .ShowSql()
                .FormatSql()
                .ConnectionString(p => p.Is(connectionString))
                .AdoNetBatchSize(20)
                .DefaultSchema("dbo"))
            .ExposeConfiguration(c => c.SetProperty(NHibernate.Cfg.Environment.CommandTimeout, "300"))
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ShipMapping>())
            .BuildSessionFactory());

        services.AddSingleton(x =>
        {
            var sessionFactory = x.GetService<ISessionFactory>();
            if (sessionFactory == null)
            {
                throw new Exception("Could not initialize a session factory before warming up the ORM");
            }
            return sessionFactory.OpenSession();
        });

    }
}
