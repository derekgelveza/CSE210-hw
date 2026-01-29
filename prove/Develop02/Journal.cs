using System;
using System.IO;

public class Journal
{
    List<JournalEntry> entries = new List<JournalEntry>();
    string[] prompts = new string[]
    {
        "What was the funniest thing that happend today? ",
        "What was the most spiritual experience you had today? " ,
        "What were you most excited about today? ",
        "What was the strongest emotion you had today? " ,
        "If I had done one thing I could do over today, what would it be? "
    };

    private Random random = new Random();

    public void WriteEntry()
    {
        int i = random.Next(prompts.Length);
        string randomPrompt = prompts[i];
        
        Console.WriteLine(randomPrompt);
        string response = Console.ReadLine();

        JournalEntry entry = new JournalEntry();
        entry._timestamp = DateTime.Now;
        entry._prompt = randomPrompt;
        entry._response = response;

        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No Entries Yet");
        } else
        {
            for (int i = 0; i < entries.Count ; i++)
            {
                JournalEntry entryIndex = entries[i];

                Console.WriteLine(entryIndex._timestamp);
                Console.WriteLine(entryIndex._prompt);
                Console.WriteLine(entryIndex._response);
                Console.WriteLine("------");
            }
        }
    }

    public void SavetoFile(string filename)
    {
        
        bool validInput = false; 

        do
        {
            Console.WriteLine($"Would you like to save it to: {filename}? Type [y] for yes and [n] for no.");
            string saveOption = Console.ReadLine().ToLower();

             if (saveOption == "y")
            {
                if (!File.Exists(filename))
                {
                    File.Create(filename).Close();
                }

                using (StreamWriter journal = new StreamWriter(filename))
                {
                    foreach (JournalEntry entry in entries)
                    {
                        journal.WriteLine(entry._timestamp);
                        journal.WriteLine(entry._prompt);
                        journal.WriteLine(entry._response);
                    }
                }

                Console.WriteLine($"Journal was saved to {filename}!");
                validInput = true;

            } else if (saveOption == "n")
            {
                Console.WriteLine("Where would you like to save the file?");
                string nameOfFile = Console.ReadLine(); 

                if (!File.Exists(nameOfFile))
                {
                    File.Create(nameOfFile).Close();
                }

                using (StreamWriter journal = new StreamWriter(nameOfFile))
                {
                    foreach (JournalEntry entry in entries)
                    {
                        journal.WriteLine(entry._timestamp);
                        journal.WriteLine(entry._prompt);
                        journal.WriteLine(entry._response);
                    }
                }

                Console.WriteLine($"Journal was saved to {nameOfFile}!");
                validInput = true;

            } else
            {
                Console.WriteLine("Not a valid answer");
            }

        } while (!validInput);

    }

    public void LoadFromFile()
    {
        Console.WriteLine("Which file would you like to load?");
        string fileOption = Console.ReadLine();

        if (!File.Exists(fileOption))
        {
            Console.WriteLine("That file does not exist");
        } else
        {
            using (StreamReader journal = new StreamReader(fileOption))
            {
                while (!journal.EndOfStream)
                {
                    string timeLine = journal.ReadLine();
                    DateTime timestamp = DateTime.Parse(timeLine);

                    string prompt = journal.ReadLine();
                    string response = journal.ReadLine();

                    JournalEntry entry = new JournalEntry();
                    entry._timestamp = timestamp;
                    entry._prompt = prompt;
                    entry._response = response;

                    entries.Add(entry);
                }
            }
        }

    }

    //https://www.geeksforgeeks.org/c-sharp/streamreader-and-streamwriter-in-c-sharp/
    //https://learn.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=net-10.0

}