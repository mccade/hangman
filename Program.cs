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
            //initialize variables
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

            //get phrase and put its words in an array
            secretPhrase = Console.ReadLine();
            string[] words = secretPhrase.Split(' ');

            //create new array of same length as the phrase array to fill with underscores to show guesser what's left to guess
            string[] blanks = new string[words.Length];
            Console.Clear();

            //loop to make underscore version of the secret phrase
            for(int h = 0; h < words.Length; h++)
            {
                for(int k = 0; k < words[h].Length; k++)
                {
                    blankWord = blankWord + "_";
                }
                blanks[h] = blankWord;
                blankWord = "";
            }
            //loop to continue play until a loss
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

                //check if the previously blank array's data is the same as the phrase to check for victory
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

                //take input and compare
                guess = Console.ReadLine();
                if(guess == secretPhrase)
                {
                    endMessage = "You win!";
                    break;
                }
                else
                {
                    if(guess.Length > 1)
                    {
                        wrong++;
                    }
                }
                if(guess.Length == 1)
                {
                    guessChar = guess[0];
                    for (int i = 0; i < words.Length; i++)
                    {
                        for (int j = 0; j < words[i].Length; j++)
                        {
                            //check phrase for guess letter and replace its spot in the blank array if included
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
                if (correct == 0 && guess.Length == 1){
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
