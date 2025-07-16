using Katalyst_TDD_Starter.Arithmetics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katalyst_TDD_Starter.Test.Arithmetics;

[TestClass]
public class ArithmeticFeatureShould
{
    [TestMethod]
    [DataRow("( 1 + ( ( 2 + 3 ) * (4 * 5) ) )", 101)]
    [DataRow("( 5 * ( 4 * ( 3 * ( 2 * ( 1 * 9 ) / 8 - 7 ) + 6 ) ) )", 3)]
    [DataRow("((()()))", 0)]
    public void Calculate_example_answers(string input, int expectedResult)
    {
        var arithmeticCalculator = new ArithmeticCalculator();

        var actualResult = arithmeticCalculator.Calculate(input);

        Assert.AreEqual(expectedResult, actualResult);
    }
}
