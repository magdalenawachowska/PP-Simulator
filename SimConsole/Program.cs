using Simulator;
using Simulator.Maps;
using System.Linq.Expressions;

namespace SimConsole;

public class Program
{
    static void Main(string[] args)
    { 
        Console.WriteLine("SIMULATION \n");

        SmallSquareMap map = new(6);
        List<IMappable> mappables = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = [new(2, 2), new(3, 1)];
        string moves = "dlrludl";
        //string moves = "urudld";

        Simulation simulation = new(map, mappables, points, moves);
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

    }
}
