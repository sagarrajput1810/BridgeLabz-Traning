namespace MealPlan;

using MealPlan.Models;

public class Meal<T> where T : IMealPlan
{
    public T Plan { get; set; }

    public Meal(T plan) => Plan = plan;

    public bool Validate() => Plan.IsValid();
}

public static class MealGenerator
{
    public static T GeneratePlan<T>() where T : IMealPlan, new()
    {
        return new T();
    }
}
