using System;

namespace DellChallenge.B.CostinsVersion
{
    public class Fish: Species, ISwim
    {
        public override void Drink()
        {
            Console.WriteLine("Not sure how much a fish should drink.");
        }

        public override void Eat()
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
