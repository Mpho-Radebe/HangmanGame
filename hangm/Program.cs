using System;

class HangmanGame
{
    static void Main()
    {
        int wins = 0; // Counter for the number of wins
        int losses = 0; // Counter for the number of losses
        bool playAgain = true; // Determines if the player wants to play again

        Console.WriteLine("Welcome to Hangman!");

        string[] words = { "apple", "banana", "orange", "grape", "mangoe" }; // Array of words to guess

        while (playAgain)
        {
            string wordToGuess = words[new Random().Next(0, words.Length)]; // Randomly select a word from the array
            char[] guessedLetters = new char[wordToGuess.Length]; // Array to store the guessed letters
            int attempts = 6; // Number of attempts allowed
            int correctGuesses = 0; // Number of correctly guessed letters

            Console.WriteLine("\nNew game started.");
            Console.WriteLine("Guess the word by entering one letter at a time.");
            Console.WriteLine("You have 6 attempts to guess the word.");

            while (attempts > 0 && correctGuesses < wordToGuess.Length)
            {
                Console.WriteLine("\nWord: " + GetWordDisplay(guessedLetters)); // Display the word with guessed letters
                Console.WriteLine("Attempts left: " + attempts); // Display the number of attempts left

                Console.Write("Enter a letter: ");
                char letter = Console.ReadLine().ToLower()[0]; // Read and convert the input to lowercase

                if (!Char.IsLetter(letter)) // Check if the input is a letter
                {
                    Console.WriteLine("Invalid input. Please enter a letter.");
                    continue;
                }

                if (Array.IndexOf(guessedLetters, letter) != -1) // Check if the letter has already been guessed
                {
                    Console.WriteLine("You already guessed that letter.");
                    continue;
                }

                bool letterFound = false;
                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (wordToGuess[i] == letter) // Check if the guessed letter is correct
                    {
                        guessedLetters[i] = letter; // Update the guessedLetters array
                        correctGuesses++; // Increment the counter for correct guesses
                        letterFound = true;
                    }
                }

                if (!letterFound)
                {
                    Console.WriteLine("Incorrect guess.");
                    attempts--; // Decrement the number of attempts
                }
            }

            if (correctGuesses == wordToGuess.Length) // Check if the word has been completely guessed
            {
                Console.WriteLine("\nCongratulations! You guessed the word: " + wordToGuess);
                wins++; // Increment the counter for wins
            }
            else
            {
                Console.WriteLine("\nGame over! The word was: " + wordToGuess);
                losses++; // Increment the counter for losses
            }

            Console.WriteLine("\nScoreboard:");
            Console.WriteLine("Wins: " + wins);
            Console.WriteLine("Losses: " + losses);

            Console.Write("\nDo you want to play again? (y/n): ");
            playAgain = Console.ReadLine().ToLower() == "y"; // Check if the player wants to play again
        }

        Console.WriteLine("Thank you for playing Hangman!");
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }

    static string GetWordDisplay(char[] guessedLetters)
    {
        string display = "";
        foreach (char letter in guessedLetters)
        {
            display += letter == '\0' ? "_" : letter.ToString(); // Replace empty characters with underscores
            display += " ";
        }
        return display.Trim();
    }
}






