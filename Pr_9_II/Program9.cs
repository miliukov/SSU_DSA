using System;
using System.IO;
using System.Text;
// Дан файл, компонентами которого являются символы. Создать новый файл таким образом, чтобы на четных местах
// у него стояли компоненты, стоящие на нечетных в первом файле, и наоборот.
namespace Pr_9_II
{
    class Program9
    {
        static void Main()
        {
            using (StreamReader fileIn = new StreamReader("D:\\.program\\C#\\SSU_DSA\\Pr_9_II\\MyFile.txt", Encoding.GetEncoding(1251)))
            {
                using (StreamWriter fileOut = new StreamWriter("D:\\.program\\C#\\SSU_DSA\\Pr_9_II\\MyNewFile.txt", false))
                {
                    string line;
                    while ((line = fileIn.ReadLine()) != null)
                    {
                        char[] characters = line.ToCharArray();
                        for (int i = 0; i < characters.Length - 1; i += 2)
                        {
                            char temp = characters[i];
                            characters[i] = characters[i + 1];
                            characters[i + 1] = temp;
                        }
                        fileOut.WriteLine(new string(characters));
                    }
                }
            }
        }
    }
}
