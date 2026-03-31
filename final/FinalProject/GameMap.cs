using System;

public class GameMap
{
    private GameTile[] _gameTiles = new GameTile[9];

    private Item _winningItem;

    public Item getWinningItem()
    {
        return _winningItem;
    }

    public GameTile[] GameTiles
    {
        set
        {
            _gameTiles = value;
        }
    }

    public void GameMap()
    {
        Item axe = new Item(
            "Rusty Axe", 
            "The axe that has taken you through the Forgotten Realms "
        );
        Item.AXE = axe;
        

        Item sword = new Item(
            "A brilliant look sword",
            "The sword once wielded by King Arthur, said to be able to destroy the Goblin King"
        );
        Item.KING_ARTHUR_SWORD = sword;
        this._winningItem = sword;

        Item cloak = new Item(
            "A rageddy old cloak",
            "Despite its age, it should get you through the mountains"
        );

        Item rawMeat = new Item(
            "a great chunk of elk meat",
            "It's a little raw and not your favourite type of meat, maybe something else would enjoy it"
        );

        Item bundleOfWood = new Item(
            "A great bundle of wood",
            "Too much wood for yourself, you should share it with others"
        );

        Item bucket = new Item(
            "An empty bucket",
            "Try to fill it up with water"
        );

        Item water = new Item(
            "clean looking water",
            "Hm could this go in the bucket?"
        );

        Item blessing = new Item(
            "King Arthur's blessing!",
            "This is the power that allows King Arthur to wield his sword"
        );

        Obstacle manInCabin = new Obstacle(
            "Man in Cabin",
            "This man will only speak to royalty",
            blessing
        );

        Obstacle grizzlyBear = new Obstacle(
            "hungry looking Grizzly bear",
            "He is blocking the rest of the cave",
            rawMeat
        );

        Obstacle manInDesert = new Obstacle(
            "Thirsty looking man",
            "This man clearly needs water",
            water
        );

        Obstacle goblinKing = new Obstacle(
            "The largest goblin you've ever seen",
            "He roars as you approach",
            sword
        );

    }

}

