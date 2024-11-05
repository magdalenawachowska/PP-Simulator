﻿namespace Simulator;

internal class Program
{

    static void Lab4a()
    {
        Console.WriteLine("HUNT TEST\n");
        var o = new Orc() { Name = "Gorbag", Rage = 7 };
        o.SayHi();
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
            o.SayHi();
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("Legolas", agility: 2);
        e.SayHi();
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
            e.SayHi();
        }

        Console.WriteLine("\nPOWER TEST\n");
        Creature[] creatures = {
        o,
        e,
        new Orc("Morgash", 3, 8),
        new Elf("Elandor", 5, 3)
    };
        foreach (Creature creature in creatures)
        {
            Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator! \n");

        Lab4a();
      

        

        /*
        ((Elf)e).Sing();                  // rzutowanie - tworzac elfa z creature nie mamy dostepu do metod z klasy elfy xd - jawna konwersja typow

        //((Elf)o).Sing();               // uwaga na cos takiego! kompilator nie da rady tego sprawdzic, moze sie wysypac potem- runtime error

        (o as Elf)?.Sing();           // bezpieczne wyjscie - jesli orch nie jest elfem to wyrazenie bedzie nullem i nic sie nie wydarzy

        if (o is Elf) (o as Elf)?.Sing();               // jesli nie jest elfem to robi nulla i nie idzie dalej, nie skompiluje sie bo bedziemy po ifie
        else Console.WriteLine($"{o.Name} is not Elf!");

        if (o is Elf elf) elf.Sing();               // 
        else Console.WriteLine($"{o.Name} is not Elf!");
        */
        

    }

    /*static void Lab3a() 
{
    Creature c = new() { Name = "   Shrek    ", Level = 20 };
    c.SayHi();
    c.Upgrade();
    Console.WriteLine(c.Info);

    c = new("  ", -5);
    c.SayHi();
    c.Upgrade();
    Console.WriteLine(c.Info);

    c = new("  donkey ") { Level = 7 };
    c.SayHi();
    c.Upgrade();
    Console.WriteLine(c.Info);

    c = new("Puss in Boots – a clever and brave cat.");
    c.SayHi();
    c.Upgrade();
    Console.WriteLine(c.Info);

    c = new("a                            troll name", 5);
    c.SayHi();
    c.Upgrade();
    Console.WriteLine(c.Info);

    var a = new Animals() { Description = "   Cats " };
    Console.WriteLine(a.Info);

    a = new() { Description = "Mice           are great", Size = 40 };
    Console.WriteLine(a.Info);
}
static void Lab3b()
{
    Creature c = new("Shrek", 7);
    c.SayHi();

    Console.WriteLine("\n* Up");
    c.Go(Direction.Up);

    Console.WriteLine("\n* Right, Left, Left, Down");
    Direction[] directions = {
    Direction.Right, Direction.Left, Direction.Left, Direction.Down
};
    c.Go(directions);

    Console.WriteLine("\n* LRL");
    c.Go("LRL");

    Console.WriteLine("\n* xxxdR lyyLTyu");
    c.Go("xxxdR lyyLTyu");
} */

}
