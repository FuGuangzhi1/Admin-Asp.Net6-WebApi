using Abstract_Fu.Account;
using Abstract_Fu.Home;
using Abstract_Fu.PersonalManagement.PersonalInfo;
using Abstract_Fu.PersonalManagement.StudyInfo;
using Common_Fu.Redis;
using EFCore_Fu.EFCoreFactroy;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Realization_Fu.Account;
using Realization_Fu.Home;
using Realization_Fu.PersonalManagement.PersonalInfo;
using Realization_Fu.PersonalManagement.StudyInfo;
using ShowTimeCode.AOPFilter.FiveFilters;
using ShowTimeCode.JWTHelper;
using System.Text;

namespace ShowTimeCode.Extensions;

public static partial class Extensions
{
    /// <summary>
    /// 全局过滤器配置
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddFilter(this IServiceCollection services)
    {
        services.AddMvc(options =>
        {
            options.Filters.Add(typeof(CustomActionFilterAttribute));
            options.Filters.Add(typeof(CustomAuthonizationFilterAttribute));
            options.Filters.Add(typeof(CustomExceptionFilterAttribute));
            options.Filters.Add(typeof(CustomResultFilterAttribute));
           // options.Filters.Add(typeof(CustomResourceFilterAttribute));
            //options.Filters.Add(typeof(ValidateModelAttribute));
            options.Filters.Add(new AuthorizeFilter());

        });

        return services;
    }

    /// <summary>
    /// JWT配置
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddJWT(this IServiceCollection services, IConfiguration configuration)
    {
        #region Swagger配置请求头Token
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer",
                  new OpenApiSecurityScheme
                  {
                      Description = "直接在下框中输入JWT生成的Token",
                      Name = "Authorization",
                      In = ParameterLocation.Header,
                      Type = SecuritySchemeType.ApiKey,
                      BearerFormat = "JWT",
                      Scheme = "Bearer"
                  });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
                    {
                        new OpenApiSecurityScheme{Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                       Array.Empty<string>()
                    }
        });
            // options.OperationFilter<AuthTokenHeaderParameter>();
        });
        #endregion

        #region 注册jwt
        JWTTokenOptions jWTTokenOptions = new();
        var jwtValue = configuration.GetSection("JWTToken");
        //获取appsettings的内容
        services.Configure<JWTTokenOptions>(jwtValue);
        //将给定的对象实例绑定到指定的配置节
        configuration.Bind("JWTToken", jWTTokenOptions);

        //注册到Ioc容器
        services.AddSingleton(jWTTokenOptions);

        //添加验证服务
        services.AddAuthentication(option =>
        {
            //默认身份验证模式
            option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //默认方案
            option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(option =>
        {
            //设置元数据地址或权限是否需要HTTP
            option.RequireHttpsMetadata = false;
            option.SaveToken = true;
            //令牌验证参数
            option.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                //获取或设置要使用的Microsoft.IdentityModel.Tokens.SecurityKey用于签名验证。
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.
        GetBytes(jWTTokenOptions.Secret ?? "")),
                //获取或设置一个System.String，它表示将使用的有效发行者检查代币的发行者。 
                ValidIssuer = jWTTokenOptions.Issuer,
                //获取或设置一个字符串，该字符串表示将用于检查的有效受众反对令牌的观众。
                ValidAudience = jWTTokenOptions.Audience,
                //是否验证发起人
                ValidateIssuer = false,
                //是否验证订阅者
                ValidateAudience = false,
                ////允许的服务器时间偏移量
                ClockSkew = TimeSpan.Zero,
                ////是否验证Token有效期，使用当前时间与Token的Claims中的NotBefore和Expires对比
                ValidateLifetime = true
            };
            //如果jwt过期，在返回的header中加入Token-Expired字段为true，前端在获取返回header时判断
            option.Events = new JwtBearerEvents()
            {
                OnAuthenticationFailed = context =>
                {
                    if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                    {
                        context.Response.Headers.Add("Token-Expired", "true");
                    }
                    return Task.CompletedTask;
                }
            };
        });
        #endregion
        return services;
    }
    public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration.GetSection("IsRedisRun").Value.ToBool())
        {
            CustomRedisConfig customRedisConfig = new();
            var redisconfig = configuration.GetSection("Redis");

            var defaultRedis = redisconfig.GetSection("Default");
            //获取appsettings的内容
            services.Configure<CustomRedisConfig>(defaultRedis);
            configuration.Bind("Redis:Default", customRedisConfig);
            services.AddSingleton(new RedisHelper(customRedisConfig));
        }

        return services;
    }

}

