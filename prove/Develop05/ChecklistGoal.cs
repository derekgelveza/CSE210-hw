using System;

public class ChecklistGoal : Goal
{
    
    private int _amountCompleted;
    private int _target;
    private int _bonus;


    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;

        if (_amountCompleted == _target)
        {
            _isComplete = true;
            return _points + _bonus;
        }

        return _points;
    }


    public int GetAmountCompleted()
    {
        return _amountCompleted;
    }


    public void SetAmountCompleted(int amount)
    {
        _amountCompleted = amount;

        if (_amountCompleted >= _target)
        {
            _isComplete = true;
        }
    }


    public int GetTarget()
    {
        return _target;
    }

        public int GetBonus()
    {
        return _bonus;
    }

}