namespace Katalyst_TDD_Starter.MarsRover
{
    public class Rover
    {
        public string Direction { get; set; } = "N";

        public Rover()
        {
        }

        public string Move(string input)
        {
            foreach (var command in input)
            {
                if (command == 'R')
                {
                    if (Direction == "W")
                    {
                        Direction = "N";
                        continue;
                    }

                    if (Direction == "S")
                    {
                        Direction = "W";
                        continue;
                    }

                    if (Direction == "E")
                    {
                        Direction = "S";
                        continue;
                    }

                    if (Direction == "N")
                    {
                        Direction = "E";
                        continue;
                    }
                }
            }

            return $"0:0:{Direction}";
        }
    }
}