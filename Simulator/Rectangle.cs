using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Rectangle
{
    public readonly int X1, Y1;   //wspolrzedne lewego dolnego naroznika
    public readonly int X2, Y2;   // wspolrzedne prawego gornego naroznika

    public Rectangle(int x1, int y1, int x2, int y2)
    {
        X1 = x1;
        Y1 = y1;
        X2 = x2;
        Y2 = y2;
     
        if (x1 == x2 || y1 == y2)
        {
            throw new ArgumentException("Podano nieprawidlowe wartosci- nie mozna utworzyc prostokata\n");    // to create  a custom error
        }

        if (x1 > x2)                              //zamiana rogow jesli podane w zlej kolejnosci
        {
            if (y1 > y2)
            {
                X1 = x2;
                Y1 = y2;
                X2 = x1;
                Y2 = y1;
            }
            else
            {
                X1 = x2;
                Y1 = y1;
                X2 = x1;
                Y2 = y2;
            }                                                         
        }                                                       
        else
        {
            if ( y1 > y2)
            {
                X1 = x1;
                Y1 = y2;
                X2 = x2;
                Y2 = y1;
            }

            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }
    }

    public Rectangle(Point p1, Point p2) : this (p1.X,p1.Y, p2.X, p2.Y)
    {
    }

    public bool Contains(Point point)                    //sprawdzenie czy punkt nalezy do prostokata
    {
    if (point.X >= X1 && point.X <= X2)                     
        if (point.Y >= Y1 && point.Y <= Y2)
            return true;
    return false;
    }
    public override string ToString()
    {
        return $"({X1},{Y1}):({X2},{Y2})";
    }
}
