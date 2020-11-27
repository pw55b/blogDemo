using AutoMapper;
using Blog.Core.Interfaces;
using Blog.Infrastructure.Data;
using Blog.Infrastructure.Repositories;
using Blog.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using System;
using Blog.Api.Infrastructure.Repositories;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace Blog.APi
{
    public class StartupDevelopment
    {
        private readonly IConfiguration _configuration;

        public StartupDevelopment(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //允许返回406
            //添加xml支持
            //支持patch
            services.AddControllers(setup =>
            {
                setup.ReturnHttpNotAcceptable = true;
            }).AddNewtonsoftJson(setup =>
                    {
                        setup.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    }).AddXmlSerializerFormatters();
            //缓存
            //services.AddResponseCaching();
            //services.AddHttpCacheHeaders((expirationModelOptions) =>
            //    {
            //        expirationModelOptions.MaxAge = 60;
            //        expirationModelOptions.CacheLocation = CacheLocation.Private;
            //    },
            //    (validationModelOptions) =>
            //    {
            //        validationModelOptions.MustRevalidate = true;
            //    });
            //配置db
            services.AddDbContext<BlogDbContext>(options =>
            {
                var connectionString = _configuration.GetConnectionString("LocalConnectionString");
                options.UseSqlServer(connectionString);
            });
            //配置idp
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:5001";

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "RESTfulAPI");
                });
            });
            //Https重定向
            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                options.HttpsPort = 7001;
            });
            ////允许angular跨域
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowAngularOrigin",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                            .WithExposedHeaders("X-Pagination")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            //配置策略
            //services.Configure<MvcOptions>(options =>
            //{
            //    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            //    options.Filters.Add(new AuthorizeFilter(policy));
            //});
            //AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<IPropertyMappingService, PropertyMappingService>();
            //注册仓储
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostImageRepository, PostImageRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPostCategoriesRepository, PostCategoriesRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            //处理异常
            app.UseDeveloperExceptionPage();

            ////跨域
            app.UseCors("AllowAngularOrigin");
            //http重定向
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //缓存
            //app.UseResponseCaching();
            //app.UseHttpCacheHeaders();

            app.UseRouting();
            //将身份验证中间件添加到管道中，以便对主机的每次调用都将自动执行身份验证。
            
            app.UseAuthentication();
            //确保匿名客户端无法访问API端点
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //.RequireAuthorization("ApiScope"); ;
            });
        }
    }
}
