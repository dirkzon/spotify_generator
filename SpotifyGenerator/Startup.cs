using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text;

using SpotifyGenerator.ApiWrapper;
using SpotifyGenerator.ApiWrapper.apiaccess;
using SpotifyGenerator.Domain.interfaces;
using SpotifyGenerator.Logic.services;
using SpotifyGenerator.Persistence;
using SpotifyGenerator.Persistence.repositories;
using Microsoft.AspNetCore.Http;
using SpotifyGenerator.Domain.interfaces.db;

namespace SpotifyGenerator
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
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.Cookie.SameSite = SameSiteMode.None;
            });

            //SQL dependency injection
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddScoped<ISqlUserRepository, SqlUserRepository>();
            services.AddScoped<ISqlPlaylistRepository, SqlPlaylistRepository>();
            services.AddScoped<ISqlQuestionRepository, SqlQuestionRepository>();

            services.AddScoped<IQuestionService, QuestionService>();

            //Api dependency injection
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddSingleton<IArtistService, ArtistService>();
            services.AddSingleton<IArtistRepository, ArtistRepository>();
            services.AddSingleton<IPlaylistService, PlaylistService>();
            services.AddSingleton<IPlaylistRepository, PlaylistRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ITokenAccess, TokenRepository>();
            services.AddSingleton<IQuestionService, QuestionService>();

            services.AddHttpClient("SpotifyAuthorization", client =>
                {
                    client.BaseAddress = new Uri("https://accounts.spotify.com");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                    var basic = Convert.ToBase64String(Encoding.ASCII.GetBytes(Configuration["Authorization:ClientId"] + ":" + Configuration["Authorization:ClientSecret"]));
                    client.DefaultRequestHeaders.Add("Authorization", "Basic " + basic);
                }
            );

            services.AddHttpClient("Spotify", client =>
                {                   
                    client.BaseAddress = new Uri("https://api.spotify.com");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                }
            );

            services.AddControllersWithViews();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
