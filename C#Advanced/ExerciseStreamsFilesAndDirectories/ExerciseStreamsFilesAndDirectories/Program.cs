using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace P1.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("text.txt");

            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                using(TextReader reader = new StreamReader(file))
                {
                    string textLine = reader.ReadLine();

                    List<string> textToReturn = new List<string>();

                    int counter = 1;
                    while (textLine != null)
                    {
                        if(counter == 2)
                        {
                            counter = 1;
                            textLine = reader.ReadLine();
                            continue;
                        }
                        if(counter == 1)
                        {
                            textToReturn.Add(textLine);
                            counter++;
                        }

                        textLine = reader.ReadLine();
                    }

                    //replace all {"-", ",", ".", "!", "?"}  with '@'
                    for (int i = 0; i < textToReturn.Count; i++)
                    {
                        StringBuilder sb = new StringBuilder(textToReturn[i]);

                        sb.Replace('-', '@');
                        sb.Replace(',', '@');
                        sb.Replace('.', '@');
                        sb.Replace('!', '@');
                        sb.Replace('?', '@');

                        string[] reverseMe = sb.ToString().Split();

                        StringBuilder reversedSb = new StringBuilder();

                        for (int word = reverseMe.Length - 1; word > 0; word--)
                        {
                            reversedSb.Append(reverseMe[word] + " ");
                        }

                        reversedSb.Append(reverseMe[0]);

                        Console.WriteLine(reversedSb.ToString());
                    }
                }
            }
        }
    }
}
