using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;

namespace SimConsole;

public class MapVisualizer
{
    private readonly Map _map;

    public MapVisualizer(Map map)
    {
        _map = map;
    }

    public string MappableIdentification(int x, int y)
    {
        List<IMappable> found = _map.At(x, y);
        if (found != null && found.Count() != 0)
        {

            if (found.Count > 1)
                return "X";
            /*
            else if (found[0].GetType() == typeof(Elf))
                return "E";
            else if (found[0].GetType() == typeof(Orc))
                return "O";
            else if (found[0].GetType() == typeof(Animals))
                return "A";
            else if (found[0].GetType() == typeof(Birds))
                return "B";*/
            else
                return found[0].Symbol.ToString();
        }
        return " ";

    }

    public void Draw()
    {
        Console.WriteLine();
        Console.Write(Box.TopLeft);
        for (int i = 0; i < _map.SizeX - 1; i++)
        {
            Console.Write(Box.Horizontal);
            Console.Write(Box.TopMid);
        }
        Console.Write(Box.Horizontal);
        Console.Write(Box.TopRight);
        Console.WriteLine();

        for (int y = _map.SizeY - 1; y >= 0; y--)
        {
            for (int x = 0; x <= _map.SizeX - 1; x++)
            {
                Console.Write(Box.Vertical);
                Console.Write(MappableIdentification(x,y));
            }
            Console.Write(Box.Vertical);
            Console.WriteLine();


            if (y > 0)
            {
                Console.Write(Box.MidLeft);
                for (int i = 0; i < _map.SizeX - 1; i++)
                {
                    Console.Write(Box.Horizontal);
                    Console.Write(Box.Cross);
                }
                Console.Write(Box.Horizontal);
                Console.Write(Box.MidRight);
                Console.WriteLine();
            }

        }
     
        Console.Write(Box.BottomLeft);
        for (int i = 0; i < _map.SizeX - 1; i++)
        {
            Console.Write(Box.Horizontal);
            Console.Write(Box.BottomMid);
        }
        Console.Write(Box.Horizontal);
        Console.Write(Box.BottomRight);
        Console.WriteLine();
    }

}

