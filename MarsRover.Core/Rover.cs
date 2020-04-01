using MarsRover.Core.Enums;
using System;

namespace MarsRover.Core
{
    public class Rover : IRover
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public Direction Direction { get; set; }

        public Rover(int xPosition, int yPosition, string direction)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            Direction = Enum.Parse<Direction>(direction);
        }

        public void Move(Map map)
        {
            var currentX = XPosition;
            var currentY = YPosition;

            switch (Direction)
            {
                case Direction.N:
                    currentY++;
                    break;
                case Direction.E:
                    currentX++;
                    break;
                case Direction.S:
                    currentY--;
                    break;
                case Direction.W:
                    currentX--;
                    break;
            }

            if (ValidateCoordinates(map, currentX, currentY))
                ApplyCoordinates(currentX, currentY);
        }

        public void Rotate(CommandInput input)
        {
            switch (input)
            {
                case CommandInput.L:
                    Direction = (Direction)((((int)Direction - 1) % 4 + 4) % 4);
                    break;
                case CommandInput.R:
                    Direction = (Direction)((((int)Direction + 1) % 4 + 4) % 4);
                    break;
            }
        }

        public bool ValidateCoordinates(Map map, int x, int y)
        {
            return x < map.MinX || x > map.MaxX ? false : y < map.MinY || y > map.MaxY ? false : true;
        }

        public void ApplyCoordinates(int x, int y)
        {
            XPosition = x;
            YPosition = y;
        }
    }
}