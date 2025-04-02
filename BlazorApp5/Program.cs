using BlazorApp5.Components;
using BlazorApp5.Servicos;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddBlazorBootstrap();

            builder.Services.AddDbContext<AppDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlExpressConnectionString3")));
            //SqlExpressConnectionString3
            //SqlExpressConnectionStringDocker

            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            builder.Services.AddScoped<CustomAuthenticationStateProvider>(); // Para poder chamar login/logout



            builder.Services.AddScoped<INFService, NFService>();
            builder.Services.AddScoped<IFornecedorService, FornecedorService>();
            builder.Services.AddScoped<IClienteService, ClienteService>();
  

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //builder.Services.AddOidcAuthentication(options =>
            //{
            //    // Configure your authentication provider options here.
            //    // For more information, see https://aka.ms/blazor-standalone-auth
            //    builder.Configuration.Bind("Local", options.ProviderOptions);
            //});

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
