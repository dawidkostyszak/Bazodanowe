using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Shop.Domain.Model.Album;

namespace Shop.Infrastructure
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();

                return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                              .ConnectionString(
                                  @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Dawid\documents\visual studio 2013\Projects\Shop\Product.Inftastructure\Database.mdf;Integrated Security=True")
                              .ShowSql()
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Album>().Conventions.Add(PrimaryKey.Name.Is(x => "ID")))
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
