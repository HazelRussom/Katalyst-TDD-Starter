namespace Katalyst_TDD_Starter
{
    public class FizzBuzz
    {
        public void Execute()
        {
            Console.WriteLine("FizzBuzz start");
        }

        public string Convert(int value)
        {
            var result = value.ToString();

            if(value % 3 == 0)
            {
                result = "Fizz";
            }

            if(value % 5 == 0)
            {
                result = "Buzz";
            }

            if (value == 15)
            {
                result = "FizzBuzz";
            }

            return result;
        }
    }
}
