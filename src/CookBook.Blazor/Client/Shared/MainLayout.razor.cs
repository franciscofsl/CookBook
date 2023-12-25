using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;

namespace CookBook.Blazor.Client.Shared
{
    public partial class MainLayout
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }
    }
}