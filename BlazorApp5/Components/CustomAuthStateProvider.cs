using BlazorApp5.Classes;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Text.Json;
using System.Security.Claims;
using BootstrapBlazor.Components;

namespace BlazorApp5.Components
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private const string AutenticationType = "CustomAuth";
        private const string UserStorageKey = "user";
        private readonly BrowserStorageService _browserStorageService;
        private AuthenticationState EmptyAuthState => new(new ClaimsPrincipal());

        public Usuario currentUser { get; set; } = new();

        public CustomAuthStateProvider(BrowserStorageService brouserStorageService)
        {
            _browserStorageService = brouserStorageService;
            AuthenticationStateChanged += CustomAuthStateProvider_AuthenticationStateChanged;
        }

        private async void CustomAuthStateProvider_AuthenticationStateChanged(Task<AuthenticationState> task)
        {
            var authState = await task;
            if (authState is not null )
            {
                var idStr = authState.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (!string.IsNullOrWhiteSpace(idStr) && Guid.TryParse(idStr, out Guid id))
                {
                    currentUser = new Usuario
                    {
                        Id = id,
                        NomeCompleto = authState.User.FindFirst(ClaimTypes.Name)?.Value,
                        Senha = authState.User.FindFirst("Token")?.Value
                    };
                    return;
                }
            }
            currentUser = new();
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = await _browserStorageService.GetFromStorage<Usuario?>(UserStorageKey);

            if (user is null)
            {
                //usuario nao esta autenticado session/local storage
                //usuario nao esta logado
                currentUser = new();
                return new AuthenticationState(new ClaimsPrincipal());
            }
            else
            {
                //usuario esta logado
                currentUser = user;

                var authState = GenerateAuthState(user);
                return authState;
            }
            //return Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));
        }

        public async Task LoginAsync(string username, string password)
        {
            var user = new Usuario { 
                Id = Guid.NewGuid(),
                NomeCompleto="edivaldo",
                Senha="123"
            };

            await _browserStorageService.SaveToStorage(UserStorageKey, user);

            var authState = GenerateAuthState(user);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }

        public async Task LogoutAsync()
        { 
            await _browserStorageService.RemoveFromStarage(UserStorageKey);
            NotifyAuthenticationStateChanged(Task.FromResult(EmptyAuthState));
        }

        private static AuthenticationState GenerateAuthState(Usuario user)
        {
            Claim[] claims = [
      new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.NomeCompleto.Trim().ToString()),
                    new Claim("Token", user.Senha.ToString()),
                    ];

            var identity = new ClaimsIdentity(claims, AutenticationType);
            var claimsPrincipal = new ClaimsPrincipal(identity);
            var authState = new AuthenticationState(new ClaimsPrincipal());
            return authState;
        }



    }
}
