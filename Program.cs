using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            string secretPhrase;
            string guess;
            string wrongGuesses = "";
            char guessChar = 'a';
            int correctNum = 0;
            string endMessage = "";
            int wrong = 0;
            int correct = 0;
            string blankWord = "";
            string[] noose = { "|----|\n|    |\n|\n|\n|\n|\n", "|----|\n|    |\n|    O\n|\n|\n|\n", "|----|\n|    |\n|    O\n|    |\n|\n|\n", "|----|\n|    |\n|    O\n|   /|\n|\n|\n", "|----|\n|    |\n|    O\n|   /|7\n|\n|\n", "|----|\n|    |\n|    O\n|   /|7\n|   /\n|\n", "|----|\n|    |\n|    O\n|   /|7\n|   / 7\n|\n" };
            Console.Write("Hangman\n" + "Enter your word(s): ");
            secretPhrase = Console.ReadLine();
            string[] words = secretPhrase.Split(' ');
            string[] blanks = new string[words.Length];
            Console.Clear();
            for(int h = 0; h < words.Length; h++)
            {
                for(int k = 0; k < words[h].Length; k++)
                {
                    blankWord = blankWord + "_";
                }
                blanks[h] = blankWord;
                blankWord = "";
            }
            while(wrong < 6)
            {
                Console.Clear();
                Console.Write(noose[wrong]);
                for(int g = 0; g < blanks.Length; g++)
                {
                    Console.Write(blanks[g]+' ');
                }
                Console.WriteLine();
                Console.WriteLine(wrongGuesses);
                for(int y = 0; y < words.Length; y++)
                {
                    if(words[y] == blanks[y])
                    {
                        correctNum++;
                    }
                }
                if(correctNum == words.Length)
                {
                    endMessage = "You win!";
                    break;
                }
                correctNum = 0;
                guess = Console.ReadLine();
                if(guess == secretPhrase)
                {
                    endMessage = "You win!";
                    break;
                }
                if(guess.Length == 1)
                {
                    guessChar = guess[0];
                    for (int i = 0; i < words.Length; i++)
                    {
                        for (int j = 0; j < words[i].Length; j++)
                        {
                            if (guessChar == words[i][j])
                            {
                                StringBuilder blankFix = new StringBuilder(blanks[i]);
                                blankFix[j] = guessChar;
                                blanks[i] = blankFix.ToString();
                                correct++;
                            }
                        }
                    }
                }
                if (correct == 0){
                    wrongGuesses = wrongGuesses + guessChar;
                    wrong++;
                }
                else
                {
                    correct = 0;
                }
            }
            if(wrong == 6)
            {
                endMessage = "You lose!";
            }
            Console.Clear();
            Console.Write(noose[wrong]);
            for (int z = 0; z < words.Length; z++)
            {
                Console.Write(words[z] + ' ');
            }
            Console.WriteLine();
            Console.WriteLine(endMessage);
            Console.ReadKey();
        }
    }
}
