using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace _3._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordsPath = Path.Combine("data", "words.txt");
            string inputPath = Path.Combine("data", "input.txt");
            string outputPath = Path.Combine("data", "output.txt");

            using(FileStream wordFile = new FileStream(wordsPath, FileMode.Open)) //open words.txt
            {
                using(TextReader wordReader = new StreamReader(wordFile)) //read words.txt
                {
                    using(FileStream inputFile = new FileStream(inputPath, FileMode.Open)) //open input.txt
                    {
                        using (TextReader inputReader = new StreamReader(inputFile)) //read input.txt
                        {
                            using (FileStream outputFile = new FileStream(outputPath, FileMode.Create)) //create output.txt
                            {
                                using(TextWriter outputWriter = new StreamWriter(outputFile)) //writing in output.txt
                                {
                                    string[] wordsToCount = wordReader.ReadToEnd().ToLower().TrimStart('-')
                                        .TrimEnd(new char[] { '.', '!', '?' })
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                                    string inputData = inputReader.ReadLine();

                                    List<string> inputDataAsList = new List<string>();


                                    while (inputData != null)
                                    {
                                        StringBuilder sb = new StringBuilder(inputData);

                                        for (int i = 0; i < sb.Length; i++)
                                        {
                                            if (sb[i] == ',')
                                            {
                                                sb[i] = ' ';
                                            }
                                        }

                                        inputData = sb.ToString();

                                        string[] currinputData = inputData.ToLower().TrimStart('-')
                                            .TrimEnd(new char[] { '.', '!', '?', ',' })
                                            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                                        for (int i = 0; i < currinputData.Length; i++)
                                        {
                                            inputDataAsList.Add(currinputData[i]);
                                        }

                                        inputData = inputReader.ReadLine();
                                    }

                                    Dictionary<string, int> outputData = new Dictionary<string, int>();

                                    for (int i = 0; i < wordsToCount.Length; i++)
                                    {
                                        string currWord = wordsToCount[i];

                                        for (int k = 0; k < inputDataAsList.Count; k++)
                                        {
                                            if(currWord == inputDataAsList[k]) //same word in words.txt and input.txt
                                            {
                                                if (!outputData.ContainsKey(currWord))
                                                {
                                                    outputData.Add(currWord, 1);
                                                }
                                                else
                                                {
                                                    outputData[currWord]++;
                                                }
                                            }
                                        }
                                    }

                                    outputData = outputData.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                                    foreach (var item in outputData)
                                    {
                                        outputWriter.WriteLine($"{item.Key} - {item.Value}");
                                    }


                                }
                            }
                        }

                    }
                }
            }
        }
    }
}
