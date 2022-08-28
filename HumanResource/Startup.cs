using HumanResource.Data;
using HumanResource.Models;
using HumanResource.Security;
using HumanResource.Utilities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResource
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllersWithViews();
           // services.AddRazorPages();
            services.AddRazorPages()
                .AddMvcOptions(options =>
                {
                    options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                        _ => "The field is required.");
             });
            //to change in Identity Tables
            services.Configure<IdentityOptions>(option =>
                              option.User.RequireUniqueEmail = true);

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme,
             options =>
             {
                 options.LoginPath = "/Accounting/Login";
                 options.LogoutPath = "/Accounting/Logout";
                 options.AccessDeniedPath = "/Accounting/AccessDenied";
                 options.SlidingExpiration = true;
                 options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
             });
            services.AddAuthorizationCore(
                options =>
                {
                    //options.AddPolicy("UsersEdit",
                    //    policy => policy.RequireAssertion(
                    //              context =>context.User.HasClaim());
                    options.AddPolicy("UsersShow",
                        policy => policy.RequireClaim("UsersShow", "true"));

                    options.AddPolicy("UsersAdd",
                        policy => policy.RequireClaim("UsersAdd", "true"));
                    options.AddPolicy("UsersEdit",
                        policy => policy.RequireClaim("UsersEdit", "true"));
                    options.AddPolicy("UsersDelete",
                        policy => policy.RequireClaim("UsersDelete", "true"));
                    
                    options.AddPolicy("PermissionsShow",
                        policy => policy.RequireClaim("PermissionsShow", "true"));
                    options.AddPolicy("PermissionsAdd",
                        policy => policy.RequireClaim("PermissionsAdd", "true"));
                    options.AddPolicy("PermissionsEdit",
                        policy => policy.RequireClaim("PermissionsEdit", "true"));
                    options.AddPolicy("PermissionsDelete",
                        policy => policy.RequireClaim("PermissionsDelete", "true"));

                    options.AddPolicy("GeneralSettingShow",
                        policy => policy.RequireClaim("GeneralSettingShow", "true"));
                    options.AddPolicy("GeneralSettingAdd",
                        policy => policy.RequireClaim("GeneralSettingAdd", "true"));
                    options.AddPolicy("GeneralSettingEdit",
                        policy => policy.RequireClaim("GeneralSettingEdit", "true"));
                    options.AddPolicy("GeneralSettingDelete",
                        policy => policy.RequireClaim("GeneralSettingDelete", "true"));
                   
                    options.AddPolicy("SalaryShow",
                        policy => policy.RequireClaim("SalaryShow", "true"));
                    options.AddPolicy("SalaryAdd",
                        policy => policy.RequireClaim("SalaryAdd", "true"));
                    options.AddPolicy("SalaryEdit",
                        policy => policy.RequireClaim("SalaryEdit", "true"));
                    options.AddPolicy("SalaryDelete",
                        policy => policy.RequireClaim("SalaryDelete", "true"));

                    options.AddPolicy("EmployeeShow",
                        policy => policy.RequireClaim("EmployeeShow", "true"));
                    options.AddPolicy("EmployeeAdd",
                        policy => policy.RequireClaim("EmployeeAdd", "true"));
                    options.AddPolicy("EmployeeEdit",
                        policy => policy.RequireClaim("EmployeeEdit", "true"));
                    options.AddPolicy("EmployeeDelete",
                        policy => policy.RequireClaim("EmployeeDelete", "true"));

                    options.AddPolicy("AttendanceShow",
                      policy => policy.RequireClaim("AttendanceShow", "true"));
                    options.AddPolicy("AttendanceAdd",
                        policy => policy.RequireClaim("AttendanceAdd", "true"));
                    options.AddPolicy("AttendanceEdit",
                        policy => policy.RequireClaim("AttendanceEdit", "true"));
                    options.AddPolicy("AttendanceDelete",
                        policy => policy.RequireClaim("AttendanceDelete", "true"));



                });

            services.AddSingleton<IAuthorizationHandler, CanEditOnlyOtherRoleAndClaims>();
            //services.AddMvc()
            //    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix,
            //        opts => { opts.ResourcesPath = "Resources"; })
            //    .AddDataAnnotationsLocalization(options =>
            //    {
            //        options.DataAnnotationLocalizerProvider = (type, factory) =>
            //            factory.Create(typeof(Minimum20YearsAttribute)); // SharedResource is the class where the DataAnnotations (translations) will be stored.
            //    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
