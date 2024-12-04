using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;

namespace Simulator;

public class Birds : Animals
{
    public bool CanFly { get; set; } = true;

    //public override char Symbol => CanFly ? 'B' : 'b';

    public override string Info               // wlasciwosc do odczytu 
    {
        get { return $"{Description} (fly{(CanFly ? '+' : '-')}) <{Size}>"; }
    }

    public override void Go(Direction direction)
    {
        if (Map != null)
        {
            if (CanFly == false)
            {
                Point newPosition = Map.NextDiagonal(Position, direction);       //directions
                Map.Move(this, Position, newPosition);                 // + ,direction

                Position = newPosition;
            }
            else if (CanFly == true)
            {
                Point newPosition = Map.Next(Position, direction);       //directions
                Point newBirdPosition = Map.Next(newPosition, direction);   

                Map.Move(this, Position, newBirdPosition);                 // + ,direction

                Position = newBirdPosition;
            }
        }
        else
            throw new ArgumentNullException("Select a map");
    }

}
