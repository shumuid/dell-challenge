using DellChallenge.B;
using System;

public class Species
{
    public Gender Gender { get; set; }
    public virtual void GetSpecies()
    {
        Console.WriteLine($"Echo who am I?");
    }
}