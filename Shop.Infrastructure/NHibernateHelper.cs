using System.Reflection;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Cfg;
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
//            var configuration = new Configuration();
//            var configurationPath = HttpContext.Current.Server.MapPath(@"~\Shop.Infrastructure\hibernate.cfg.xml");
//            configuration.Configure(configurationPath);
//            var configurationFile = HttpContext.Current.Server.MapPath(@"~\Shop.Domain\Model\Album\Album.hbm.xml");
//            configuration.AddFile(configurationFile);
//            _sessionFactory = configuration.BuildSessionFactory();

            _sessionFactory = Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Dawid\documents\visual studio 2013\Projects\Shop\Shop.Infrastructure\ShopDatabase.mdf;Integrated Security=True"
                    ).ShowSql()
                )
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                .BuildSessionFactory();
                
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
