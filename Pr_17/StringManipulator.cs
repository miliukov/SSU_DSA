using System;
using System.Text;

namespace Pr_17
{
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

        public void ConvertToLowerCase()
        {
            line = new StringBuilder(line.ToString().ToLower());
        }

        public void RemovePunctuation()
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsPunctuation(line[i]))
                {
                    line = line.Remove(i, 1);
                    i--;
                }
            }
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
            sm.ConvertToLowerCase();
            return sm;
        }

        public static StringManipulator operator -(StringManipulator sm)
        {
            sm.line = new StringBuilder(sm.line.ToString().ToUpper());
            return sm;
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
            return string.Equals(sm1.Line, sm2.Line, StringComparison.OrdinalIgnoreCase);
        }

        public static explicit operator StringBuilder(StringManipulator sm)
        {
            return sm.line;
        }

        public static explicit operator StringManipulator(StringBuilder sb)
        {
            return new StringManipulator(sb.ToString());
        }
    }
}