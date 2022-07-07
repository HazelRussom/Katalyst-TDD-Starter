namespace Katalyst_TDD_Starter.MarsRover
{
    public class Rover
    {
        private Direction Direction = Direction.N;
        private int YPosition = 0;
        private int XPosition = 0;

        private const int MOVEMENT_SPEED = 1;

        public Rover()
        {
        }

        public string Execute(string input)
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

            return $"{XPosition}:{YPosition}:{Direction}";
        }

        private void Move()
        {
            if(Direction == Direction.N)
            {
                YPosition += MOVEMENT_SPEED;

                if (YPosition == 10)
                {
                    YPosition = 0;
                }
            }

            if(Direction == Direction.S)
            {
                YPosition -= MOVEMENT_SPEED;

                if (YPosition == -1)
                {
                    YPosition = 9;
                }
            }

            if (Direction == Direction.E)
            {
                XPosition += MOVEMENT_SPEED;

                if (XPosition == 10)
                {
                    XPosition = 0;
                }
            }

            if (Direction == Direction.W)
            {
                XPosition -= MOVEMENT_SPEED;

                if (XPosition == -1)
                {
                    XPosition = 9;
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

            Direction += MOVEMENT_SPEED;
        }

        private void TurnLeft()
        {
            if (Direction == Direction.N)
            {
                Direction = Direction.W;
                return;
            }

            Direction -= MOVEMENT_SPEED;
        }
    }
}