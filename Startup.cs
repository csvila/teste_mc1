using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ProductCatalog.Data;
using ProductCatalog.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace ProductCatalog
{
    public class Startup
    {
        //Aqui se adiciona o MiddleWere - Validações e services entre o Request/Response
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddResponseCompression(); 

            services.AddScoped<StoreDataContext, StoreDataContext>();

            services.AddTransient<ProductRepository, ProductRepository>();

            services.AddSwaggerGen(x => {
                x.SwaggerDoc("v1", new Info {Title = "ProductCatalog", Version = "v1"});
            });
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

                app.UseMvc();

                app.UseResponseCompression();

                app.UseSwagger();

                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductCatalog - V1");
                });
        }   
    }
}

