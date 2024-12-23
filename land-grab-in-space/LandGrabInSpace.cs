using System;
using System.Collections.Generic;
using System.Linq;

public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
}

public struct Plot
{
    private Coord west { get; }
    private Coord north { get; }
    private Coord east { get; }
    private Coord south { get; }


    public Plot(Coord west, Coord north, Coord east, Coord south)
    {
        this.west = west;
        this.north = north;
        this.south = south;
        this.east = east;
    }

    private double SideCalc(Coord point1, Coord point2)
    {
        return Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
    }

    public double LongestSide()
    {
        var allSides = new List<double>();
        allSides.Add(SideCalc(west, north));
        allSides.Add(SideCalc(east, north));
        allSides.Add(SideCalc(west, south));
        allSides.Add(SideCalc(east, south));

        return allSides.Max();
    }

    private bool Equals(Plot pi) => pi.GetHashCode() == base.GetHashCode();
    
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        return base.Equals(obj);
    }

    public override int GetHashCode() => base.GetHashCode();
    
}


public class ClaimsHandler
{
    static List<Plot> claimBase = new List<Plot>();
    public void StakeClaim(Plot plot) => claimBase.Add(plot);
    
    public bool IsClaimStaked(Plot plot) => claimBase.Contains(plot);
    
    public bool IsLastClaim(Plot plot) => claimBase.Last().Equals(plot);
    
    public Plot GetClaimWithLongestSide()
    {
        var biggest = new List<double>();

        foreach (var item in claimBase)
        {
            biggest.Add(item.LongestSide());
        }

        return claimBase[biggest.IndexOf(biggest.Max())];
    }
}
