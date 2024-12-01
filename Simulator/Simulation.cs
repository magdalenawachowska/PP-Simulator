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

    int creatureIndex  = 0;           
    int movesIndex = 0;

    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature { get => Creatures[creatureIndex]; }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName { get => Moves[movesIndex].ToString(); }        

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
    {
        if (creatures == null)
            throw new ArgumentNullException("List of creatures is empty");

        if (creatures.Count != positions.Count)
            throw new ArgumentException("Number of creatures doesn't match the number of starting positions");

        Map = map;
        Creatures = creatures;
        Positions = positions;
        //Moves = moves;

        for (int i = 0; i < creatures.Count; i++)
        {
            Creatures[i].InitMapAndPosition(Map, Positions[i]);
        }

        Moves = moves;
    
    }

/// <summary>
/// Makes one move of current creature in current direction.
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

        Console.WriteLine($"{CurrentCreature.Name} goes {_moveName}");

        CurrentCreature.Go(DirectionParser.Parse(CurrentMoveName).First());

        Console.WriteLine($"{CurrentCreature.Name} is at {CurrentCreature.Position}");
        //Console.WriteLine(DirectionParser.Parse(CurrentMoveName).First());
        creatureIndex++;
        movesIndex++;
        if (creatureIndex >= Creatures.Count())
            creatureIndex = 0;

        if (movesIndex >= Moves.Count())
            Finished = true;
    

    }


}
