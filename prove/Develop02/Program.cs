using System;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        bool exit = false;


        while (!exit)
        {
            Console.WriteLine("What would you like to do? Please input a number from 1-5.");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Edit");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Save to File");
            Console.WriteLine("6. Load from File");
            Console.WriteLine("7. Exit");

            string optionChosen = Console.ReadLine();
            int option = int.Parse(optionChosen);

            if (option == 1)
            {
                myJournal.WriteEntry();
                Console.WriteLine("");
        
            } else if (option == 2)
            {
                myJournal.DisplayEntries();
                Console.WriteLine("");

            } else if (option == 3) {

                myJournal.editEntry();
                Console.WriteLine("");
                
            } else if (option == 4)
            {
                myJournal.deleteEntry();
                Console.WriteLine("");

            } else if (option == 5)
            {
                myJournal.SavetoFile("journal");
                Console.WriteLine("");

            } else if (option == 6)
            {
                myJournal.LoadFromFile();
                Console.WriteLine("");

            } else if (option == 7)
            {
                exit = true;
                Console.WriteLine("Exiting Journal ...");
            } else
            {
                Console.WriteLine("Invalid option. Please choose from numbers 1 - 5.");
            }
        }
    }
}