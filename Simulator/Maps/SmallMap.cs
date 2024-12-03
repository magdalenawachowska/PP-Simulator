using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{

    List<IMappable>?[,] _fields;                  // tablica 2d, dopuszczamy nulla 



    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {

        if (sizeX > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "too wide");
        }
        if (sizeY > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "too high");
        }


        _fields = new List<IMappable>?[sizeX, sizeY];

    }

    public override void Add(IMappable mappable, Point position)
    {
        if (_fields[position.X,position.Y] == null)
        {
            _fields[position.X, position.Y] = new List<IMappable>();
        }
        _fields[position.X, position.Y]?.Add(mappable);
    }

    public override void Remove(IMappable mappable, Point position)
    {
        _fields[position.X, position.Y]?.Remove(mappable);
    }

    public override void Move(IMappable mappable, Point position1, Point position2)
    {
        _fields[position1.X, position1.Y]?.Remove(mappable);
        if (_fields[position2.X, position2.Y] == null)
            _fields[position2.X, position2.Y] = new List<IMappable>();

        _fields[position2.X, position2.Y]?.Add(mappable);
    }

    public override List<IMappable>? At(Point currentposition)
    {
        return _fields[currentposition.X, currentposition.Y];
    }

    public override List<IMappable>? At(int x, int y)
    {
        return _fields[x,y];
    }
}