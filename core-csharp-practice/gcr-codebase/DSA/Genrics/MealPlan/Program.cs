using MealPlan.Models;

class Program
{
    static void Main()
    {
        var vegPlan = MealGenerator.GeneratePlan<VegetarianMeal>();
        var meal = new Meal<VegetarianMeal>(vegPlan);
        Console.WriteLine($"Plan: {meal.Plan.Description}, Valid: {meal.Validate()}");
    }
}
