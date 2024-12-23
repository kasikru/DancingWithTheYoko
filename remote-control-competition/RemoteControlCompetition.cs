using System;
using System.Collections.Generic;
using System.Linq;

// TODO implement the IRemoteControlCar interface

public class ProductionRemoteControlCar : IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public void Drive()
    {
        DistanceTravelled += 10;
    }

    public int CompareTo(ProductionRemoteControlCar car)
    {
        return NumberOfVictories.CompareTo(car.NumberOfVictories);
    }
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        List<ProductionRemoteControlCar> result = new List<ProductionRemoteControlCar>();

        if (prc1.CompareTo(prc2) < 0)
        {
            result.Add(prc1);
            result.Add(prc2);
        }
        else
        {
            result.Add(prc2);
            result.Add(prc1);
        }

        return result;
    }
}

public interface IRemoteControlCar
{
    public int DistanceTravelled { get; }
    public void Drive();
}
