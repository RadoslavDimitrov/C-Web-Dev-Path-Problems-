using System;
using System.IO;
using System.IO.Compression;

namespace ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @".\copyMe.png";

            string zipPath = @"C:\Users\morve\OneDrive\Desktop\Newfolder";

            string ExtractedFile = @"C:\Users\morve\OneDrive\Desktop\Newfolder\output";

            
            ZipFile.CreateFromDirectory(zipPath, filePath);
            ZipFile.ExtractToDirectory(zipPath, ExtractedFile);
        }
    }
}