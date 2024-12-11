using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;

namespace Simulator;

public abstract class Creature : IMappable                       //uwaga dodalam abstract - nie da sie stworzyc ogolnego stwora- innego niz elf czy ork
{
    public Map? Map { get; private set; }
    public Point Position { get; private set; }

    public abstract string Symbol { get; }

    public void InitMapAndPosition(Map map, Point position)           //wybranie mapy dla stwora i ustawienie pozycji
    {
        if (Map != null)
            throw new InvalidOperationException($"{Name} is currently on a map.");

        if (!map.Exist(position))
            throw new ArgumentException($"{position} is out of range of the map");


        Map = map;
        Position = position;

        Map.Add(this, position);
    }

    private string name = "Unknown";           // field
    private int level = 1;                    // field
    private int power;

    public string Name
    {
        get => name;
        init => name = Validator.Shortener(value, 3, 25, '#');
    }

    public int Level                          
    {
        get => level;
        init => level = Validator.Limiter(value, 1, 10);                                          
    }

    public abstract int Power { get; }       // wlasciwosc do odczytu

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

    public abstract string Greeting(); // => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}");              //zastapilam virtual abstraktem

    public void Upgrade()                
    {
        // pozwoli na awansowanie stwora o jeden poziom, ale nie powyzej 10go

        level = Level >= 10 ? Level : Level + 1;    
    }

    /*public string Go(Direction direction)
    {

        // ma uzyc regul mapy - przy pomocy metody next mapy sprawdzic jaki nastepny punkt, nie musimy sprawdzac czy exist bo mapa sama zwrocila istniejacy
        // trzeba sprawdzic czy to nie jest ten na ktorym juz jestesmy tylko 
        return $"{direction.ToString().ToLower()}";
    }*/
    
    // potem usuwac to hurtowe chodzenie  xdd ale tak schludnie to zrobic
    /*public string[] Go(Direction[] directions)
    {
        var result = new string[directions.Length];

        for (int i = 0; i<directions.Length; i++)
        {
            result[i] = Go(directions[i]);
        }
        
        return result ;
    }*/

    public void Go(Direction directions)
    {
        /*
        if (Map != null)
        {
            Point newPosition = Map.Next(Position, directions);
            //Console.WriteLine(newPosition.ToString());

            Map.Move(this, Position, newPosition);
            
            Position = newPosition;
        }
        else
            throw new ArgumentNullException("Select a map");
        */ 
        directions.ToString().ToLower();
        var newPosition = Map.Next(Position, directions);
        Map.Move(this, Position, newPosition);
        Position = newPosition;

    }

    //public string[] Go(string expr) => Go(DirectionParser.Parse(expr));
             
    /*
    {
        Direction[] exprs = DirectionParser.Parse(expr);
        Go(exprs);
    }*/

    // przy abstrakcie nie mamy dozwolonej implementacji . abstract wymusza override'a
    // 
    // kazdy obiekt "ma" metode tostring- korzysta z tego console.writeline i dlatego sie nie wywala! 
    // string bazowo zwraca to samo co gettype - jesli dostaniemy w gettype typ elfa to wypisze sie tez simulator.elf 

    // , -15): ... - wyrównuje do 15 char (tutaj akurat :) z lewej strony! 
    // , +15): ... - wyrównuje do 15 char z prawej hihi (chyba tak, ale mialo byc z plusem)
    // typ wartosciowy przerzucamy do obiektu- boxing, w druga strone - unboxing


}
