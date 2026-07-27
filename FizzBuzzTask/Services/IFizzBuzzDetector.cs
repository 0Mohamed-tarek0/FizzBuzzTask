using System;
using System.Collections.Generic;
using System.Text;
using FizzBuzzTask.Models;

namespace FizzBuzzTask.Services
{
    public interface IFizzBuzzDetector
    {
        FizzBuzzResult GetOverlappings(string input);
    }
}
