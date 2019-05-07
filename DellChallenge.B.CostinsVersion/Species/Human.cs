using System;

namespace DellChallenge.B.CostinsVersion
{
    public class Human : Species
    {      
        public override void Drink()
        {
            Console.WriteLine("Drink some water! An average human can survive about 3 days without it.");
        }

        public override void Eat()
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
