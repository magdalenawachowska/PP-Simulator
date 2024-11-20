using Simulator;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator;

public class PointTests
{
    [Theory]
    [InlineData(3, 3, "(3, 3)")]
    [InlineData(10, 24, "(10, 24)")]
    public void ToStringShouldReturnCorrectStringRepresentation(int x, int y, string expectedstring)
    {
        //Arrange
        var p = new Point(x, y);
        //Act & Assert
        Assert.Equal(expectedstring, p.ToString());
    }

    [Theory]
    [InlineData(1,1, Direction.Right, 2,1)]
    [InlineData(10, 8, Direction.Down, 10, 7)]
    [InlineData(6,4, Direction.Up, 6, 5)]
    [InlineData(28, 27, Direction.Left, 27, 27)]
    public void NextShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        //Arrange
        var point = new Point(x, y);

        //Act
        var newNextPoint = point.Next(direction);

        //Assert
        Assert.Equal(new Point(expectedX, expectedY), newNextPoint);
    }

    [Theory]
    [InlineData(10, 25, Direction.Right, 11, 24)]
    [InlineData(10, 25, Direction.Down, 9, 24)]
    [InlineData(10, 25, Direction.Up, 11, 26)]
    [InlineData(10, 25, Direction.Left, 9, 26)]
    public void NextDiagonalShouldReturnCorrectNextDiagonalPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        //Arrange
        var point = new Point(x, y);
        //Act
        var newDiagonalPoint = point.NextDiagonal(direction);
        //Assert
        Assert.Equal(new Point(expectedX, expectedY), newDiagonalPoint);
    }

}
