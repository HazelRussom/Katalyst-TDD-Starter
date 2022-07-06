namespace Katalyst_TDD_Starter.MarsRover
{
    public class Rover
    {
        private Direction Direction = Direction.N;

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

                if(command == 'L')
                {
                    TurnLeft();
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

        private void TurnLeft()
        {
            if (Direction == Direction.N)
            {
                Direction = Direction.W;
                return;
            }

            Direction -= 1;
        }
    }
}