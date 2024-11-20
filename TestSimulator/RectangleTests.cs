using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator;

public class RectangleTests
{
    [Theory]
    [InlineData(3, 4, 10, 14)]
    [InlineData(1, 1, 6, 6)]
    public void ConstructorShouldReturnCorrectRectangle(int x1, int y1, int x2, int y2)
    {
        //Arrange
        var correctRectangle = new Rectangle(x1, y1, x2, y2);

        //Act & Assert
        Assert.Equal(x1, correctRectangle.X1);
        Assert.Equal(y1, correctRectangle.Y1);
        Assert.Equal(x2, correctRectangle.X2);
        Assert.Equal(y2, correctRectangle.Y2);

    }

    [Theory]
    [InlineData(8,10,2,4)]
    [InlineData(5,5,0,0)]
    public void ConstructorShouldChangeTheOrderOfTheCorners(int x1, int y1, int x2, int y2)
    {
        //Arrange
        var incorrectRectangle = new Rectangle(x1, y1, x2, y2);

        //Act & Assert
        Assert.Equal(x2, incorrectRectangle.X1);
        Assert.Equal(y2, incorrectRectangle.Y1);
        Assert.Equal(x1, incorrectRectangle.X2);
        Assert.Equal(y1, incorrectRectangle.Y2);

    }

    [Fact]
    public void ConstructorShouldThrowArgumentException()
    {
        //Arrange
        //Act &  Assert
        Assert.Throws<ArgumentException>(()=> new Rectangle(3,4,3,4));
    }


    [Theory]
    [InlineData(7, 7, 20, 20, 14, 14)]
    [InlineData(3, 3, 10, 10, 7, 7)]
    public void ContainsShouldReturnTrue(int x1, int y1, int x2, int y2, int x3, int y3)
    {
        //Arrange
        var p1 = new Point(x1, y1);
        var p2 = new Point(x2, y2); 
        var rectangle = new Rectangle(p1, p2);

        var p3 = new Point(x3, y3);

        //Act & Assert 
        Assert.True(rectangle.Contains(p3));
    }


    [Theory]
    [InlineData(7, 7, 20, 20, 14,-1)]
    [InlineData(3, 3, 10, 10, 12,10)]
    public void ContainsShouldReturnFalse(int x1, int y1, int x2, int y2, int x3, int y3)
    {
        //Arrange
        var p1 = new Point(x1, y1);
        var p2 = new Point(x2, y2);

        var rectangle = new Rectangle(p1, p2);

        var p3 = new Point(x3, y3);
        //Act & Assert
        Assert.False(rectangle.Contains(p3));
    }


    [Theory]
    [InlineData(3,3,20,20, "(3,3):(20,20)")]
    [InlineData(7,7,10,10, "(7,7):(10,10)")]
    public void ToStringShouldReturnCorrectStringRectangleRepresentation(int x1, int y1, int x2, int y2, string expectedstring)
    {
        //Arrange
        var p1 = new Point(x1, y1);
        var p2 = new Point(x2, y2);
        var rectangle = new Rectangle(p1, p2);

        //Act & Assert
        Assert.Equal(expectedstring, rectangle.ToString());
    }

}
