using System;
using Autofac;
using System.IO;
using System.Reflection;
using PDM.AppCore.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.Configuration;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace PDM.AppCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //配置
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options=> {
                //注册 返回规范的 全局过滤器
                options.Filters.Add(typeof(WebApiResultAttribute));
                options.RespectBrowserAcceptHeader = true;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //根目录
            var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0.0", new Info
                {
                    Version = "v1.0.0",
                    Title = "PDM.AppCore API",
                    Description = "接口说明文档",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "PDM.AppCore", Email = "", Url = "" }
                });

                var xmlPath = Path.Combine(Directory.GetCurrentDirectory(), "PDM.AppCore.xml");//这个就是刚刚配置的xml文件名
                c.IncludeXmlComments(xmlPath, true);//默认的第二个参数是false，这个是controller的注释，记得修改
                /*
                var xmlModelPath = Path.Combine(Directory.GetCurrentDirectory(), "PDM.Model.xml");
                c.IncludeXmlComments(xmlModelPath);
                */
            });
            #endregion
          
            #region AutoFac
            //实例化 AutoFac  容器   
            var builder = new ContainerBuilder();
            //通过反射将Services和Repository两个程序集的全部方法注入，要记得!!!这个注入的是实现类层，不是接口层 IServices
            try
            {
                var servicesDllFile = Path.Combine(basePath, "PDM.Services.dll");
                var assemblysServices = Assembly.LoadFrom(servicesDllFile);
                builder.RegisterAssemblyTypes(assemblysServices).AsImplementedInterfaces();
                var repositoryDllFile = Path.Combine(basePath, "PDM.Repository.dll");
                var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
                builder.RegisterAssemblyTypes(assemblysRepository).AsImplementedInterfaces();
            }
            catch (Exception)
            {
                throw new Exception("Startup 注册IOC失败");
            }

            //将services填充到Autofac容器生成器中
            builder.Populate(services);
            //使用已进行的组件登记创建新容器
            var ApplicationContainer = builder.Build();

            #endregion
            return new AutofacServiceProvider(ApplicationContainer);//第三方IOC接管 core内置DI容器
        }


        //使用
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0.0/swagger.json", "ApiHelp V1.0.0");
            });
            app.UseMvc();
        }
    }
}
