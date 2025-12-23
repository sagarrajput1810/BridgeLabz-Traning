using System;
class VotingEligibility
{
    static void Main(String[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] ages = new int[n];
        for(int i =0; i<n; i++)
        {
            ages[i] = int.Parse(Console.ReadLine());
        }
        for(int i=0; i<n; i++)
        {
            if(ages[i] >= 18)
            {
                Console.WriteLine("Age with "+ ages[i]+" Eligible for Voting");
            }
            else
            {
                Console.WriteLine("Age with "+ ages[i]+" Not Eligible for Voting");
            }
        }
    }
}