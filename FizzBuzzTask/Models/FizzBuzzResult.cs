using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzzTask.Models
{
    public sealed class FizzBuzzResult
    {

        public string OutputString { get; }


        public int FizzCount { get; }


        public int BuzzCount { get; }


        public int FizzBuzzCount { get; }


        public int TotalCoincidences => FizzCount + BuzzCount + FizzBuzzCount;


        public FizzBuzzResult(string outputString, int fizzCount, int buzzCount, int fizzBuzzCount)
        {
            OutputString = outputString;
            FizzCount = fizzCount;
            BuzzCount = buzzCount;
            FizzBuzzCount = fizzBuzzCount;
        }
    }
}
