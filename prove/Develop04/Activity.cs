using System;

class Activity
{
    private String _welcomeMessage;
    private String _description;
    private String _activityName;
    protected int _seconds;

    public Activity(String ActivityName, String WelcomeMessage, String Description)
    {
        _activityName = ActivityName;
        _welcomeMessage = WelcomeMessage;
        _description = Description;
    }

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine(_welcomeMessage);
        Console.WriteLine("\n");
        Console.WriteLine(_description);
        Console.WriteLine("\n");
        SetDuration();

        Console.Clear();
        Console.WriteLine("Get ready... ");
        PauseWithCountdown(3);

    }

    public void SetDuration()
    {
        Console.Write("How long in seconds, would you like your session? ");
        _seconds = int.Parse(Console.ReadLine());
    }

    protected void PauseWithCountdown(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" }; 
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(250); 
            Console.Write("\b"); 
            i++;
        }
        Console.WriteLine();
    }

 protected void PauseWithCountdownNumbersInline(int seconds, string message)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{message}{i}  ");
            Thread.Sleep(1000);
        }
        Console.Write($"\r{message} ");
        Console.WriteLine();
    }

    public void EndActivity()
    {
        Console.WriteLine("Well done!");
        Console.WriteLine($"You have completed another {_seconds} seconds of the {_activityName}");

    }
}