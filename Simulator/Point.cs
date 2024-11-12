using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public readonly struct Point
{
    public readonly int X, Y;
    public Point(int x, int y) => (X, Y) = (x, y);
    public override string ToString() => $"({X}, {Y})";

    public Point Next(Direction direction)
    {
        if (direction == Direction.Left)
            return new Point(X-1, Y);
        if (direction == Direction.Right) 
            return new Point(X+1, Y);
        if (direction == Direction.Up) 
            return new Point(X, Y + 1);
        if (direction == Direction.Down)
            return new Point(X, Y - 1);
        else
            return default;
    }
    // enum - jest intem, w kazdej chwili mozemy mu zdefiniowac nowe inty"kierunki") - trzeba rozpatrzyc pozostale randomowe i zwrocic default
    // mozna switchem z returnami lub switch jako expression 

    // rotate given direction 45 degrees clockwise
    public Point NextDiagonal(Direction direction)
    {
        if (direction == Direction.Right)
            return new Point(X+1, Y - 1);
        if (direction == Direction.Down)
            return new Point(X - 1, Y -1);
        if (direction == Direction.Left)
            return new Point(X-1, Y+1);
        if (direction == Direction.Up)
            return new Point(X+1, Y+1);
        else
            return default;
    }
}
