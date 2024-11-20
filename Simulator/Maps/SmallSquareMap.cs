using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class SmallSquareMap : SmallMap
{
    /*public readonly int Size;
    
    public SmallSquareMap(int size)
    {
        if (size < 5 || size > 20) 
            throw new ArgumentOutOfRangeException("Size of the map is incorrect");
        Size = size;
    }

    // wspolrzedne punktow mapy - (0,0)- (Size-1, Size-1), wspolrzedne nie moga tego przekroczyc

    public override bool Exist(Point p)
    {
        if (p.X <0 || p.X > Size-1 || p.Y <0 || p.Y > Size-1)
            return false;
        else
            return true;
    }*/
    public SmallSquareMap(int size) : base(size, size)
    {

    }


    public override Point Next(Point p, Direction d)
    {
       if (Exist(p.Next(d)))                  //sprawdzamy czy po tym ruchu punkt bedzie nadal nalezal do mapy
            return p.Next(d);
       else
            return p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        if (Exist(p.NextDiagonal(d)))                 //analogicznie
            return p.NextDiagonal(d);
        else
            return p;
    }
}
