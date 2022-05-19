using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudifyProject.Data;
using AudifyProject.Models;
using AudifyProject.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Storage;

namespace AudifyProject
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
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IFirebaseService, FirebaseService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
            string connetionString = Configuration.GetConnectionString("MysqlConnection");
            services.AddDbContextPool<ApplicationDbContext>(options =>
            {

                //options.UseLoggerFactory(MyLoggerFactory);
                options.UseMySql(
                     connetionString,
                     builder =>
                     {
                         builder.MigrationsAssembly(typeof(Startup).Assembly.FullName);
                         builder.EnableRetryOnFailure(
                            maxRetryCount: 10,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
                     }
                   );
            }, 20);
            

            /* services.AddDbContextPool<ApplicationDbContext>(options =>
             {
                 //options.UseLoggerFactory(MyLoggerFactory);
                 options.UseMySql(
                     connectionString: connetionString,
                     mySqlOptionsAction: builder =>
                     {
                         builder.EnableRetryOnFailure(
                             maxRetryCount: 10,
                             maxRetryDelay: TimeSpan.FromSeconds(30),
                             errorNumbersToAdd: null);
                     },
                     serverVersion: ServerVersion.AutoDetect(connetionString));
             }, 20);
            /* services.AddDbContext<ApplicationDbContext>(options =>


                    options.UseMySql(Configuration.GetConnectionString("MysqlConnection"), mysql =>
                    {
                        mysql.EnableRetryOnFailure();
                    })

                    );
             */
            services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = long.MaxValue; // <-- ! long.MaxValue
                options.MultipartBoundaryLengthLimit = int.MaxValue;
                options.MultipartHeadersCountLimit = int.MaxValue;
                options.MultipartHeadersLengthLimit = int.MaxValue;
            });
            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<ApplicationRole>()
               .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddAutoMapper(typeof(Startup));
            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });

            services.AddAuthentication()

         .AddJwtBearer(options =>
         {
             options.SaveToken = true;
             options.RequireHttpsMetadata = false;
             options.TokenValidationParameters = new TokenValidationParameters()
             {
                 ValidateIssuer = true,
                 ValidateAudience = true,
                 ValidAudience = Configuration["JWT:ValidAudience"],
                 ValidIssuer = Configuration["JWT:ValidIssuer"],
                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
             };
         });
         

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Audify API",
                    Version = "v1",
                    Description = "Description for the API goes here.",
                    Contact = new OpenApiContact
                    {
                        Name = "Ko Ko Thein",
                        Email = string.Empty,
                       
                    },
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Audify V1 API");

                // To serve SwaggerUI at application's root page, set the RoutePrefix property to an empty string.
                // c.RoutePrefix = string.Empty;
            });
            MyIdentityDataInitializer.SeedData(userManager, roleManager);
            app.UseAuthorization();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            
            /*app.Use(async (context, next) =>
            {
                context.Features.Get<IHttpMaxRequestBodySizeFeature>().MaxRequestBodySize = null; // unlimited I guess
                await next.Invoke();
            });
            */

        }
    }
}
