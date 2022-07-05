namespace Katalyst_TDD_Starter.MarsRover
{
    public class Rover
    {
        public Rover()
        {
        }

        public string Move(string input)
        {
            if (input.Equals("RR"))
            {
                return "0:0:S";
            }

            return "0:0:E";
        }
    }
}