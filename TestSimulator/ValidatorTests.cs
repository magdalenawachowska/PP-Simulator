using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(-1,0,10, 0)]
    [InlineData(200,0,10, 10)]
    [InlineData(8,0,10,8)]
    public void LimiterShouldReturnValidValue(int value, int min, int max, int expectedvalue)
    {
        //Arrange
        var testvalue = Validator.Limiter(value, min, max);
        //Act & Assert
        Assert.Equal(testvalue, expectedvalue);
    }

    [Theory]
    [InlineData("Legolas", 3, 15, '#',"Legolas")]
    [InlineData("xd", 3, 15, '#', "Xd#")]
    [InlineData("mojeimie           jestzadlugie", 3,15, '#', "Mojeimie")]
    [InlineData("", 3,15, '#', "###")]
    public void ShortenerShouldReturnValidString(string value, int min, int max, char placeholder, string expectedvalue)
    {
        //Arrange
        var testvalue = Validator.Shortener(value, min, max, placeholder);
        //Act & Assert
        Assert.Equal(testvalue, expectedvalue);

    }
}
