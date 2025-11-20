using Katalyst_TDD_Starter.Arithmetics;

namespace Katalyst_TDD_Starter.Test.Arithmetics;

public class ArithmeticCalculatorShould
{
    ArithmeticCalculator calculator;

    public ArithmeticCalculatorShould()
    {
        calculator = new ArithmeticCalculator();
    }

    private void ExpectInputGeneratesResult(string input, double expectedResult)
    {
        var actualResult = calculator.Calculate(input);

        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [InlineData("()")]
    [InlineData("(())")]
    [InlineData("((()))")]
    public void Calculate_empty_parenthesis_as_0(string input)
    {
        ExpectInputGeneratesResult(input, 0);
    }

    [Theory]
    [InlineData("(")]
    [InlineData("())")]
    [InlineData("((())")]
    [InlineData(")(")]
    public void Throw_when_parenthesis_do_not_match(string input)
    {
        var exception = Assert.Throws<Exception>(() => calculator.Calculate(input));

        Assert.Equal("Invalid record error", exception.Message);
    }

    [Theory]
    [InlineData("1")]
    [InlineData("3 + ( 1 + 2 )")]
    public void Throw_when_input_is_not_wrapped_in_parenthesis(string input)
    {
        var exception = Assert.Throws<Exception>(() => calculator.Calculate(input));

        Assert.Equal("Invalid record error", exception.Message);
    }

    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(1, 2, 3)]
    [InlineData(13, 6, 19)]
    public void Sum_two_numbers(int firstNumber, int secondNumber, int expectedResult)
    {
        ExpectInputGeneratesResult($"({firstNumber} + {secondNumber})", expectedResult);
    }

    [Theory]
    [InlineData(2, 1, 1)]
    [InlineData(10, 4, 6)]
    [InlineData(1, 12, -11)]

    public void Subtract_two_numbers(int firstNumber, int secondNumber, int expectedResult)
    {
        ExpectInputGeneratesResult($"({firstNumber} - {secondNumber})", expectedResult);
    }

    [Theory]
    [InlineData(2, 1, 2)]
    [InlineData(5, 4, 20)]
    [InlineData(0.5, 5, 2.5)]

    public void Multiply_two_numbers(double firstNumber, double secondNumber, double expectedResult)
    {
        ExpectInputGeneratesResult($"({firstNumber} * {secondNumber})", expectedResult);
    }

    [Theory]
    [InlineData(5, 1, 5)]
    [InlineData(24, 4, 6)]
    [InlineData(2, 4, 0.5)]

    public void Divide_two_numbers(double firstNumber, double secondNumber, double expectedResult)
    {
        ExpectInputGeneratesResult($"({firstNumber} / {secondNumber})", expectedResult);
    }
}
