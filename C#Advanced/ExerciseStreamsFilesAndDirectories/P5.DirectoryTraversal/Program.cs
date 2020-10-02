using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace P5.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string dirPath = Console.ReadLine();

            string[] files = Directory.GetFiles(dirPath);

            Dictionary<string, Dictionary<string, double>> allFiles = new Dictionary<string, Dictionary<string, double>>();

            foreach (var file in files)
            {
                var currFile = new FileInfo(file);

                string name = currFile.Name;
                double size = currFile.Length;
                string extension = currFile.Extension;

                if (!allFiles.ContainsKey(extension))
                {
                    allFiles.Add(extension, new Dictionary<string, double>());
                }

                allFiles[extension].Add(name, size);
            }

            allFiles = allFiles.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            string outputPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using(var writer = new StreamWriter($"{outputPath}/report.txt"))
            {
                foreach (var file in allFiles)
                {
                    string extension = file.Key;

                    var currFile = file.Value.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                    writer.WriteLine(extension);

                    foreach (var item in currFile)
                    {
                        writer.WriteLine($"--{item.Key} - {item.Value / 1024}kb");
                    }
                }
            }
        }
    }
}
