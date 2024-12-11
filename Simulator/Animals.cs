using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public class Animals : IMappable            
{
    //public override char Symbol => 'A';
    public virtual string Symbol { get { return "A"; } }

    private string description = "Unknown";
    public required string Description                                  
    { 
        get => description;
        set => description = Validator.Shortener(value, 3, 15, '#');
    }
    public uint Size { get; set; } = 3;

    public virtual string Info               // wlasciwosc do odczytu 
    {
        get { return $"{Description} <{Size}>"; }
    }


    public Point Position { get; protected set; }
    public Map? Map { get; private set; }

    public virtual void Go(Direction direction)
    {
        if (Map != null)
        {
            Point newPosition = Map.Next(Position, direction);       //directions
            //Console.WriteLine(newPosition.ToString());

            Map.Move(this, Position, newPosition);                 // + ,direction

            Position = newPosition;
        }
        else
            throw new ArgumentNullException("Select a map");
    }

    public void InitMapAndPosition(Map map, Point position) 
    {
        if (Map != null)
            throw new InvalidOperationException($"{Description} is currently on a map.");

        //if (!map.Exist(position))
        //    throw new ArgumentException($"{position} is out of range of the map");


        Map = map;
        Position = position;

        Map.Add(this, position);
    }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}
