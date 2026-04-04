public class UseAction : AbstractAction
{
    public UseAction() : base("u", "Use Item") { }

    public override bool CanDoAction(Player player)
    {
        return player.Inventory.Count > 0;
    }

    public override void DoAction(Player player)
    {
        var inventory = player.Inventory;
        for (int i = 0; i < inventory.Count; i++)
        {
            Console.WriteLine(i + 1 + ". " + inventory[i]);
        }

        Console.Write("Which item will you use? ");
        string itemChoice = Console.ReadLine();

        if (!int.TryParse(itemChoice, out int numberChoice))
        {
            Console.WriteLine("That is not a valid option.");
            return;
        }

        if (numberChoice <= 0 || numberChoice > inventory.Count)
        {
            Console.WriteLine("That is not a valid option.");
            return;
        }

        Item selectedItem = inventory[numberChoice - 1];
        Obstacle obstacle = player.Location.ObstacleType;

        if (obstacle == null)
        {
            Console.WriteLine("There is nothing here to use that on.");
            return;
        }

        if (selectedItem.Name == obstacle.Required.Name)
        {
            Console.WriteLine($"You use the {selectedItem.Name}.");
            Console.WriteLine($"You have overcome the {obstacle.Name}!");
            player.Location.ObstacleType = null;

            bool isReusable = selectedItem == Item.AXE || selectedItem == Item.CLOAK;
            if (!isReusable)
            {
                player.Inventory.Remove(selectedItem);
            }
        }
        else
        {
            Console.WriteLine($"Using the {selectedItem.Name} has no effect.");
        }
    }
}
