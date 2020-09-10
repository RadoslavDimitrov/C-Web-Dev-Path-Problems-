using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace _2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("data", "input.txt");
            string destPath = Path.Combine("data", "output.txt");

            using(FileStream file = new FileStream(path, FileMode.Open))
            {
                using(TextReader reader = new StreamReader(file))
                {
                    using(FileStream destFile = new FileStream(destPath, FileMode.Create))
                    {
                        using(TextWriter writer = new StreamWriter(destFile))
                        {
                            string line = reader.ReadLine();

                            List<string> lines = new List<string>();

                            while (line != null)
                            {
                                lines.Add(line);

                                line = reader.ReadLine();
                            }
                            int counter = 1;

                            foreach (var item in lines)
                            {
                                writer.WriteLine($"{counter}. {item}");
                                counter++;
                            }
                        }
                    }
                }
            }
        }
    }
}
