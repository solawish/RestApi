using Autofac;
using DataProvider;
using Microsoft.Extensions.DependencyInjection;
using RestApi.Repository;
using RestApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Extension
{
    public static class ServicesExtensions
    {
        public static void DependencyInjection(this IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<IDataProvider>().As<SqlServerDataProvider>();
            builder.RegisterType<IShipperRepository>().As<ShipperRepository>();
            builder.RegisterType<IShipperService>().As<ShipperService>();
        }
    }
}
