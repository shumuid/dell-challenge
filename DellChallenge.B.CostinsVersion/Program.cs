using System;
using System.Collections.Generic;

namespace DellChallenge.B.CostinsVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            //This is one possible scenario in which you can use an abstract base class of Species and some IFly, ISwim interfaces 
            //to showcase the Abstract Class vs Interface topic

            //An abstract class defines the fundamental identity of a class family and it is used for objects of the same type.
            //An interface is used to define secondary features for a class.
            //For example Bird class and Plane class can both implement IFly interface but they are fundamentally different. 
            Plane cargoPlane = new Plane();
            cargoPlane.Fly();
            Bird crane = new Bird();
            crane.Fly();

            Console.WriteLine();

            List<Species> speciesCollection = ArcList<Species>(
                 new Human() { Gender = Gender.Male },
                 new Bird() { Gender = Gender.Female },
                 new Fish());

            foreach(Species individual in speciesCollection)
            {
                individual.GetSpecies();
            }

            Console.ReadKey();
        }

        static List<T> ArcList<T>(params T[] items)
        {
            return new List<T>(items);
        }
    }
}