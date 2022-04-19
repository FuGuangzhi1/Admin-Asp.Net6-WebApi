using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Common_Fu.Redis;
using Microsoft.Extensions.DependencyInjection;
using ShowTimeCode.Extensions;
using ShowTimeCode.Utility.Autofac;
using System.Configuration;

namespace ShowTimeCode;
internal class Program
{
    private async static Task Main(string[] args)
    {
        await Task.Run(() =>
         {
             WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
             IConfiguration configuration = builder.Configuration;
             builder.Logging.AddLog4Net(Path.Combine(Directory.GetCurrentDirectory(), "Config/log4net.config"));
             builder.Services.AddControllers();
             builder.Services.AddEndpointsApiExplorer();
             builder.Services.AddSwaggerGen();
             builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
             builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
             {
                 builder.RegisterModule<AutofacModule>();
             });
             builder.Services.AddConfig(configuration);
             //builder.Services.AddIOC();
             builder.Services.AddFilter();
             builder.Services.AddJWT(configuration);
             builder.Services.AddRedis(configuration);      
             builder.Services.AddCors(options => options
             .AddPolicy("All", builder => builder
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader()));
             var app = builder.Build();

             // Configure the HTTP request pipeline.
             if (app.Environment.IsDevelopment())
             {
                 app.UseSwagger();
                 app.UseSwaggerUI();
             }

             app.UseAuthentication(); //鉴权
            app.UseAuthorization();//授权

            app.UseRouting();     //路由
            app.UseCors("All");       //跨域
            app.MapControllers();

             app.Run();
         });
    }
}