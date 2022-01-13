using Commerce.Client.Services;
using Commerce.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace Commerce.Client.Pages.PM
{
    public class SetupBase : ComponentBase
    {
        [Inject]
        public HttpClient _client { get; set; }

        [Inject]
        public IJSRuntime _jsRuntime { get; set; }

        [Inject]
        public StateContainer _stateContainer { get; set; }

        public bool IsLoading { get; set; }

        public List<Company> Companies { get; set; }
        public List<UnitOfMeasure> UnitOfMeasures { get; set; }



        public async Task<TItem> GetAsync<TItem>(string uri)
        {
            return await _client.GetFromJsonAsync<TItem>($"api/{uri}");
        }

        public async Task<TItem> CreateAsync<TItem>(TItem item , string uri)
        {
            IsLoading = true;
            var response = await _client.PostAsJsonAsync($"api/{uri}", item);
            IsLoading = false;
            TItem result;
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadFromJsonAsync<TItem>();
                return result;
            }
            else
            {
                return default(TItem);
            }
            
        }

        public async Task<TItem> UpdateAsync<TItem>(TItem item, string uri, int itemId)
        {
            IsLoading = true;
            var response = await _client.PutAsJsonAsync($"api/{uri}/{itemId}", item);
            IsLoading = false;

            if (response.IsSuccessStatusCode)
            {
                return item;
            }
            else
            {
                return default(TItem);
            }
            
        }

        public async Task<int> DeleteAsync<TItem>(string uri, int itemId)
        {
            IsLoading = true;
            var isConfirmed = await _jsRuntime.InvokeAsync<bool>("confirm", "Are you sure you want to delete?");
            IsLoading = false;
            if (isConfirmed)
            {
                var response = await _client.DeleteAsync($"api/{uri}/{itemId}");

                if (response.IsSuccessStatusCode)
                {
                    return itemId;
                }

            }
            return 0;
        }

    }
}
