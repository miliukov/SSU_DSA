using System;
using System.Text;

class StringManipulator
{
    private StringBuilder line;
    public StringManipulator(string input)
    {
        line = new StringBuilder(input);
    }
    public StringManipulator()
    {
        line = new StringBuilder();
    }
    public int CountSpaces()
    {
        int count = 0;
        foreach (char c in line.ToString())
        {
            if (c == ' ')
            {
                count++;
            }
        }
        return count;
    }
    public StringManipulator ConvertToLowerCase()
    {
        return new StringManipulator(line.ToString().ToLower());
    }
    public StringManipulator RemovePunctuation()
    {
        StringBuilder result = new StringBuilder();
        foreach (char c in line.ToString())
        {
            if (!char.IsPunctuation(c))
            {
                result.Append(c);
            }
        }
        return new StringManipulator(result.ToString());
    }
    public int Length
    {
        get { return line.Length; }
    }
    public string Line
    {
        get { return line.ToString(); }
        set { line = new StringBuilder(value); }
    }
    public char this[int index]
    {
        get { return line[index]; }
    }
    public static StringManipulator operator +(StringManipulator sm)
    {
        return new StringManipulator(sm.line.ToString().ToUpper());
    }
    public static StringManipulator operator -(StringManipulator sm)
    {
        return new StringManipulator(sm.line.ToString().ToLower());
    }
    public static bool operator true(StringManipulator sm)
    {
        return sm.line.Length > 0;
    }
    public static bool operator false(StringManipulator sm)
    {
        return sm.line.Length == 0;
    }
    public static bool operator &(StringManipulator sm1, StringManipulator sm2)
    {
        return string.Equals(sm1.line.ToString(), sm2.line.ToString(), StringComparison.OrdinalIgnoreCase);
    }
    public static explicit operator StringBuilder(StringManipulator sm)
    {
        return new StringBuilder(sm.line.ToString());
    }
    public static implicit operator StringManipulator(StringBuilder sb)
    {
        return new StringManipulator(sb.ToString());
    }
}