using System;
using System.IO;

namespace _6._Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(); //enter path

            string[] files = Directory.GetFiles(path);

            double size = 0;

            foreach (string item in files)
            {
                FileInfo fileInfo = new FileInfo(item);

                size += fileInfo.Length;
            }

            size = size / 1024 / 1024;

            Console.WriteLine(size);
        }
    }
}
