using System;
using System.Collections.Generic;
using System.IO;

namespace _4._Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputOnePath = Path.Combine("data", "input1.txt");
            string inputTwoPath = Path.Combine("data", "input2.txt");
            string outputPath = Path.Combine("data", "output.txt");

            string[] firstInput = File.ReadAllLines(inputOnePath);
            string[] secondInput = File.ReadAllLines(inputTwoPath);

            List<string> outputData = new List<string>();

            if(firstInput.Length > secondInput.Length)
            {

                for (int i = 0; i < secondInput.Length; i++)
                {
                    outputData.Add(firstInput[i]);
                    outputData.Add(secondInput[i]);
                }

                for (int k = secondInput.Length; k < firstInput.Length; k++)
                {
                    outputData.Add(firstInput[k]);
                }
            }
            else if(firstInput.Length < secondInput.Length)
            {
                for (int i = 0; i < firstInput.Length; i++)
                {
                    outputData.Add(firstInput[i]);
                    outputData.Add(secondInput[i]);
                }

                for (int k = firstInput.Length; k < secondInput.Length; k++)
                {
                    outputData.Add(firstInput[k]);
                }
            }
            else
            {
                for (int i = 0; i < firstInput.Length; i++)
                {
                    outputData.Add(firstInput[i]);
                    outputData.Add(secondInput[i]);
                }
            }

            File.WriteAllLines(outputPath, outputData);
        }
    }
}
