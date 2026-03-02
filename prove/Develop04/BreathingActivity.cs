using System;
using System.Diagnostics;

class BreathingActivity : Activity
{
    public BreathingActivity() :base("Breathing Activity", "Welcome to the Breathing Activity.", "This activity will help you relax by walking you through brething in and out slowly. Clear your mind and focus on your breathing.")
    {
        
    }

    public void Run()
    {
        StartActivity();
        DateTime endTime = DateTime.Now.AddSeconds(_seconds);
        while (DateTime.Now < endTime)
        {
            PauseWithCountdownNumbersInline(5, "Breathe in... ");
            PauseWithCountdownNumbersInline(5, "Breathe out... ");
            Console.WriteLine("\n");
        }
        EndActivity();
    }

}