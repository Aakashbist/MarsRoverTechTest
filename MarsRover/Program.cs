using System;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Plateau plateau = new Plateau(5, 5);
            Rover rover = new Rover("3 3 E");
            var moves = "MMRMMRMRRM";

            try
            {
                rover.StartMoving(plateau, moves);
                Console.WriteLine($"{rover.XCordinate} {rover.Ycordinate} {rover.Direction}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
