using Xunit;
namespace FizzBuzzLib.Tests;
using FizzBuzzTask.Models;
using FizzBuzzTask.Services;
public class FizzBuzzWordDetectorTests
{
    private readonly FizzBuzzDetector _detector = new();

    [Fact]
    public void GetOverlappings_TaskExample_ProducesExpectedOutputAndCount()
    {
        const string input =
            "Mary had a little lamb\n" +
            "Little lamb, little lamb\n" +
            "Mary had a little lamb\n" +
            "It's fleece was white as snow";

        const string expectedOutput =
            "Mary had Fizz little Buzz\n" +
            "Fizz lamb, little Fizz\n" +
            "Buzz had Fizz little lamb\n" +
            "FizzBuzz fleece was Fizz as Buzz";

        FizzBuzzResult result = _detector.GetOverlappings(input);

        Assert.Equal(expectedOutput, result.OutputString);
        Assert.Equal(9, result.TotalCoincidences);
    }

    [Fact]
    public void GetOverlappings_NullInput_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _detector.GetOverlappings(null!));
    }

    [Fact]
    public void GetOverlappings_EmptyString_ReturnsEmptyOutputAndZeroCount()
    {
        FizzBuzzResult result = _detector.GetOverlappings(string.Empty);

        Assert.Equal(string.Empty, result.OutputString);
        Assert.Equal(0, result.TotalCoincidences);
    }

    [Fact]
    public void GetOverlappings_FewerThanThreeWords_LeavesTextUnchanged()
    {
        FizzBuzzResult result = _detector.GetOverlappings("one two");

        Assert.Equal("one two", result.OutputString);
        Assert.Equal(0, result.TotalCoincidences);
    }

    [Fact]
    public void GetOverlappings_ExactlyFifteenWords_LastWordBecomesFizzBuzz()
    {
        const string input =
            "w1 w2 w3 w4 w5 w6 w7 w8 w9 w10 w11 w12 w13 w14 w15";

        FizzBuzzResult result = _detector.GetOverlappings(input);

        Assert.EndsWith("FizzBuzz", result.OutputString);
        Assert.Equal(1, result.FizzBuzzCount);
        Assert.Equal(4, result.FizzCount);  // words 3, 6, 9, 12
        Assert.Equal(2, result.BuzzCount);  // words 5, 10
        Assert.Equal(7, result.TotalCoincidences);
    }

    [Fact]
    public void GetOverlappings_SymbolOnlyTokensAreSkippedAndNotCounted()
    {

        const string input = "one -- two three *** four five";

        FizzBuzzResult result = _detector.GetOverlappings(input);


        Assert.Equal("one -- two Fizz *** four Buzz", result.OutputString);
        Assert.Equal(1, result.FizzCount);
        Assert.Equal(1, result.BuzzCount);
        Assert.Equal(0, result.FizzBuzzCount);
    }

    [Fact]
    public void GetOverlappings_PunctuationAttachedToWord_IsPreservedWhenNotReplaced()
    {
        FizzBuzzResult result = _detector.GetOverlappings("hello, world! today");


        Assert.Equal("hello, world! Fizz", result.OutputString);
        Assert.Equal(1, result.FizzCount);
    }

    [Fact]
    public void GetOverlappings_MultipleWhitespaceAndNewlines_ArePreservedExactly()
    {
        const string input = "one   two\nthree";

        FizzBuzzResult result = _detector.GetOverlappings(input);


        Assert.Equal("one   two\nFizz", result.OutputString);
    }
}
