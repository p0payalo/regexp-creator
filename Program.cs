using System;
using System.Collections.Generic;
using System.IO;

namespace ObsceneWordsFilter
{
    class Program
    {
        static Dictionary<string, string> Words = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            ConsoleKeyInfo UserChoise;
            string UserInput;
            bool Exit = false;
            while (!Exit)
            {
                Console.WriteLine("1. Add new english word\n2. Add new russian word\n3. My words list\n4. Input test string\n5. Save result in file\n0 or Escape. Exit");
                UserChoise = Console.ReadKey();
                switch (UserChoise.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("Enter target word: ");
                        UserInput = Console.ReadLine();
                        try
                        {
                            AddNewWord(UserInput, WordLanguage.English);
                            Console.Clear();
                            Console.WriteLine("Your word has been added\n");
                        }
                        catch (KeyNotFoundException e)
                        {
                            Console.Clear();
                            Console.WriteLine("This word have another language letters\n" + e.Message + "\n");
                        }
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine("Enter target word: ");
                        UserInput = Console.ReadLine();
                        try
                        {
                            AddNewWord(UserInput, WordLanguage.Russian);
                            Console.Clear();
                            Console.WriteLine("Your word has been added\n");
                        }
                        catch (KeyNotFoundException e)
                        {
                            Console.Clear();
                            Console.WriteLine("This word have another language letters\n" + e.Message + "\n");
                        }
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        Console.WriteLine("Words list:");
                        ShowWordsList();
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        Console.WriteLine("Enter target string: ");
                        UserInput = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Changed string: " + Filter.FormatString(UserInput, Words.Values) + "\n");
                        break;
                    case ConsoleKey.D5:
                        Console.Clear();
                        Console.WriteLine("Enter target filename: ");
                        UserInput = Console.ReadLine();
                        SaveFile(UserInput);
                        Console.Clear();
                        Console.WriteLine("File was saved as " + Path.GetFullPath(UserInput));
                        break;
                    case ConsoleKey.Escape:
                        Exit = true;
                        break;
                    case ConsoleKey.D0:
                        Exit = true;
                        break;
                    default:
                        Console.Clear();
                        break;

                }
            };
        }

        static void AddNewWord(string input, WordLanguage wl)
        {
            try
            {
                Words.Add(input, Filter.BuildRegularExpression(input, wl));
            }
            catch (ArgumentException e)
            {
                Console.Clear();
                Console.WriteLine("This word is currently exist\n" + e.Message + "\n");
            }
        }

        static void ShowWordsList()
        {
            foreach (var i in Words)
            {
                Console.WriteLine("Word: " + i.Key);
                Console.WriteLine("Regular expression: " + i.Value + "\n");
            }
        }

        static void SaveFile(string filename)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filename, true))
                {
                    foreach (var i in Words)
                    {
                        sw.WriteLine("{0} : {1}", i.Key, i.Value);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
