using System;

namespace DellChallenge.B
{
    public class Human : Species, ISpecies
    {      
        public void Drink()
        {
            Console.WriteLine("Drink some water! An average human can survive about 3 days without it.");
        }

        public void Eat()
        {
            Console.WriteLine("Eat some food! An average human can survive about 3 weeks without it.");
        }

        public override void GetSpecies()
        {
            base.GetSpecies();

            Console.WriteLine($"You are a {GetType()}. {Gender.GetText()}");
        }
    }
}
