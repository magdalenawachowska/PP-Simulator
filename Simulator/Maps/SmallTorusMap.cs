using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public int Size { get;}

    public override bool Exist(Point p)
    {
        if (p.X < 0 || p.X > Size - 1 || p.Y < 0 || p.Y > Size - 1)
            return false;
        else
            return true;
    }

    public override Point Next(Point p, Direction d)
    {
        Point p1 = p.Next(d);
        
        if (p1.Y <0 && p1.X >= 0 && p1.X <= Size-1)
        {
            return new Point(p1.X, Size - 1);
        }
        if (p1.Y > Size-1 && p1.X >= 0 && p1.X <=Size-1)
        {
            return new Point(p1.X, 0);
        }
        if (p1.X <0 && p1.Y >= 0 && p1.Y <= Size-1)
        {
            return new Point(Size - 1, p1.Y);
        }
        if (p1.X > Size-1 && p1.Y >= 0 && p1.Y <= Size-1)
        {
            return new Point(0, p1.Y);
        }
        else
            return p1;
            
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point p2 = p.NextDiagonal(d);

        if (p2.Y < 0 && p2.X >= 0 && p2.X < Size - 1)
            return new Point(p2.X, Size - 1);
        if (p2.Y < 0 && p2.X > Size - 1)
            return new Point(0, Size - 1);
        if (p2.Y < 0 && p2.X < 0)
            return new Point(Size - 1, Size - 1);
        if (p2.X > Size - 1 && p2.Y >= 0 && p2.Y < Size - 1)
            return new Point(0, p2.Y);
        if (p2.X < 0 && p2.Y >= 0 && p2.Y < Size - 1)
            return new Point(Size - 1, p2.Y);
        if (p2.Y > Size - 1 && p2.X >= 0 && p2.X < Size - 1)
            return new Point(p2.X, 0);
        if (p2.Y > Size - 1 && p2.X < 0)
            return new Point(Size - 1, 0);
        if (p2.Y > Size - 1 && p2.X > Size - 1)
            return new Point(0, 0);

        return p2;
    }

    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20)
            throw new ArgumentOutOfRangeException("Size of the map is incorrect");
        Size = size;
    }
}
