using MarsRover.Core.Enums;

namespace MarsRover.Core
{
    public interface IRover
    {
        void Move(Map map);
        void Rotate(CommandInput input);
        void ApplyCoordinates(int x, int y);
        bool ValidateCoordinates(Map map, int x, int y);
    }
}