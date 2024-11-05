using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Elf : Creature
{
    private int agility = 1;
    private int sing_count = 0;
    public int Agility
    {
        get => agility;
        init
        {
            if (value < 0)
                value = 0;
            else if (value > 10)
                value = 10;
            agility = value;
        }
    }

    public Elf() : base() { }

    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }

    public void Sing()
    {
        sing_count++;

        if (sing_count % 3 == 0 && sing_count != 0 && agility < 10)
            agility++;

        Console.WriteLine($"{Name} is singing.");
    }
    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}."
    );

    public override int Power => 8 * Level + 2 * Agility;
}
