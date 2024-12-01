using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{

    List<Creature>?[,] _fields;                  // tablica 2d, dopuszczamy nulla 



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


        _fields = new List<Creature>?[sizeX, sizeY];

    }

    public override void Add(Creature creature, Point position)
    {
        if (_fields[position.X,position.Y] == null)
        {
            _fields[position.X, position.Y] = new List<Creature>();
        }
        _fields[position.X, position.Y]?.Add(creature);
    }

    public override void Remove(Creature creature, Point position)
    {
        _fields[position.X, position.Y]?.Remove(creature);
    }

    public override void Move(Creature creature, Point position1, Point position2)
    {
        _fields[position1.X, position1.Y]?.Remove(creature);
        if (_fields[position2.X, position2.Y] == null)
            _fields[position2.X, position2.Y] = new List<Creature>();

        _fields[position2.X, position2.Y]?.Add(creature);
    }

    public override List<Creature>? At(Point currentposition)
    {
        return _fields[currentposition.X, currentposition.Y];
    }

    public override List<Creature>? At(int x, int y)
    {
        return _fields[x,y];
    }
}