using System;
class Quiz1
{
   private String[] questions={
            "What comes after 5?",
            "What color is the sky?",
            "How many legs does a dog have?",
            "Name a fruit.",
            "What do we use to write?",
            "Which animal gives us milk?",
            "What shape is a ball?",
            "What comes before 10?",
            "What do we drink when we are thirsty?",
            "Which body part do we use to see?"
        };
    private String [] answers= {
            "6",
            "Blue",
            "4",
            "Apple",
            "Pencil",
            "Cow",
            "Circle",
            "9",
            "Water",
            "Eye"
        };
    private int score=0;
    public void Game(){
        for(int i=0;i<questions.Length;i++)
        {
            Console.WriteLine(questions[i]);
            Console.WriteLine("Enter Answer");
            String ans=Console.ReadLine();
            if(ans.ToLower() ==answers[i].ToLower())
            {
                Console.WriteLine("Correct Answer");
                score++;
            }
            else
            {
                Console.WriteLine("Incorrect Answer");
            }
        }
    }
    public void Percentage()
    {
        Console.WriteLine("total percentage is " +(double) score/10*100);
        if((double)score/10*100>40)
        {
            Console.WriteLine("Pass");
        }
        else
        {
             Console.WriteLine("Fail");
        }
    }

    
}

class Start{
    static void Main(){
        Console.WriteLine("Quiz Start");
        Quiz1 q=new Quiz1();
        q.Game();
        q.Percentage();
    }
}