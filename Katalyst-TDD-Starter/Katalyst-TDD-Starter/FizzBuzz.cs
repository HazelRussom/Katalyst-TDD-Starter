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
            if(value % 3 == 0)
            {
                return "Fizz";
            }

            if(value == 5)
            {
                return "Buzz";
            }

            return value.ToString();
        }
    }
}
