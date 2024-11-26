using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallTorusMap : SmallMap
{
    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    { 
    
    }

    public override Point Next(Point p, Direction d)
    {
        Point p1 = p.Next(d);
        
        if (p1.Y <0 && p1.X >= 0 && p1.X <= SizeX-1)
        {
            return new Point(p1.X, SizeY - 1);
        }
        if (p1.Y > SizeY-1 && p1.X >= 0 && p1.X <=SizeX-1)
        {
            return new Point(p1.X, 0);
        }
        if (p1.X <0 && p1.Y >= 0 && p1.Y <= SizeY-1)
        {
            return new Point(SizeX - 1, p1.Y);
        }
        if (p1.X > SizeX-1 && p1.Y >= 0 && p1.Y <= SizeY-1)
        {
            return new Point(0, p1.Y);
        }
        else
            return p1;
            
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point p2 = p.NextDiagonal(d);

        if (p2.Y < 0 && p2.X >= 0 && p2.X < SizeX - 1)
            return new Point(p2.X, SizeY - 1);
        if (p2.Y < 0 && p2.X > SizeX - 1)
            return new Point(0, SizeY - 1);
        if (p2.Y < 0 && p2.X < 0)
            return new Point(SizeX - 1, SizeY - 1);
        if (p2.X > SizeX - 1 && p2.Y >= 0 && p2.Y < SizeY - 1)
            return new Point(0, p2.Y);
        if (p2.X < 0 && p2.Y >= 0 && p2.Y < SizeY - 1)
            return new Point(SizeX - 1, p2.Y);
        if (p2.Y > SizeY - 1 && p2.X >= 0 && p2.X < SizeX - 1)
            return new Point(p2.X, 0);
        if (p2.Y > SizeY - 1 && p2.X < 0)
            return new Point(SizeX - 1, 0);
        if (p2.Y > SizeY - 1 && p2.X > SizeX - 1)
            return new Point(0, 0);

        return p2;
    }
}
