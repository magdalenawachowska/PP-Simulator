using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public static class Validator
{
    public static int Limiter(int value, int min, int max)
    {
        if (value < min)
            return min;
        else if (value > max) 
            return max;
        else return value;
    }

    public static string Shortener(string value, int min, int max, char placeholder)
    {
        value = value.Trim();                                   //usuwa zbedne spacje

        if (value.Length < min)
        {
            value = value.PadRight(min, placeholder);          //placeholder- zastepuje brakujace miejsca danym symbolem
        }
        else if (value.Length > max)
        {
            value = value.Substring(0, max);
            value = value.Trim();
            if (value.Length < min)
            {
                value = value.PadRight(min, placeholder);
            }
        }
        return value = char.ToUpper(value[0]) + value.Substring(1);

    }

}
