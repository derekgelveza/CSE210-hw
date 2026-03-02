using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Random rand = new Random();

    public ListingActivity()
        : base("Listing Activity",
               "Welcome to the Listing Activity.",
               "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public void Run()
    {
        StartActivity();
        Console.WriteLine("\n");

        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");

        PauseWithCountdownNumbersInline(5, "You may begin in: ");

        List<string> entries = new List<string>();

        DateTime endTime = DateTime.Now.AddSeconds(_seconds);

        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                string entry = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(entry))
                    entries.Add(entry);
            }
        }
        Console.WriteLine($"You listed {entries.Count} items!");
        Console.WriteLine("\n");
        
        EndActivity();
    }
}