using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class BigBounceMap : BigMap
{
    public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
    }
    public override Point Next(Point p, Direction d)
    {
        
        Point p1 = p.Next(d);

        if (p1.Y <0 && p1.X >= 0 && p1.X <= SizeX - 1)                         //y za maly(<0), x w normie- odbijamy go do gory
        {
            return new Point(p1.X, 1);                                             // x pozostaje, y na 1 od dolu
        }
        if (p1.Y > SizeY - 1 && p1.X >= 0 && p1.X <= SizeX - 1)                //y wyjdzie poza do gory, x w normie
        {
            return new Point(p1.X, SizeY-2);                                      //x pozostaje, y na 1 od gory
        }
        if (p1.X < 0 && p1.Y >= 0 && p1.Y <= SizeY - 1)                        //x za bardzo na lewo, y w normie
        {
            return new Point(1, p1.Y);                                            //x dajemy na 1, y pozostaje
        }
        if (p1.X > SizeX - 1 && p1.Y >= 0 && p1.Y <= SizeY - 1)               //x wyjdzie poza w prawo, y w normie
        {
            return new Point(SizeX-2, p1.Y);                                      //x na 1 od boku, y pozostaje
        }
        else
            return p1;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        //pamietajmy ze sie odbijamy od tej mapy paskudnej

        Point p1 = p.NextDiagonal(d);

        if (p1.Y < 0 && p1.X >= 0 && p1.X <= SizeX - 1)                         //y za maly(<0), x w normie
        {
            if (d == Direction.Right)
                if (Exist(new Point(p1.X - 2, 1)))
                    return new Point(p1.X - 2, 1);
                else
                    return p;
            if (d == Direction.Down)
                if (Exist(new Point(p1.X + 2, 1)))
                    return new Point(p1.X + 2, 1);
                else
                    return p;  
        }
        if (p1.Y < 0 && p1.X < 0)                                             //y wyjdzie poza do dolu w lewo - musial dostac downa
        {
                return new Point(p1.X + 2, 1);
        }
        if (p1.Y < 0 && p1.X > SizeX-1)                                     //y wyjdzie poza do dolu w prawo - musial dostac right'a
        {
            return new Point(p1.X-2, 1);
        }

        if (p1.Y > SizeY - 1 && p1.X >= 0 && p1.X <= SizeX - 1)                //y wyjdzie poza do gory, x w normie
        {
            if (d == Direction.Left)
                if (Exist(new Point(p1.X + 2, SizeY - 2)))
                    return new Point(p1.X + 2, SizeY - 2);
                else
                    return p;
            if (d == Direction.Up)
                if (Exist(new Point(p1.X - 2, SizeY - 2)))
                    return new Point(p1.X - 2, SizeY - 2);
                else
                    return p; 
        }
        if (p1.Y > SizeY - 1 && p1.X > SizeX - 1)                //y wyjdzie poza do gory w prawo - musial dostac up'a
        {
                return new Point(p1.X - 2, SizeY - 2);
        }
        if (p1.Y > SizeY - 1 && p1.X < 0)                        //y wyjdzie poza do gory w lewo - musial dostac left'a
        {
            return new Point(p1.X+ 2, SizeY - 2);
        }

        if (p1.X < 0 && p1.Y >= 0 && p1.Y <= SizeY - 1)                        //x za bardzo na lewo, y w normie
        {
            if (d == Direction.Left)
                if (Exist(new Point(1, p1.Y - 2)))
                    return new Point(1, p1.Y - 2);
                else
                    return p;
            if (d == Direction.Down)
                if (Exist(new Point(1, p1.Y + 2)))
                    return new Point(1,p1.Y+2);
                else
                    return p;
        }
        if (p1.X > SizeX - 1 && p1.Y >= 0 && p1.Y <= SizeY - 1)               //x wyjdzie poza w prawo, y w normie
        {
            if (d == Direction.Up)
                if (Exist(new Point(SizeX - 2, p1.Y - 2)))
                    return new Point(SizeX - 2, p1.Y-2);
                else
                    return p;
            if (d == Direction.Right)
                if (Exist(new Point(SizeX - 2, p1.Y + 2)))
                    return new Point(SizeX-2, p1.Y+2);
                else
                    return p;
        }
        else
            return p1;

        return default;

    }

}
