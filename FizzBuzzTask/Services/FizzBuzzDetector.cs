using System;
using System.Collections.Generic;
using System.Text;
using FizzBuzzTask.Models;

namespace FizzBuzzTask.Services
{
    public sealed class FizzBuzzDetector : IFizzBuzzDetector
    {
        private const string FizzKeyword = "Fizz";
        private const string BuzzKeyword = "Buzz";
        private const string FizzBuzzKeyword = "FizzBuzz";

        private const int FizzDivisor = 3;
        private const int BuzzDivisor = 5;

        
        public FizzBuzzResult GetOverlappings(string input)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input), "Input string cannot be null.");
            }

            var output = new StringBuilder(input.Length);
            int wordIndex = 0;
            int fizzCount = 0;
            int buzzCount = 0;
            int fizzBuzzCount = 0;

            int position = 0;
            int length = input.Length;

            while (position < length)
            {
                if (char.IsWhiteSpace(input[position]))
                {
                    // Copy the run of whitespace (spaces, tabs, newlines) as-is.
                    int start = position;
                    while (position < length && char.IsWhiteSpace(input[position]))
                    {
                        position++;
                    }

                    output.Append(input, start, position - start);
                    continue;
                }

                // Copy the run of non-whitespace characters: this is one "token".
                int tokenStart = position;
                while (position < length && !char.IsWhiteSpace(input[position]))
                {
                    position++;
                }

                string token = input.Substring(tokenStart, position - tokenStart);

                if (!ContainsAlphanumericCharacter(token))
                {
                    // Symbols-only token (e.g. "--", "***"): not a word, skip
                    // counting and leave it untouched in the output.
                    output.Append(token);
                    continue;
                }

                wordIndex++;

                string replacement = DetermineReplacement(
                    wordIndex,
                    ref fizzCount,
                    ref buzzCount,
                    ref fizzBuzzCount);

                output.Append(replacement ?? token);
            }

            return new FizzBuzzResult(output.ToString(), fizzCount, buzzCount, fizzBuzzCount);
        }
        private static string? DetermineReplacement(
            int wordIndex,
            ref int fizzCount,
            ref int buzzCount,
            ref int fizzBuzzCount)
        {
            bool isFizz = wordIndex % FizzDivisor == 0;
            bool isBuzz = wordIndex % BuzzDivisor == 0;

            if (isFizz && isBuzz)
            {
                fizzBuzzCount++;
                return FizzBuzzKeyword;
            }

            if (isFizz)
            {
                fizzCount++;
                return FizzKeyword;
            }

            if (isBuzz)
            {
                buzzCount++;
                return BuzzKeyword;
            }

            return null;
        }


        private static bool ContainsAlphanumericCharacter(string token)
        {
            foreach (char c in token)
            {
                if (char.IsLetterOrDigit(c))
                {
                    return true;
                }
            }

            return false;
        }
    }

    
}
