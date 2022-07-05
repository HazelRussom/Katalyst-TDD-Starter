namespace Katalyst_TDD_Starter.MarsRover
{
    public class Rover
    {
        public Direction Direction { get; set; } = Direction.N;

        public Rover()
        {
        }

        public string Move(string input)
        {
            foreach (var command in input)
            {
                if (command == 'R')
                {
                    TurnRight();
                }
            }

            return $"0:0:{Direction}";
        }

        private void TurnRight()
        {
            if (Direction == Direction.W)
            {
                Direction = Direction.N;
                return;
            }

            Direction += 1;
        }
    }
}