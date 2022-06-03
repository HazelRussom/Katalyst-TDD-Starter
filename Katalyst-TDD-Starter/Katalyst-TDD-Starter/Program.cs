using Katalyst_TDD_Starter.FizzBuzz;
using Katalyst_TDD_Starter.FizzBuzz.Converters;
using Katalyst_TDD_Starter.Test.Utilities;

new FizzBuzzExecutor(new FizzBuzzWithDigitsConverter(), new ConsoleWriter()).Execute(100);