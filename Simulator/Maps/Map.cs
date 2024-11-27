using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;                 

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public int SizeX { get; }
    public int SizeY { get; }

    private readonly Rectangle _map;


    protected Map (int sizeX, int sizeY)
    {
        if (sizeX < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "too narrow");
        }
        if (sizeY <5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "too short");
        }
        SizeX = sizeX;
        SizeY = sizeY;
        _map = new Rectangle(0,0, SizeX-1, SizeY-1);
    }

    public abstract void Add(Creature creature, Point position);                              //dodanie stwora na jakas pozycje
    public abstract void Remove(Creature creature, Point position);                            //zabranie stwora z danego punktu

    public abstract void Move(Creature creature, Point position1, Point position2);           // przeniesienie stwora miedzy dwoma punktami

    public abstract List<Creature>? At(Point currentposition);                        //sprawdzenie jakie stwory sa w danym punkcie
    //public List<Creature>? At( int x, int y) => At(new Point(x,y));
    public abstract List<Creature> At(int x, int y);

    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p) => _map.Contains(p);

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);
}
