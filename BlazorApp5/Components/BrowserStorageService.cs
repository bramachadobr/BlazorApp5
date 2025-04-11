using Microsoft.JSInterop;
using System.Text.Json;

namespace BlazorApp5.Components
{
    public class BrowserStorageService
    {
        /*
         * localStorage.setItem("key", value")
         * localStorage.getItem("key")
         * localStorage.removeItem("key")
         * localStorage.clean()
         * 
         * sessionStorage.setItem("key", value")
         * sessionStorage.getItem("key")
         * sessionStorage.removeItem("key")
         * sessionStorage.clean()
         * */


        private const string StorageType = "sessionStorage";
        private readonly IJSRuntime _jsRuntime;

        public BrowserStorageService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task SaveToStorage<TData>(string key, TData value)
        {
            var serializeData = Serialize(value);
            await _jsRuntime.InvokeVoidAsync($"localStorage.setItem", key, serializeData);
        }
        public async Task<TData?> GetFromStorage<TData>(string key)
        {
            var serializeData = await _jsRuntime.InvokeAsync<string?>("sessionStorage.getItem", key);
            return Deserialize<TData?>(serializeData);
        }

        public async Task RemoveFromStarage(string key)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }

        private static readonly JsonSerializerOptions jsonSerializerOptions =
            new JsonSerializerOptions();

        private static string Serialize<TData>(TData data)
        {
            return JsonSerializer.Serialize(data, jsonSerializerOptions);
        }

        private static TData? Deserialize<TData>(string? jsonData)
        {
            if (!string.IsNullOrWhiteSpace(jsonData))
            {
                return JsonSerializer.Deserialize<TData>(jsonData, jsonSerializerOptions);
            }
            return default;
        }
    }
}
