using System;
using System.IO;

namespace StreamsAndFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("data", "input.txt");
            string destPath = Path.Combine("data", "output.txt");

            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                using(TextReader reader = new StreamReader(file))
                {
                    using(FileStream outputFile = new FileStream(destPath ,FileMode.Create))
                    {
                        using (TextWriter writer = new StreamWriter(outputFile))
                        {
                            string line = reader.ReadLine();

                            int counter = 0;

                            while (line != null)
                            {
                                if(counter % 2 != 0)
                                {
                                    writer.WriteLine(line);
                                }

                                counter++;
                                line = reader.ReadLine();
                            }
                        }
                    }
                }
            }
        }
    }
}
