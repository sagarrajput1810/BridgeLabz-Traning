using System;
using System.Collections.Generic;

namespace StackAndQueueProblems
{
    /// <summary>
    /// Problem: Given a set of petrol pumps with petrol and distance to the next pump, 
    /// determine the starting point for completing a circular tour.
    /// 
    /// Approach: Use a queue to simulate the tour, keeping track of surplus petrol at each pump.
    /// 
    /// Time Complexity: O(n)
    /// Space Complexity: O(1)
    /// </summary>
    public class CircularTourProblem
    {
        public class PetrolPump
        {
            public int Petrol { get; set; }
            public int Distance { get; set; }

            public PetrolPump(int petrol, int distance)
            {
                Petrol = petrol;
                Distance = distance;
            }
        }

        /// <summary>
        /// Find the starting pump index for completing circular tour
        /// Returns -1 if no solution exists
        /// </summary>
        public static int FindStartingPoint(PetrolPump[] pumps)
        {
            if (pumps == null || pumps.Length == 0)
                return -1;

            int n = pumps.Length;
            int startIndex = 0;
            int petrolInTank = 0;
            int totalPetrol = 0;
            int totalDistance = 0;

            for (int i = 0; i < n; i++)
            {
                petrolInTank += pumps[i].Petrol - pumps[i].Distance;
                totalPetrol += pumps[i].Petrol;
                totalDistance += pumps[i].Distance;

                // If petrol becomes negative, we can't reach next pump from current starting point
                if (petrolInTank < 0)
                {
                    startIndex = i + 1; // Try next pump as starting point
                    petrolInTank = 0;
                }
            }

            // Check if total petrol >= total distance required
            return (totalPetrol >= totalDistance) ? startIndex : -1;
        }

        /// <summary>
        /// Brute force approach - Try each pump as starting point - O(n^2)
        /// </summary>
        public static int FindStartingPointBruteForce(PetrolPump[] pumps)
        {
            if (pumps == null || pumps.Length == 0)
                return -1;

            int n = pumps.Length;

            for (int start = 0; start < n; start++)
            {
                int petrol = 0;
                bool canComplete = true;

                for (int i = 0; i < n; i++)
                {
                    int idx = (start + i) % n;
                    petrol += pumps[idx].Petrol - pumps[idx].Distance;

                    if (petrol < 0)
                    {
                        canComplete = false;
                        break;
                    }
                }

                if (canComplete)
                    return start;
            }

            return -1;
        }

        /// <summary>
        /// Simulate the tour from given starting point
        /// </summary>
        public static bool CanCompleteTour(PetrolPump[] pumps, int startIndex)
        {
            if (pumps == null || pumps.Length == 0 || startIndex < 0 || startIndex >= pumps.Length)
                return false;

            int n = pumps.Length;
            int petrol = 0;

            for (int i = 0; i < n; i++)
            {
                int idx = (startIndex + i) % n;
                petrol += pumps[idx].Petrol - pumps[idx].Distance;

                if (petrol < 0)
                    return false;
            }

            return true;
        }

        public static void PrintPumps(PetrolPump[] pumps)
        {
            Console.WriteLine("Pump#\tPetrol\tDistance");
            for (int i = 0; i < pumps.Length; i++)
            {
                Console.WriteLine($"{i}\t{pumps[i].Petrol}\t{pumps[i].Distance}");
            }
        }

        public static void Main()
        {
            Console.WriteLine("=== Circular Tour Problem ===\n");

            // Test case 1: Valid solution exists
            Console.WriteLine("Test Case 1:");
            PetrolPump[] pumps1 = {
                new PetrolPump(4, 6),
                new PetrolPump(6, 5),
                new PetrolPump(7, 3),
                new PetrolPump(4, 5)
            };

            PrintPumps(pumps1);
            int start1 = FindStartingPoint(pumps1);
            Console.WriteLine($"Starting pump: {start1}");
            if (start1 != -1)
            {
                Console.WriteLine($"Can complete tour: {CanCompleteTour(pumps1, start1)}");
            }

            // Test case 2: Another valid case
            Console.WriteLine("\n--- Test Case 2 ---");
            PetrolPump[] pumps2 = {
                new PetrolPump(1, 5),
                new PetrolPump(2, 5),
                new PetrolPump(5, 1),
                new PetrolPump(6, 4),
                new PetrolPump(4, 6)
            };

            PrintPumps(pumps2);
            int start2 = FindStartingPoint(pumps2);
            Console.WriteLine($"Starting pump: {start2}");
            if (start2 != -1)
            {
                Console.WriteLine($"Can complete tour: {CanCompleteTour(pumps2, start2)}");
            }

            // Test case 3: No valid solution
            Console.WriteLine("\n--- Test Case 3: No Solution ---");
            PetrolPump[] pumps3 = {
                new PetrolPump(1, 2),
                new PetrolPump(2, 3),
                new PetrolPump(3, 4)
            };

            PrintPumps(pumps3);
            int start3 = FindStartingPoint(pumps3);
            Console.WriteLine($"Starting pump: {start3}");

            // Verify both approaches
            Console.WriteLine("\n--- Verification (Optimized vs Brute Force) ---");
            PetrolPump[] pumps4 = {
                new PetrolPump(3, 4),
                new PetrolPump(2, 3),
                new PetrolPump(4, 2)
            };

            int optimized = FindStartingPoint(pumps4);
            int bruteForce = FindStartingPointBruteForce(pumps4);

            Console.WriteLine($"Optimized Result: {optimized}");
            Console.WriteLine($"Brute Force Result: {bruteForce}");
            Console.WriteLine($"Results Match: {optimized == bruteForce}");
        }
    }
}
