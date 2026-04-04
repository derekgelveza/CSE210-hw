using System;

public class Game
{
    private enum GameState { Playing, Won }

    private Player _player;
    private List<Action> _normalActions;
    private List<Action> _travelActions;
    private static Game _instance = new Game();
    private static readonly object _lock = new object();

    private Game()
    {
        InitGame();
    }

    public void Start()
    {
        PlayGame();
    }

    public static Game GetInstance()
    {
        lock (_lock)
        {
            if (_instance == null)
            {
                _instance = new Game();
            }
            return _instance;
        }
    }

    private void InitGame()
    {
        GameMap gameMap = new GameMap();
        _player = new Player();
        _player.Init(gameMap);

        _normalActions = new List<Action>
        {
            new GetItemAction(),
            new UseAction(),
            new InvenotryAction(),
            new ShowMapAction(),
            new QuitAction(),
            new InvalidAction()
        };

        _travelActions = new List<Action>
        {
            new TravelNorthAction(),
            new TravelSouthAction(),
            new TravelEastAction(),
            new TravelWestAction()
        };
    }

    private void PlayGame()
    {
        Console.Clear();
        WelcomeMessage();

        GameState state = GameState.Playing;

        while (state == GameState.Playing)
        {
            state = CheckGameState();
            if (state == GameState.Won) break;
            DisplayValidActions();
            MoveAndAct();
        }

        EndMessage();
    }

    private GameState CheckGameState()
    {
        GameTile current = _player.Location;

        if (current.ObstacleType != null)
        {
            Console.WriteLine($"You see {current.ObstacleType.Name}{current.ObstacleType.Description}");
        }
        else if (current.HasItem())
        {
            Console.WriteLine($"You spot an item: {current.Item}");
        }

        if (current.Terrain == TerrainType.GOBLINCAMP &&
            current.ObstacleType == null)
        {
            return GameState.Won;
        }

        return GameState.Playing;
    }

    private void DisplayValidActions()
    {
        Console.WriteLine("\nAvailable actions:");

        foreach (Action action in _travelActions)
        {
            if (action.CanDoAction(_player))
            {
                Console.WriteLine($"  {action.GetActionDescription()} ({action.GetKey().ToUpper()})");
            }
        }

        foreach (Action action in _normalActions)
        {
            if (action.CanDoAction(_player) && action is not InvalidAction)
            {
                Console.WriteLine($"  {action.GetActionDescription()} ({action.GetKey().ToUpper()})");
            }
        }
    }

    private void MoveAndAct()
    {
        Console.Write("\nWhat will you do? ");
        string input = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(input)) return;

        foreach (Action action in _travelActions)
        {
            if (action.ValidKey(input))
            {
                if (action.CanDoAction(_player))
                    action.DoAction(_player);
                else
                    Console.WriteLine("You can't go that way.");
                return;
            }
        }

        foreach (Action action in _normalActions)
        {
            if (action.ValidKey(input))
            {
                if (action.CanDoAction(_player))
                    action.DoAction(_player);
                else
                    Console.WriteLine("You can't do that here.");
                return;
            }
        }
    }

    private static void WelcomeMessage()
    {
        Console.WriteLine("Welcome adventurer! You have travlled long and far across the Forgotten Realms. You are in pursuit of defeating the Goblin King!");
    }

    private static void EndMessage()
    {
        Console.WriteLine("You have finished this chapter of your journey. Congrats!");
    }
}
