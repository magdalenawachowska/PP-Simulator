using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Orc : Creature 
{
    private int rage = 1;
    private int hunt_count = 0;

    public int Rage
    {
       get => rage;
       set => rage = Validator.Limiter(value, 0, 10);
    }
    public void Hunt()
    {
        hunt_count++;

        if (hunt_count % 2 == 0 && hunt_count != 0 && rage < 10)
            rage++;

        Console.WriteLine($"{Name} is hunting.");
    }
    public Orc() : base() { }          //    -pusty konstruktor bezparametrowy                                

    public Orc(string name, int level = 1, int rage = 1) : base(name, level)       // po doklejeniu tego konstruktora "znika" bezparametrowy domyslny, dziedziczony z klasy bazowej
    {
        Rage = rage;
    }

    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");

    public override int Power => 7 * Level + 3 * Rage;

    public override string Info                              
    {
        get { return $"{Name} [{Level}] [{Rage}]"; }
    }

}
