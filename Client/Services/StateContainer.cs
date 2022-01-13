using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Commerce.Client.Services
{
    public class StateContainer
    {
        private readonly IJSRuntime _jsRuntime;

        public StateContainer(IJSRuntime jSRuntime)
        {
            _jsRuntime = jSRuntime;
        }

        private string savedString;

        private Company company;
        private List<Company> companies;

        public string Property
        {
            get => savedString ?? string.Empty;
            set
            {
                savedString = value;
                NotifyStateChanged();
            }
        }

        public Company Company
        {
            get => company ?? null;
            set
            {
                company = value;
                NotifyStateChanged();
                SetCompanyAsync(value.Slug);
            }
        }

        public List<Company> Companies
        {
            get => companies ?? null;
            set
            {
                companies = value;
                NotifyStateChanged();
            }
        }

        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

        private async void SetCompanyAsync(string slug)
        {
            await _jsRuntime.InvokeVoidAsync($"sessionStorage.setItem", new object[] { "company", slug }); 
        }
    }
}
