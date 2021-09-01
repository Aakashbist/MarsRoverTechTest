using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Rover : IRover
    {

        public int XCordinate { get; set; }
        public int Ycordinate { get; set; }
        public Rover(string position)
        {
            var args = position.Split(' ');
            XCordinate = Int32.Parse(args[0]);
            Ycordinate = Int32.Parse(args[1]);
            Direction = args[2];
        }

        public Rover()
        {
        }

        public string Direction { get; private set; }

        public void ChangeDirection(string direction)
        {
            if (direction == "R")
            {
                string[] compass = { "N", "E", "S", "W" };
                Turn(compass);
            }
            else if(direction == "L")
            {
                string[] compass = { "N", "W", "S", "E" };
                Turn(compass);
            }
            else
            {
                throw new ArgumentException("you passed valid direction");
            }
        }

        private void Turn(string[] compass)
        {
            int currentDirection = Array.IndexOf(compass, Direction);
            Direction = compass[(currentDirection + 1) % 4];
        }

        private void MoveInSameDirection()
        {
            switch (Direction)
            {
                case "N":
                    Ycordinate += 1;
                    break;
                case "S":
                   Ycordinate -= 1;
                    break;
                case "E":
                    XCordinate += 1;
                    break;
                case "W":
                    XCordinate -= 1;
                    break;
                default:
                    throw new ArgumentException($"({Direction}) must be (N,E,S,W)");
               
            }
        }

        public void StartMoving(Plateau plateau, string moves)
        {
            foreach (var move in moves)
            {
                switch (move)
                {
                    case 'M':
                        MoveInSameDirection();
                        break;
                    case 'L':
                        ChangeDirection("L");
                        break;
                    case 'R':
                        ChangeDirection("R");
                        break;
                    default:
                        throw new ArgumentException("Invalid Direction");
                }

                if (XCordinate < 0 || XCordinate > plateau.XCordinate || Ycordinate < 0 || Ycordinate > plateau.YCordinate)
                {
                    throw new ArgumentOutOfRangeException($"Xcordinate and Ycordinate must should be in between of (0,0) and (5,5)"); ;
                }
            }


        }

    }
}
