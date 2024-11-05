﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Birds : Animals
{
    public bool CanFly { get; set; } = true;

    public override string Info               // wlasciwosc do odczytu 
    {
        get { return $"{Description} (fly{(CanFly ? '+' : '-')}) <{Size}>"; }
    }


}
