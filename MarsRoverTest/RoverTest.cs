using MarsRover;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverTest
{
   public class RoverTest
    {
        [TestCase("N","E")]
        [TestCase("E", "S")]
        [TestCase("S", "W")]
        [TestCase("W", "N")]
        public void ShouldTurnRightClockwise(string initialDirection, string endDirection)
        {
            Rover rover = new ("1 2 "+initialDirection);
            rover.ChangeDirection("R");
            Assert.AreEqual(endDirection, rover.Direction);
        }


        [TestCase("N", "W")]
        [TestCase("W", "S")]
        [TestCase("S", "E")]
        [TestCase("E", "N")]
        public void ShouldTurnLeftClockwise(string initialDirection, string endDirection)
        {
            Rover rover = new ("1 2 " + initialDirection);
            rover.ChangeDirection("L");
            Assert.AreEqual(endDirection, rover.Direction);
        }


        [TestCase("1 2 N","LMLMLMLMM", "1 3 N")]
        [TestCase("3 3 E", "MMRMMRMRRM", "5 1 E")]
        public void ShouldMove(string initialPosition ,string command, string endPosition)
        {
            Rover rover = new (initialPosition);
            Plateau plateau = new(5, 5);
            rover.StartMoving(plateau, command);
            var actualOutput = $"{rover.XCordinate} {rover.Ycordinate} {rover.Direction}";
            Assert.AreEqual(endPosition, actualOutput);
        }

 
        [Test]
        public void ShouldThrowArgumentExceptionIfDirectionIsNotLeftOrRight()
        {
            Rover rover = new();
       
            Assert.Throws<ArgumentException>(() => rover.ChangeDirection("F"));
        }

        [TestCase("2 12 N", "LMLMLMLMM")]
        [TestCase("12 2 E", "LMLMLMLMM")]
        public void ShouldThrowArgumentOutOfRangeExceptionIfCordinatesOfRoverIsOutOfRange( string position,string command)
        {
            Rover rover = new(position);
            Plateau plateau = new(5, 5);

            Assert.Throws<ArgumentOutOfRangeException>(() => rover.StartMoving(plateau,command));
        }
    }
}

