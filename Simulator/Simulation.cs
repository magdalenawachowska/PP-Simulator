using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Simulation
{

    int mappableIndex  = 0;           
    int movesIndex = 0;
    int turnCount = 1;

    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// IMappables moving on the map.
    /// </summary>
    public List<IMappable> Mappables { get; }

    /// <summary>
    /// Starting positions of mappables.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of mappables moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first mappable, second for second and so on.
    /// When all mappables make moves, 
    /// next move is again for first mappable and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// IMappable which will be moving current turn.
    /// </summary>
    public IMappable CurrentMappable { get => Mappables[mappableIndex]; }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName { get => Moves[movesIndex].ToString(); }        

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if mappables' list is empty,
    /// if number of mappables differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> mappables,
        List<Point> positions, string moves)
    {
        if (mappables == null)
            throw new ArgumentNullException("List of mappables is empty");

        if (mappables.Count != positions.Count)
            throw new ArgumentException("Number of mappables doesn't match the number of starting positions");

        Map = map;
        Mappables = mappables;
        Positions = positions;
        //Moves = moves;

        for (int i = 0; i < mappables.Count; i++)
        {
            Mappables[i].InitMapAndPosition(Map, Positions[i]);
        }

        Moves = moves;
    
    }

/// <summary>
/// Makes one move of current mappable in current direction.
/// Throw error if simulation is finished.
/// </summary>
    public void Turn()
    { 
        if (Finished)
            throw new Exception("Simulation is finished");

        string _moveName = " ";

        switch (CurrentMoveName)
        {
            case "u":
                    _moveName = "Up";
                break;
            case "d":
                _moveName = "Down";
                break;
            case "l":
                _moveName = "Left";
                break;
            case "r":
                _moveName = "Right";
                break;

            default: _moveName = CurrentMoveName; break;
        }

        Console.WriteLine($"Turn {turnCount}:");
        Console.WriteLine($"{CurrentMappable.ToString()} goes {_moveName}");

        CurrentMappable.Go(DirectionParser.Parse(CurrentMoveName).First());

        //Console.WriteLine($"{CurrentMappable.ToString()} is at..."); // {CurrentMappable.Position}");
        //Console.WriteLine(DirectionParser.Parse(CurrentMoveName).First());
        mappableIndex++;
        movesIndex++;
        turnCount++;
        if (mappableIndex >= Mappables.Count())
            mappableIndex = 0;

        if (movesIndex >= Moves.Count())
            Finished = true;
    

    }


}
