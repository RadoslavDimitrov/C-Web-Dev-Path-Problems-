using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;

namespace P3.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            //actualResult.txt - without sorting
            //expectedResult.txt - with sorting - descending
            string wordsPath = Path.Combine("words.txt");
            string textPath = Path.Combine("text.txt");
            string actualPath = Path.Combine("actualResult.txt");
            string expectedPath = Path.Combine("expectedResult.txt");

            using (var reader = new StreamReader(wordsPath))
            {
                using (var textReader = new StreamReader(textPath))
                {
                    
                    List<string> words = new List<string>();

                    string wordLine = reader.ReadLine();

                    while (wordLine != null)
                    {
                        words.Add(wordLine);
                        wordLine = reader.ReadLine();
                    }

                    var text = new List<string>();

                    char[] separators = new char[] { '-', ',', '.', '!', '?', ' ' };

                    var line = textReader.ReadLine();

                    while (line != null)
                    {
                        text.AddRange(line.ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries));
                        line = textReader.ReadLine();
                    }

                    Dictionary<string, int> countWords = new Dictionary<string, int>();

                    foreach (string word in words)
                    {
                        countWords.Add(word, 0);

                        while (text.Contains(word))
                        {
                            countWords[word]++;
                            text.RemoveAt(text.IndexOf(word));
                        }
                    }

                    using (var writer = new FileStream(actualPath, FileMode.OpenOrCreate))
                    {
                        using (var writeActual = new StreamWriter(writer))
                        {
                            foreach (var item in countWords)
                            {
                                writeActual.WriteLine($"{item.Key} - {item.Value}");
                            }
                        }
                    }
                    
                    using (var writerExp = new FileStream(expectedPath, FileMode.OpenOrCreate))
                    {
                        using (var writerExpected = new StreamWriter(writerExp))
                        {
                            countWords = countWords.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                            foreach (var item in countWords)
                            {
                                writerExpected.WriteLine($"{item.Key} - {item.Value}");
                            }
                        }
                    }

                    
                }
                
            }

            

            

            

           

            

            

            
        }
    }
}
