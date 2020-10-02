using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace P2.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("text.txt");
            string dest = Path.Combine("output.txt");

            using(FileStream file = new FileStream(path, FileMode.Open))
            {
                using(TextReader reader = new StreamReader(file))
                {
                    string line = reader.ReadLine();

                    int lineCounter = 1;

                    List<string> textToAdd = new List<string>();
                    while (line != null)
                    {
                        int digitCounter = 0;
                        int symbolCounter = 0;

                        foreach (char ch in line)
                        {
                            if (char.IsLetter(ch))
                            {
                                symbolCounter++;
                            }
                            else if (char.IsPunctuation(ch))
                            {
                                digitCounter++;
                            }
                        }

                        string newLine = $"Line{lineCounter}: {line} ({symbolCounter})({digitCounter})";
                        lineCounter++;

                        textToAdd.Add(newLine);

                        line = reader.ReadLine();
                    }

                    File.WriteAllLines(dest, textToAdd);
                }
            }
        }
    }
}
