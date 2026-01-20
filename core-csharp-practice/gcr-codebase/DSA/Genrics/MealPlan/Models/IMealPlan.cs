namespace MealPlan.Models;

public interface IMealPlan
{
    bool IsValid();
    string Description { get; }
}

public class VegetarianMeal : IMealPlan
{
    public string Description => "Vegetarian meal plan";
    public bool IsValid() => true; // simple rule for beginners
}

public class VeganMeal : IMealPlan
{
    public string Description => "Vegan meal plan";
    public bool IsValid() => true;
}
