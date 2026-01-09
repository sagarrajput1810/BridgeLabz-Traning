using System;
using System.Collections.Generic;

// Interface for trackable workouts
public interface ITrackable
{
    string GetWorkoutType();
    int GetCaloriesBurned();
    void DisplayDetails();
}

// UserProfile class to manage user information
public class UserProfile
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }
    public List<Workout> WorkoutHistory { get; private set; }

    public UserProfile(string name, int age, double weight, double height)
    {
        Name = name;
        Age = age;
        Weight = weight;
        Height = height;
        WorkoutHistory = new List<Workout>();
    }

    public void AddWorkout(Workout workout)
    {
        WorkoutHistory.Add(workout);
        Console.WriteLine($"Workout added for {Name}");
    }

    public void DisplayProfile()
    {
        Console.WriteLine($"\n--- User Profile ---");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Weight: {Weight} kg");
        Console.WriteLine($"Height: {Height} cm");
        Console.WriteLine($"Total Workouts: {WorkoutHistory.Count}");
    }

    public int GetTotalCaloriesBurned()
    {
        int total = 0;
        foreach (var workout in WorkoutHistory)
        {
            total += workout.CaloriesBurned;
        }
        return total;
    }
}

// Base Workout class
public abstract class Workout : ITrackable
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public int Duration { get; set; }
    public int CaloriesBurned { get; set; }

    public Workout(string name, int duration, int caloriesBurned)
    {
        Name = name;
        Duration = duration;
        CaloriesBurned = caloriesBurned;
        Date = DateTime.Now;
    }

    public abstract string GetWorkoutType();

    public int GetCaloriesBurned()
    {
        return CaloriesBurned;
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"\nWorkout: {Name}");
        Console.WriteLine($"Type: {GetWorkoutType()}");
        Console.WriteLine($"Duration: {Duration} minutes");
        Console.WriteLine($"Calories Burned: {CaloriesBurned}");
        Console.WriteLine($"Date: {Date:dd/MM/yyyy HH:mm}");
    }
}

// CardioWorkout class
public class CardioWorkout : Workout
{
    public string CardioType { get; set; }
    public double Distance { get; set; }
    public double AverageHeartRate { get; set; }

    public CardioWorkout(string name, int duration, int caloriesBurned, string cardioType, double distance, double averageHeartRate)
        : base(name, duration, caloriesBurned)
    {
        CardioType = cardioType;
        Distance = distance;
        AverageHeartRate = averageHeartRate;
    }

    public override string GetWorkoutType()
    {
        return "Cardio";
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Cardio Type: {CardioType}");
        Console.WriteLine($"Distance: {Distance} km");
        Console.WriteLine($"Average Heart Rate: {AverageHeartRate} bpm");
    }
}

// StrengthWorkout class
public class StrengthWorkout : Workout
{
    public string MuscleGroup { get; set; }
    public int Sets { get; set; }
    public int Reps { get; set; }
    public double Weight { get; set; }

    public StrengthWorkout(string name, int duration, int caloriesBurned, string muscleGroup, int sets, int reps, double weight)
        : base(name, duration, caloriesBurned)
    {
        MuscleGroup = muscleGroup;
        Sets = sets;
        Reps = reps;
        Weight = weight;
    }

    public override string GetWorkoutType()
    {
        return "Strength";
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Muscle Group: {MuscleGroup}");
        Console.WriteLine($"Sets: {Sets}");
        Console.WriteLine($"Reps: {Reps}");
        Console.WriteLine($"Weight: {Weight} kg");
    }
}

// Main Program
public class Program
{
    public static void Main()
    {
        // Create a user profile
        UserProfile user = new UserProfile("John Doe", 28, 75, 180);
        user.DisplayProfile();

        // Add Cardio Workout
        CardioWorkout cardio = new CardioWorkout("Morning Run", 30, 300, "Running", 5.0, 140);
        user.AddWorkout(cardio);
        cardio.DisplayDetails();

        // Add Strength Workout
        StrengthWorkout strength = new StrengthWorkout("Chest Press", 45, 250, "Chest", 4, 10, 80);
        user.AddWorkout(strength);
        strength.DisplayDetails();

        // Add another Cardio Workout
        CardioWorkout cycling = new CardioWorkout("Evening Cycling", 40, 350, "Cycling", 15.0, 130);
        user.AddWorkout(cycling);
        cycling.DisplayDetails();

        // Add another Strength Workout
        StrengthWorkout legs = new StrengthWorkout("Leg Press", 50, 280, "Legs", 3, 12, 150);
        user.AddWorkout(legs);
        legs.DisplayDetails();

        // Display summary
        Console.WriteLine($"\n--- Fitness Summary ---");
        Console.WriteLine($"Total Calories Burned: {user.GetTotalCaloriesBurned()}");
        Console.WriteLine($"Total Workouts Completed: {user.WorkoutHistory.Count}");
    }
}