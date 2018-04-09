using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Formatters;
using GenschiStockHandler.Repository;
using GenschiStockHandler.Repository.Interfaces;
using GenschiStockHandler.Business;
using GenschiStockHandler.Business.Interfaces;
using AutoMapper;
using Dapper;
using MediatR;
using GenschiStockHandler.API.Extensions;
using System.Reflection;

namespace GenschiStockHandler.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc(setupAction =>
            {
                // (^_^): Return 406 for Non JSON request
                setupAction.ReturnHttpNotAcceptable = true;
                // (^_^): Accept header for XML allowed
                setupAction.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                // (^_^): XML INPUT formatter too
                setupAction.InputFormatters.Add(new XmlDataContractSerializerInputFormatter());
            });
            services.AddTransient<AppDb>(_ => new AppDb(Configuration[key: "ConnectionStrings:DefaultConnection"]));


            // register services
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductManager, ProductManager>();

            services.AddAutoMapper();

            services.AddScoped<IMediator, Mediator>();
            services.AddTransient<SingleInstanceFactory>(sp => t => sp.GetService(t));
            services.AddTransient<MultiInstanceFactory>(sp => t => sp.GetServices(t));
            services.AddMediatorHandlers(typeof(Startup).GetTypeInfo().Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            SqlMapper.AddTypeHandler(typeof(Dictionary<string, object>), new JsonObjectTypeHandler());

        }
    }
}
