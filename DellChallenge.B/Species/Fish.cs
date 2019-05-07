using System;

namespace DellChallenge.B
{
    public class Fish: Species, ISpecies
    {
        public void Drink()
        {
            Console.WriteLine("Not sure how much a fish should drink.");
        }

        public void Eat()
        {
            Console.WriteLine("Don't forget to feed your fish.");
        }

        public new void GetSpecies()
        {
            Console.WriteLine($"It is a {GetType()}. {Gender.GetText()}");
        }

        public void Swim()
        {
            Console.WriteLine("If the fish can't fly then it will swim.");
        }
    }
}
