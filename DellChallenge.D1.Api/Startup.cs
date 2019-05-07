using AutoMapper;
using DellChallenge.D1.Api.Dal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace DellChallenge.D1.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //creating the database using Entity Framework Migrations
            //open command prompt
            //-> cd D:\Dell\DellChallenge\DellChallenge.D1.Api (change directory to current API folder location)
            //run the following comands -> dotnet ef migrations add InitialCreate
            //-> dotnet ef database update
            services.AddDbContext<DataContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            //services.AddDbContext<ProductsContext>(options => options.UseInMemoryDatabase("ProductsDb"));
            //services.AddTransient<IProductsService, ProductsService>();

            services.AddAutoMapper();
            services.AddTransient<Seed>();
            services.AddScoped<IProductsRepository, ProductsRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Products API", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowReactCors",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                    });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, Seed seeder)
        {
            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Products API V1");
            });

            seeder.SeedProducts();
            app.UseMvc();
            app.UseCors();
        }
    }
}
