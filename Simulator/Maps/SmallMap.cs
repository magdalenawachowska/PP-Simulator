using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{

    // List<Creature>? [,] _fields;                  // tablica 2d, dopuszczamy nulla 



    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {

        if (sizeX >20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "too wide");   
        }
        if (sizeY > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "too high");
        }

        
       //_fields = new List<Creature>?[sizeX, sizeY];                


    }

}