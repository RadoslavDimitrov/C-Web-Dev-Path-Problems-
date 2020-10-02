﻿using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace P4.CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using var reader = new FileStream("picture.png", FileMode.OpenOrCreate);
            using var writer = new FileStream("./pictureCopy.png", FileMode.OpenOrCreate);

            byte[] buffer = new byte[4096];

            while (true)
            {
                var bytesToRead = reader.Read(buffer, 0, buffer.Length);

                if(bytesToRead < buffer.Length)
                {
                    buffer = buffer.Take(bytesToRead).ToArray();
                    writer.Write(buffer, 0, buffer.Length);

                    break;
                }

                writer.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
