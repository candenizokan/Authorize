using Identity.Context;
using Identity.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity
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
            services.AddControllersWithViews();


            services.AddDbContext<ApplicationDbContext>
                (
                options => options.UseSqlServer(Configuration.GetConnectionString("Default"))
                );

            services.AddIdentity<AppUser, IdentityRole>
                (
                    x =>
                    {
                        //burada giriş işlemkerş/kullanıcı detayları/şifrelere aidt detaylı isteklerimizi belirtebiliyoruz. Eğer yazmazsak defaulttaki ayarları kabul edecektir.

                        x.SignIn.RequireConfirmedPhoneNumber = false;// girişte doğrulanmış telefon gerekli mi
                        x.SignIn.RequireConfirmedEmail = false;// girişte doğrulanmış mail gerekli mi
                        x.User.RequireUniqueEmail = true;//eşsiz mail olsun mu kişiye ait
                        x.Password.RequiredLength = 4;//şifre kaç karakter olsun
                        x.Password.RequireLowercase = false;//şifrede küçük harf zorunlu mu
                        x.Password.RequireUppercase = false;//şifrede büyük harf zorunlu mu
                        x.Password.RequireNonAlphanumeric = false;//şifrede noktalama işareti zorunlu mu
                        x.Password.RequireDigit = false;//şifrede rakam zorunlu mu
                        x.Password.RequiredUniqueChars = 0;//eşsiz karakter gerekli mi

                        // gibi gibni daha birçok ayarlama yapılabilir. biz değer atamazsak o defaulttaki değerleri kabul eder. Yer yer bu sebepten hatalar alınabilir. dikkatten kaçan yerler olursa.
                    }
                ).AddEntityFrameworkStores<ApplicationDbContext>()//sayesinde aslında AppUser arkaplanda tutuluyor. Tablosuz ulaşılmış oluyor.
                .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
