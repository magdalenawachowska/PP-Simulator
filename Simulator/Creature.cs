using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

internal class Creature
{
    private string name;           // field
    private int level;            // field

    public string Name            // property - uzywane potem w konstruktorze !
    {
        get; set;                // short-hand
    }                           
    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    public Creature()             // bezparametrowy konstruktor "nic nie robiacy"
    {   }

    public Creature(string name, int level= 1)         
    {
        Name = name;
        Level = level; 
    }

    public string Info               // wlasciwosc do odczytu 
    {
        get { return $"{Name} [{Level}]"; }
    }

    public void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}");

}
