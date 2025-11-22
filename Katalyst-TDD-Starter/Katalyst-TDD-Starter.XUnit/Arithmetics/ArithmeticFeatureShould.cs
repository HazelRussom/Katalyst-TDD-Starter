using Katalyst_TDD_Starter.Arithmetics;

namespace Katalyst_TDD_Starter.Test.Arithmetics;

public class ArithmeticFeatureShould
{
    [Theory]
    [InlineData("( 1 + ( ( 2 + 3 ) * (4 * 5) ) )", 101)]
    [InlineData("( 5 * ( 4 * ( 3 * ( 2 * ( 1 * 9 ) / 8 - 7 ) + 6 ) ) )", 3)]
    [InlineData("((() + ()))", 0)]
    public void Calculate_example_answers(string input, int expectedResult)
    {
        var arithmeticCalculator = new ArithmeticCalculator();

        var actualResult = arithmeticCalculator.Calculate(input);

        Assert.Equal(expectedResult, actualResult);
    }
}
