using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class BigMap : Map
{

    //List<IMappable>?[,] _fields;
    readonly Dictionary<Point, List<IMappable>> MappablesDict; //= new Dictionary<Point, List<IMappable>>();

    public BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 1000)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "too wide");
        }
        if (sizeY > 1000)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "too high");
        }

        MappablesDict = new Dictionary<Point, List<IMappable>>();
    }

    public override void Add(IMappable mappable, Point position)
    {

        if (!MappablesDict.ContainsKey(position))               //jesli nie zawieral wczesniej takiego klucza
        {
            //MappablesDict[position] = new List<IMappable>[];
            MappablesDict.Add(position, new List<IMappable>());
        }
        MappablesDict[position].Add(mappable);                 //jesli zawieral, to tylko dopisujemy stwora do listy
    }


    public override void Move(IMappable mappable, Point position1, Point position2)
    {
        if (MappablesDict.ContainsKey(position1))
            MappablesDict[position1].Remove(mappable);
        if (!MappablesDict.ContainsKey(position2))
            MappablesDict.Add(position2, new List<IMappable>());
        MappablesDict[position2].Add(mappable);
    }

    public override void Remove(IMappable mappable, Point position)
    {
        if (MappablesDict.ContainsKey(position))
            MappablesDict[position].Remove(mappable);

    }

    public override List<IMappable>? At(Point currentposition)
    {
        if (!MappablesDict.ContainsKey(currentposition))
            return null;
        return MappablesDict[currentposition];
    }

    public override List<IMappable>? At(int x, int y)
    {
        var currentposition = new Point(x, y);
        if (!MappablesDict.ContainsKey(currentposition))
            return null;
        return MappablesDict[currentposition];
    }

    public override Point Next(Point p, Direction d)
    {
        throw new NotImplementedException();
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        throw new NotImplementedException();
    }
}

