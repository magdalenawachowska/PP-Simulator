using Simulator.Maps;
using System;
using System.ComponentModel;
using System.Numerics;
using System.Security.Cryptography;

namespace Simulator;

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
    static void Lab4b()
    {
        object[] myObjects = {
        new Animals() { Description = "dogs"},
        new Birds { Description = "  eagles ", Size = 10 },
        new Elf("e", 15, -3),
        new Orc("morgash", 6, 4)
    };
        Console.WriteLine("\nMy objects:");
        foreach (var o in myObjects) Console.WriteLine(o);
        /*
            My objects:
            ANIMALS: Dogs <3>
            BIRDS: Eagles (fly+) <10>
            ELF: E## [10][0]
            ORC: Morgash [6][4]
        */
    }

    static void Lab5a()
    {
        Console.WriteLine("Rectangles test \n");

        Point p1 = new(1, 2);
        Point p2 = new(6, 7);
      
        Rectangle rec1 = new(p1, p2);                                               //poprawnie zbudowany prostokat z punktow

        Point p3 = new(10, 12);
        Point p4 = new(4, 6); 

        Rectangle rec2 = new(p3, p2);                                               // prostokat zbudowany z punktow podanych na odwrot 

        Point p5 = new(5, 7);
        try
        {
            Console.WriteLine($"Prostokat zbudowany z punktow współliniowych:");
            Rectangle rec3 = new(p5, p2);                                          // prostokat zbudowany z punktow współliniowych

            Console.WriteLine(rec3);
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
        finally
        {
            Console.WriteLine("Sprawdzono prostokąt o punktach współliniowych.\n");
        }
         
        Rectangle rec4 = new(3, 1, 9, 7);                                         // prostokat zbudowany poprawnie z wspolrzednych
        Rectangle rec5 = new(10, 10, 1, 1);

        Console.WriteLine($"Prostokąt zbudowany z prawidłowych punktów: {rec1}");
        Console.WriteLine($"Prostokat zbudowany z punktow podanych na odwrót {rec2}");
        
        Console.WriteLine($"Prostokat zbudowany poprawnie z współrzędnych: {rec4}");
        Console.WriteLine($"Prostokat zbudowany z współrzędnych podanych na odwrót: {rec5}");

        try
        {
            Console.WriteLine($"\nProstokat zbudowany z współrzędnych współliniowych:");
            Rectangle rec6 = new(2, 2, 2, 6);

            Console.WriteLine(rec6);
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
        finally
        {
            Console.WriteLine("Sprawdzono prostokąt o współrzędnych współliniowych.\n");
        }

        Console.WriteLine($"\nSprawdzam zawieranie się w prostokącie {rec4}:\n punktu {p3}: {rec4.Contains(p3)}\n punktu {p4}: {rec4.Contains(p4)}");
        
    }

    static void Lab5b()
    {
        Console.WriteLine("SmallSquareMap test \n");

        int size = 7;
        SmallSquareMap map1 = new (size);

        Point p1 = new(2, 2);
        Point p2 = new(-2, -2);

        Console.WriteLine($"Sprawdzam, czy punkt {p2} należy do mapy: \n{map1.Exist(p2)}");

        try
        {
            Console.WriteLine($"Punkt {p1} należący do mapy- kolejne przemieszczenia: \n");

            p1 = map1.Next(p1, Direction.Up);
            p1 = map1.NextDiagonal(p1, Direction.Up);
            Console.WriteLine(p1);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            SmallSquareMap map2 = new SmallSquareMap(1);
            Console.WriteLine("Podano za mały rozmiar mapy.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator! \n");

        //Lab5a();
        Lab5b();

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


    // exception- klasa bazowa dla wszystkich bledow- zawiera informacje o bledzie, potem dajemy nazwe zmiennej, przed dajemy catch -- catch (Exception excpt) 
    // blok finally - wykonuje sie zawsze, niezaleznie od bledu , mozna pominac tez catcha xd ale po co..
    // throw exception
    // try { throw ...Exception ("....")   }
}
