using System;
using System.Collections.Generic;

class ReflectionActivity : Activity
{   
    private List<string> unusedPrompts;
    private List<string> prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private Random rand = new Random();

    public ReflectionActivity()
        : base("Reflection Activity",
               "Welcome to the Reflection Activity.",
               "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        unusedPrompts = new List<string>(prompts);
    }

    private void ShuffleList(List<string> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            string temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }

    public void Run()
    {
        if (unusedPrompts.Count == 0)
        {
            unusedPrompts = new List<string>(prompts);
        }

        StartActivity();
        Console.WriteLine("Consider the following prompt: ");
        Console.WriteLine("\n");
        int promptIndex = rand.Next(unusedPrompts.Count);
        string prompt = unusedPrompts[promptIndex];
        unusedPrompts.RemoveAt(promptIndex);
        Console.WriteLine(prompt);
        Console.WriteLine("\n");
        
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.Clear();

        List<string> shuffledQuestions = new List<string>(questions);
        ShuffleList(shuffledQuestions);

        DateTime endTime = DateTime.Now.AddSeconds(_seconds);
        int questionIndex = 0;
        while (DateTime.Now < endTime && questionIndex < shuffledQuestions.Count)
        {
            Console.WriteLine(shuffledQuestions[questionIndex]);
            PauseWithCountdown(5); 
            questionIndex++;
        }
        Console.WriteLine("\n");

        EndActivity();
    }
}