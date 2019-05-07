using DellChallenge.B.CostinsVersion;
using System;

public abstract class Species
{
    public abstract void Drink();
    public abstract void Eat();
    public Gender Gender { get; set; }
    public virtual void GetSpecies()
    {
        Console.WriteLine($"Echo who am I?");
    }
}