using Simulator;
using Simulator.Maps;
using System.Linq.Expressions;

namespace SimConsole;

public class Program
{
    static void Main(string[] args)
    { 
        Console.WriteLine("SIMULATION \n");

        /*
        SmallSquareMap map = new(6);
        List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = [new(2, 2), new(3, 1)];
        string moves = "dlrludl";
        //string moves = "urudld";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);
        mapVisualizer.Draw();

        foreach (var charac in moves)
        {
            Console.WriteLine("Press any key to continue...\n");
            Console.ReadLine();
            simulation.Turn();

            mapVisualizer.Draw();
        }

        Console.WriteLine("Simulation ended. Press any key to quit..\n");
        Console.ReadLine();
        */

        SmallTorusMap map2 = new(8, 6);
        List<IMappable> mappables2 = [new Elf("Legolas"), new Orc("Georg"), new Animals() { Description = "Króliki"},
            new Birds() { Description = "Orły", CanFly=true}, new Birds() { Description= "Strusie", CanFly=false}];
        List<Point> points2 = [new(2, 2), new(3, 2), new(4,3), new(5,2), new(4,4)];
        string moves2 = "dlrludlrrudldlu";

        Simulation simulation2 = new(map2, mappables2, points2, moves2);
        MapVisualizer mapVisualizer2 = new(simulation2.Map);
        Console.WriteLine("Starting positions: ");
        mapVisualizer2.Draw();

        foreach (var charac in moves2)
        {
            Console.WriteLine("Press any key to continue...\n");
            Console.ReadLine();
            simulation2.Turn();

            mapVisualizer2.Draw();
        }

        Console.WriteLine("Simulation ended. Press any key to quit..\n");
        Console.ReadLine();
    }
}
