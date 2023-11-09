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
            string inputFile = "D:\\.program\\C#\\SSU_DSA\\Pr_9_II\\MyFile.txt";
            string outputFile = "D:\\.program\\C#\\SSU_DSA\\Pr_9_II\\MyNewFile.txt";

            using (StreamReader fileIn = new StreamReader(inputFile, Encoding.GetEncoding(1251)))
            {
                using (StreamWriter fileOut = new StreamWriter(outputFile, false))
                {
                    char[] buffer = new char[2];
                    int bytesRead;

                    while ((bytesRead = fileIn.Read(buffer, 0, 2)) > 0)
                    {
                        if (bytesRead == 1)
                        {
                            fileOut.Write(buffer[0]);
                        }
                        else
                        {
                            fileOut.Write(buffer[1]);
                            fileOut.Write(buffer[0]);
                        }
                    }
                }
            }
        }
    }
}
