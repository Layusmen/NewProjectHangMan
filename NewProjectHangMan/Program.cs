using System;
using System.Collections.Generic;

namespace NewProjectHangman
{
    class Program
    {
        const int MAX_GUESS = 6;

        static void Main(string[] args)
        {
            List<string> words = new List<string>() { "standard", "approach", "wonder", "student", "catering" };
            int counter = 0;
            Random random = new Random();
            int secretWordChosen = random.Next(words.Count);
            string secretWord = words[secretWordChosen];
            char[] revealedWord = new char[secretWord.Length];

            // Initialize the revealed word array with dashes.
            for (int i = 0; i < secretWord.Length; i++)
            {
                revealedWord[i] = '-';
            }

            // Clear the console and display the welcome message.
            Console.Clear();
            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine("I have picked a secret word from the list. Can you try to guess the word?");

            // Start the game loop.
            while (counter < MAX_GUESS)
            {
                // Display the current state of the revealed word.
                string guessedWord = new string(revealedWord);
                Console.WriteLine($"\nCurrent word: {guessedWord}");
                Console.WriteLine($"Guesses remaining: {MAX_GUESS - counter}");

                // Read the player's guess.
                Console.Write("Guess a letter: ");
                char guess = Console.ReadKey().KeyChar;

                // Check if the guess is contained in the secret word.
                bool isCorrectGuess = false;
                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (secretWord[i] == guess)
                    {
                        revealedWord[i] = guess;
                        isCorrectGuess = true;
                    }
                }

                // If the guess is incorrect, deduct from the player's total.
                if (!isCorrectGuess)
                {
                    counter++;
                }

                // Check if the player has won or lost the game.
                if (new string(revealedWord) == secretWord)
                {
                    Console.WriteLine($"\nYou win! The secret word was '{secretWord}'.");
                    break;
                }
                else if (counter == MAX_GUESS)
                {
                    Console.WriteLine($"\nYou lose! The secret word was '{secretWord}'.");
                    break;
                }
            }
        }
    }
}
