using System;

class MathAssignment : Assignment
{
    
    private string _textBookSection;
    private string _problems;

    public MathAssignment(string studentName, string topic, string section, string problems) : base(studentName, topic)
    {
        this._textBookSection = section;
        this._problems = problems;

    }


    public string GetHomeworkList()
    {
        return $"Section {_textBookSection} Problems {_problems}";
    }






}