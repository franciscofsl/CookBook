using CookBook.Blazor.Client.Clients.Recipes;
using CookBook.Shared.Recipes;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;

namespace CookBook.Blazor.Client.Shared;

public partial class RecipeLayout
{
    [Inject]
    protected IJSRuntime JSRuntime { get; set; }

    [Inject]
    protected NavigationManager NavigationManager { get; set; }

    [Inject]
    protected DialogService DialogService { get; set; }

    [Inject]
    protected TooltipService TooltipService { get; set; }

    [Inject]
    protected ContextMenuService ContextMenuService { get; set; }

    [Inject]
    protected NotificationService NotificationService { get; set; }
    
    [Inject]
    private RecipesClient RecipesClient { get; set; }
    
    public static RecipeDto CurrentRecipe { get; set; }
 
}