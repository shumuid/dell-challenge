using System;

namespace DellChallenge.B
{
    public class Bird: Species, ISpecies
    {
        public void Drink()
        {
            Console.WriteLine("A bird has to drink.");
        }

        public void Eat()
        {
            Console.WriteLine("Bird food.");
        }

        public override void GetSpecies()
        {
            base.GetSpecies();

            Console.WriteLine($"You are a {GetType()}. {Gender.GetText()}");
        }

        public void Fly()
        {
            Console.WriteLine("If it's not a penguin, it can fly.");
        }      
    }
}
