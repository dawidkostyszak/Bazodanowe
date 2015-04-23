﻿using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Shop.Infrastructure.Mappings;

namespace Shop.Infrastructure
{
    public class NHibernateHelper
    {
        private static string _connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Dawid\documents\visual studio 2013\Projects\Shop\Shop.Infrastructure\ShopDatabase.mdf;Integrated Security=True";

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
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(_connectionString))
                .Mappings(m => m.FluentMappings
                    .Add<AlbumMap>()
                    .Add<ArtistMap>()
                    .Add<CategoryMap>()
                    .Add<UserMap>()
                    .Add<AddressMap>()
                    .Add<NameMap>()
                    .Add<ValidationsMap>()
                    .Add<OrderMap>()
                ).BuildSessionFactory();                
        }

        public static IStatelessSession OpenSession()
        {
            return SessionFactory.OpenStatelessSession();
        }
    }
}
