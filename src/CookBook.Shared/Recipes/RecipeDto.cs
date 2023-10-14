namespace CookBook.Shared.Recipes;

public class RecipeDto
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public int? TotalHours { get; set; }
    
    public int? TotalMinutes { get; set; }
}