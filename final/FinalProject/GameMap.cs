using System;

public class GameMap
{
    private GameTile[] _gameTiles = new GameTile[9];

    private Item _winningItem;

    public Item GetWinningItem()
    {
        return _winningItem;
    }

    public GameTile[] GameTiles
    {
        get
        {
            return _gameTiles;
        }
        set
        {
            _gameTiles = value;
        }
    }


    public GameMap()
    {
        Item axe = new Item(
            "Rusty Axe", 
            "The axe that has taken you through the Forgotten Realms "
        );
        Item.Axe = axe;
        

        Item sword = new Item(
            "A brilliant look sword",
            "The sword once wielded by King Arthur, said to be able to destroy the Goblin King"
        );
        Item.KingArthurSword = sword;
        this._winningItem = sword;

        Item cloak = new Item(
            "A rageddy old cloak",
            "Despite its age, it should get you through the mountains"
        );
        Item.Cloak = cloak;

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
            "this should be useful"
        );

        Item blessing = new Item(
            "King Arthur's blessing! ",
            "This is the power that allows King Arthur to wield his sword"
        );

        Obstacle manInCabin = new Obstacle(
            "man in cabin ",
            "This man will only speak to royalty",
            blessing
        );

        Obstacle grizzlyBear = new Obstacle(
            "hungry looking Grizzly bear ",
            "He is blocking the rest of the cave",
            rawMeat
        );

        Obstacle manInDesert = new Obstacle(
            "thirsty man ",
            "This man clearly needs water",
            water
        );

        Obstacle goblinKing = new Obstacle(
            "the largest goblin you've ever seen ",
            "He roars as you approach",
            sword
        );

        Obstacle elf = new Obstacle(
            "an elf is prepping food ",
            "They tell you the meat ready for cooking, but there's no wood for fire",
            bundleOfWood
        );

        Obstacle blisteringWinds = new Obstacle(
            "a blistering wind ",
            "It is too cold for you to stay here long",
            cloak
        );

        Obstacle missingItem = new Obstacle(
            "running water ",
            "It looks drinkable",
            bucket
        );

        Obstacle trees = new Obstacle(
            "huge trees ",
            "Cutting some down would be useful",
            axe
        );

        GameTile tile0 = new GameTile(TerrainType.GoblinCamp, null, goblinKing);
        GameTile tile1 = new GameTile(TerrainType.Mountain, _winningItem, blisteringWinds);
        GameTile tile2 = new GameTile(TerrainType.Cabin, cloak, manInCabin);

        GameTile tile3 = new GameTile(TerrainType.Desert, blessing, manInDesert);
        GameTile tile4 = new GameTile(TerrainType.Grove, rawMeat, elf);
        GameTile tile5 = new GameTile(TerrainType.Cave, bucket, grizzlyBear);

        GameTile tile6 = new GameTile(TerrainType.Dock, water, missingItem);
        GameTile tile7 = new GameTile(TerrainType.Forest, bundleOfWood, trees);
        GameTile tile8 = new GameTile(TerrainType.Camp, axe, null);

        _gameTiles[0] = tile0;
        _gameTiles[1] = tile1;
        _gameTiles[2] = tile2;
        _gameTiles[3] = tile3;
        _gameTiles[4] = tile4;
        _gameTiles[5] = tile5;
        _gameTiles[6] = tile6;
        _gameTiles[7] = tile7;
        _gameTiles[8] = tile8;

        tile0.East = tile1;
        tile0.South = tile3;

        tile1.West = tile0;
        tile1.East = tile2;
        tile1.South = tile4;

        tile2.West = tile1;
        tile2.South = tile5;

        tile3.North = tile0;
        tile3.East = tile4;
        tile3.South = tile6;

        tile4.North = tile1;
        tile4.East = tile5;
        tile4.South = tile7;
        tile4.West = tile3; 

        tile5.North = tile2;
        tile5.South = tile8;
        tile5.West = tile4;

        tile6.North = tile3;
        tile6.East = tile7;

        tile7.North = tile4;
        tile7.East = tile8;
        tile7.West = tile6;

        tile8.North = tile5;
        tile8.West = tile7;

    }

    public void ShowMap(GameTile location) {
    Console.WriteLine();

    for (int row = 0; row < 3; row++) {
        for (int col = 0; col < 3; col++) {
            int tile = (row * 3) + col;
            if (_gameTiles[tile] == location){
                Console.Write("[" + _gameTiles[tile].ShowTile() + "]");
            } else {
                Console.Write(_gameTiles[tile].ShowTile());
            }

            if (col < 2){
                Console.Write("|");
            }
            }
        Console.WriteLine();
        }
    }

}

