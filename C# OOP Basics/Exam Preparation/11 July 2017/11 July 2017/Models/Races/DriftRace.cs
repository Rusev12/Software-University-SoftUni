﻿public class DriftRace : Race
{
    public DriftRace(int length, string route, int prizePool) : base(length, route, prizePool)
    {
    }

    protected override int GetPerformancePoints(Car car)
    {
        return car.DriftPerformance();
    }
}