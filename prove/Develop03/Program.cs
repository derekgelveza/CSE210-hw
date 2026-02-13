using System;

class Program
{
    static void Main(string[] args)
    {
       
        List<Scripture> listOfScriptures = new List<Scripture>();

        listOfScriptures.Add(new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the LORD with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."));

        listOfScriptures.Add(new Scripture(new Reference("2 Nephi", 2, 27), "Wherefore, men are free according to the flesh; and all things are given them which are expedient unto man. And they are free to choose liberty and eternal life, through the great Mediator of all men, or to choose captivity and death, according to the captivity and power of the devil; for he seeketh that all men might be miserable like unto himself."));

        listOfScriptures.Add(new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."));

        Random random = new Random();
        Scripture scripture = listOfScriptures[random.Next(listOfScriptures.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.AllWordsHidden())
            {
                break;
            }

            Console.WriteLine("\nPress Enter to continue or type 'quit' to finish");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }


            scripture.HideRandomWords(3);

        }




    }
}