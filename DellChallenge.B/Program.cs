using System;
using System.Collections.Generic;

namespace DellChallenge.B
{
    class Program
    {
        static void Main(string[] args)
        {
            //This is one possible scenario in which you can use a base class of Species and an Interface of ISpecies
            Console.WriteLine("P1 example:");
            //Polymorphism 1
            //Objects of derived classes can be treated as objects of the base class in places such as collections
            List<Species> speciesCollection = ArcList<Species>(
                 new Human() { Gender = Gender.Male },
                 new Bird() { Gender = Gender.Female },
                 new Fish());

            foreach (Species individual in speciesCollection)
            {
                individual.GetSpecies();
            }

            Console.WriteLine();

            Console.WriteLine("P2 example:");
            //Polymorphism 2 
            //You can call a base class method and produce derived class method execution
            Human soldier = new Human() { Gender = Gender.Female };
            Species sample = (Species)soldier;
            sample.GetSpecies();

            Console.WriteLine();

            Console.WriteLine("P3 example:");
            //Polymorphism 3 - exception
            //If you call a base class method which has a new implementation in the derived class (which will hide the base class method implementation) 
            //you will produce the base class method execution
            Fish trout = new Fish();
            Species s = (Species)trout;
            s.GetSpecies();

            Console.ReadKey();
        }

        static List<T> ArcList<T>(params T[] items)
        {
            return new List<T>(items);
        }
    }
}