using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public abstract class Creature                   //uwaga dodalam abstract - nie da sie stworzyc ogolnego stwora- innego niz elf czy ork
{
    private string name = "Unknown";           // field
    private int level = 1;                    // field
    private int power;

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

    public /*abstract*/ virtual void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}");              //zastapilam virtual abstraktem

    public void Upgrade()                
    {
        // pozwoli na awansowanie stwora o jeden poziom, ale nie powyzej 10go

        level = Level >= 10 ? Level : Level + 1;    
    }

    public void Go(Direction direction)
    {
        Console.WriteLine($"{Name} goes {direction.ToString().ToLower()}");
    }

    public void Go(Direction[] directions)
    {
        foreach (Direction direction in directions)
        {
            Go(direction);
        }
    }

    public void Go(string expr)
    {
        Direction[] exprs = DirectionParser.Parse(expr);
        Go(exprs);
    }

    public abstract int Power { get; }       // wlasciwosc do odczytu
    //{
      //  get => Power;
    //}



    // przy abstrakcie nie mamy dozwolonej implementacji . abstract wymusza override'a
    // 
    // kazdy obiekt "ma" metode tostring- korzysta z tego console.writeline i dlatego sie nie wywala! 
    // string bazowo zwraca to samo co gettype - jesli dostaniemy w gettype typ elfa to wypisze sie tez simulator.elf 

    // , -15): ... - wyrównuje do 15 char (tutaj akurat :) z lewej strony! 
    // , +15): ... - wyrównuje do 15 char z prawej hihi (chyba tak, ale mialo byc z plusem)
    // typ wartosciowy przerzucamy do obiektu- boxing, w druga strone - unboxing


}
