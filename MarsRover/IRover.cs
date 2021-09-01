using System.Collections.Generic;

namespace MarsRover
{
    public interface IRover
    {
        void StartMoving(Plateau plateau, string moves);

        void ChangeDirection(string direction);
    }
}