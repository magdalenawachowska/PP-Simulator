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
        set => name = Validator.Shortener(value, 3, 25, '#');
    }

    public int Level                          
    {
        get => level;
        set => level = Validator.Limiter(value, 1, 10);                                          
    }   

    public Creature()                
    {   }

    public Creature(string name, int level=1)         
    {
        Name = name;
        Level = level; 
    }

    public abstract string Info { get; }                               // wlasciwosc do odczytu
                                                                       //{
                                                                      //get { return $"{Name} [{Level}]"; }
                                                                      //}
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

    public abstract void SayHi(); // => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}");              //zastapilam virtual abstraktem

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
