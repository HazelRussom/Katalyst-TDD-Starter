namespace Katalyst_TDD_Starter.MarsRover
{
    public class Rover
    {
        private Direction Direction = Direction.N;
        private int YPosition = 0;

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

                if (command == 'L')
                {
                    TurnLeft();
                }

                if (command == 'M')
                {
                    Move();
                }
            }

            return $"0:{YPosition}:{Direction}";
        }

        private void Move()
        {
            if(Direction == Direction.N)
            {
                YPosition += 1;

                if (YPosition == 10)
                {
                    YPosition = 0;
                }

                return;
            }

            if(Direction == Direction.S)
            {
                YPosition -= 1;

                if (YPosition == -1)
                {
                    YPosition = 9;
                }
            }
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