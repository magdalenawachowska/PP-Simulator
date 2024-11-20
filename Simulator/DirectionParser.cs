using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Simulator;

public static class DirectionParser
{
    public static List<Direction> Parse(string expression)
    {
        var directions = new List<Direction>();

        expression = expression.Trim().ToLower();

        foreach (var charac in expression)
        {
            switch (charac.ToString())
            {
                case "u":
                    directions.Add(Direction.Up);
                    break;
                case "r":
                    directions.Add(Direction.Right);
                    break;
                case "d":
                    directions.Add(Direction.Down);
                    break;
                case "l":
                    directions.Add(Direction.Left);
                    break;
                default:
                    break;
            }
        }

        return directions;
    }
}
