using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text.RegularExpressions;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();

        }

        public static void Menu()
        {
            while (true)
            {
                Console.WriteLine("======================\n     Hangman Game\n======================\n");
                Console.WriteLine("1] Start\n\n2] Info\n\n3] Exit\n");
                int select;

                // try to get a valid number in this while loop
                while (true)
                {
                    try
                    {
                        select = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Unkown Choice");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        continue;
                    }
                    if (select != 1 && select != 2 && select != 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Unkown Choice");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        continue;
                    }
                    else break;
                }
                // now i have a valid number

                if (select == 1)
                {
                    Console.Clear();
                    Hangman hangman = new Hangman();
                    string word = Hangman.GetRandomWord();
                    int chances = 6;
                    string dashes="";
                    int size = word.Length;
                    for(int i = 0; i < size; i++)
                    {
                        dashes += '-';
                    }
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("======================\n     Hangman Game\n======================\n");
                        Console.WriteLine($"Word : {dashes}\n\n");
                        Console.WriteLine(hangman[chances]+"\n\n");
                        Console.Write("Enter Your Guessing Letter : ");
                        char letter = GetChar();

                        if (IsLetterInWord(letter, word))
                        {
                            dashes = ReplaceDashesWithLetter(letter, dashes, word);
                            if(dashes == word)
                            {
                                
            
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n| You Saved The Hangman |");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine($"\n\n==================================");

                                break;
                            }
                        }
                        else
                        {
                            chances--;
                            if (chances == -1)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n| You Are Dead |");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write($"\n\nThe Word Was ");
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine($"( {word} )\n");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine("=================================");

                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Wrong Letter");
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }           
                        }          
                    }
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n< Click Enter To Back >");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    string enter = Console.ReadLine();
                    
                    Console.Clear();
                }

                else if(select == 2)
                {
                    Console.Clear();
                    Console.WriteLine("======================\n     Hangman Game\n======================\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Hangman Game Summary\n");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Objective:");
                    Console.ResetColor();
                    Console.WriteLine("Guess the word by suggesting letters. Win if you guess the word before running out of attempts.");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nHow to Play:");
                    Console.ResetColor();
                    Console.WriteLine("1. Guess letters; correct ones reveal themselves, wrong ones count against you.");
                    Console.WriteLine("2. Win by guessing all letters; lose if you use all attempts.");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nRules:");
                    Console.ResetColor();
                    Console.WriteLine("   - Typically, 7 incorrect guesses allowed.");
                    Console.WriteLine("   - Each wrong guess adds to the hangman figure.");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nTips:");
                    Console.ResetColor();
                    Console.WriteLine("   - Guess common letters first.");
                    Console.WriteLine("   - Look for letter patterns.");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nExample:");
                    Console.ResetColor();
                    Console.WriteLine("Word: 'apple'");
                    Console.WriteLine("   - Guess letters to reveal the word or run out of attempts.");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nHangman is a fun word game to improve vocabulary!\n");
                    Console.ResetColor();

                    Console.WriteLine("===================================================================================================================");

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n< Click Enter To Back >");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    string enter = Console.ReadLine();
                    Console.Clear();
                }
      
                else
                {
                    break;
                }


            }
        }

        public static bool IsLetterInWord(char letter, string word)
        {
            foreach (char c in word)
            {
                if (c == letter) return true;
            }
            return false;
        }

        public static string ReplaceDashesWithLetter(char letter, string dash,  string word)
        {
            char[] dasharray = dash.ToCharArray();
            for(int i = 0 ; i < word.Length ; i++)
            {
                if (word[i] == letter)
                {
                    dasharray[i] = letter;
                }
            }

            return new string(dasharray);
        }

        public static char GetChar()
        {
            string letter;
            while (true)
            {
                letter = Console.ReadLine();

                //regular exeprission to check if it special char or not
                if (Regex.IsMatch(letter, @"[\"";./,!@#$%?><^&*()_+=\\}{\[\]]"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Special Characters Is Not Allowed");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    continue;
                }

                //regular exeprission to check if it number or not
                if (Regex.IsMatch(letter, @"^\d+(\.\d+)?$"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Enter Only English Character");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    continue;
                }

                //check length of letter
                if (letter.Length != 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Enter Only One Letter");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    continue;
                }
                
                else break;
            }
            letter = letter.ToLower();
            return letter[0];
        }
    }
}

