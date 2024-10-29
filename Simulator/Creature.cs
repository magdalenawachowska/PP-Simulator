using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Creature
{
    private string name = "Unknown";           // field
    private int level = 1;                    // field

    public string Name
    {
        get => name;
        init                                      // init - uzywane zeby wartosc mogla byc nadana tylko raz przy inicjacji
        {
            name = value.Trim();                  // usuwa zbedne spacje
            
            if (name.Length <3)
            {
                name = name.PadRight(3, '#');
            }
            else if (name.Length >25)
            {
                name = name.Substring(0,25);
                name = name.Trim();
                if (name.Length < 3)
                {
                    name = name.PadRight(3, '#');
                }
            }
            name = char.ToUpper(name[0]) + name.Substring(1);      // zamiana pierwszej litery na wielka
        }
    }                                             // property - uzywane potem w konstruktorze !

    public int Level                             // **int na uint- zeby nie bylo ujemnych
    {
        get => level;
        init
        {
            if (value < 1)
                value = 1;
            else if (value > 10)
                value = 10;
            level = value;
        }
                                                 
    }   

    public Creature()                
    {   }

    public Creature(string name, int level=1)         
    {
        Name = name;
        Level = level; 
    }

    public string Info                               // wlasciwosc do odczytu 
    {
        get { return $"{Name} [{Level}]"; }
    }

    public void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}");

    public void Upgrade()                
    {
        // pozwoli na awansowanie stwora o jeden poziom, ale nie powyzej 10go

        level = Level >= 10 ? Level : Level + 1;    
    }
}
