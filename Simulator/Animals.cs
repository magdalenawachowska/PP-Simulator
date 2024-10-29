using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public class Animals             
{

    private string description = "Unknown";
    public required string Description
    { 
        get => description; 
        init
        {
            description = value.Trim();                  // usuwa zbedne spacje

            if (description.Length < 3)
            {
                description = description.PadRight(3, '#');
            }
            else if (description.Length > 15)
            {
                description = description.Substring(0, 15);
                description = description.Trim();
                if (description.Length < 3)
                {
                    description = description.PadRight(3, '#');
                }
            }
            description = char.ToUpper(description[0]) + description.Substring(1);
        }
    }
    public uint Size { get; set; } = 3;

    public string Info               // wlasciwosc do odczytu 
    {
        get { return $"{Description} <{Size}>"; }
    }

}
