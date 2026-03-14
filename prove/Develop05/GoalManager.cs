using System;
using System.Collections.Generic;
using System.IO;



public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 1;
    private int _goalsCompleted = 0;

    public void Start()
    {
        int choice = 0;

        while (choice != 6)
        {   
            Console.WriteLine(" ");
            Console.WriteLine($"You have {_score} points | Level {_level}");
            Console.WriteLine(" ");

            Console.WriteLine("1. Create Goals");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Events");
            Console.WriteLine("6. Quit");

            Console.Write("Select a choice from the menu: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
                CreateGoal();
            else if (choice == 2)
                ListGoals();
            else if (choice == 3)
                SaveGoals();
            else if (choice == 4)
                LoadGoals();
            else if (choice == 5)
                RecordEvent();
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("What type of goal would you like to create? ");

        int type = int.Parse(Console.ReadLine());

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string desc = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (type == 1)
        {
            _goals.Add(new SimpleGoal(name, desc, points));
        } 
        else if (type == 2)
        {
            _goals.Add(new EternalGoal(name, desc, points));
        }
        else if (type == 3)
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());


            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));

        }
    }

    private void ListGoals()
    {
        Console.WriteLine("\nThe Goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            string status = "[ ]";

            if (_goals[i].IsComplete())
            {
                status = "[X]";  
            }

            Console.Write($"{i + 1}. {status} {_goals[i].GetName()} ({_goals[i].GetDescription()})");   
                

            if (_goals[i] is ChecklistGoal checklist)
            {
                Console.Write($" -- Completed {checklist.GetAmountCompleted()}/{checklist.GetTarget()}");
            } 

            Console.WriteLine();

        }
    }

    private void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string file = Console.ReadLine();

        using (StreamWriter output = new StreamWriter(file))
        {
            output.WriteLine($"{_score}|{_level}|{_goalsCompleted}");

            foreach (Goal g in _goals)
            {
                if (g is SimpleGoal)
                {
                    output.WriteLine($"SimpleGoal|{g.GetName()}|{g.GetDescription()}|{g.GetPoints()}|{g.IsComplete()}");
                }
                else if (g is EternalGoal)
                {
                    output.WriteLine($"EternalGoal|{g.GetName()}|{g.GetDescription()}|{g.GetPoints()}");
                }
                else if (g is ChecklistGoal checklist)
                {
                    output.WriteLine($"ChecklistGoal|{g.GetName()}|{g.GetDescription()}|{g.GetPoints()}|{checklist.GetTarget()}|{checklist.GetBonus()}|{checklist.GetAmountCompleted()}");
                }
            }
        }

        Console.WriteLine("Goals saved.");
    }


    private void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string file = Console.ReadLine();

        if (File.Exists(file))
        {
            string[] lines = File.ReadAllLines(file);

            string[] stats = lines[0].Split('|');

            _score = int.Parse(stats[0]);
            _level = int.Parse(stats[1]);
            _goalsCompleted = int.Parse(stats[2]);

            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');

                string type = parts[0];

                if (type == "SimpleGoal")
                {
                    string name = parts[1];
                    string desc = parts[2];
                    int points = int.Parse(parts[3]);
                    bool complete = bool.Parse(parts[4]);

                    SimpleGoal goal = new SimpleGoal(name, desc, points);

                    if (complete)
                    {
                        goal.RecordEvent();
                    }

                    _goals.Add(goal);
                }

                else if (type == "EternalGoal")
                {
                    string name = parts[1];
                    string desc = parts[2];
                    int points = int.Parse(parts[3]);

                    _goals.Add(new EternalGoal(name, desc, points));
                }

                else if (type == "ChecklistGoal")
                {
                    string name = parts[1];
                    string desc = parts[2];
                    int points = int.Parse(parts[3]);
                    int target = int.Parse(parts[4]);
                    int bonus = int.Parse(parts[5]);
                    int completed = int.Parse(parts[6]);

                    ChecklistGoal goal = new ChecklistGoal(name, desc, points, target, bonus);

                    goal.SetAmountCompleted(completed);

                    _goals.Add(goal);
                }
            }

            Console.WriteLine("Goals loaded.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }


    private void RecordEvent()
    {
        Console.WriteLine("\nWhich goal did you accomplish?");

        ListGoals();

        Console.Write("Enter goal number: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        int pointsEarned = _goals[index].RecordEvent();

        _score += pointsEarned;

        if (pointsEarned > 0)
        {
            _goalsCompleted++;
            CheckGoalBonus();
        }

        CheckLevelUp();

        Console.WriteLine($"You earned {pointsEarned} points!");
    }

    private void CheckLevelUp()
    {
        int newLevel = (_score / 1000) + 1;

        if (newLevel > _level)
        {
            _level = newLevel;
            Console.WriteLine($"Congratulations! You leveled up to Level {_level}!");
        }
    }

    private void CheckGoalBonus()
    {
        if (_goalsCompleted % 5 == 0)
        {
            _score += 500;
            Console.WriteLine("Bonus! You completed 5 goals and earned 500 extra points!");
        }
    }



}