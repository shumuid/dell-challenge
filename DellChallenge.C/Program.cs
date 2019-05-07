using System;

namespace DellChallenge.C
{
    class Program
    {
        static void Main(string[] args)
        {
            StartHere();

            Console.ReadKey();
        }

        private static void StartHere()
        {
            MyObject myNewObject = new MyObject();
            Console.WriteLine(myNewObject.Do(1, 3));
            Console.WriteLine(myNewObject.Do(1, 3, 5));
        }
    }
}