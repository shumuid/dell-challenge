using System;

namespace DellChallenge.A
{

    class Program
    {
        static void Main(string[] args)
        {
            // State and explain console output order.

            new B();

            Console.ReadKey();

            #region Statements and explanations

            //CONSOLE OUTPUT

            //A.A()
            //B.B()
            //A .Age

            //COMMENTS

            //Inheritance allows derived(child) class(es) "B" or "C" or "D" (and so on) creation from a base(parent) class "A" to reuse, extend or modify the base class functionality.

            //1 A class contructor is called
            //2 the console displays the message inside A class constructor -> A.A()
            //3 derived class B constructor is called
            //4 the console displays the message inside B class constructor -> B.B()
            //5 Age public property which is available for class B as well (due to inheritance and public access modifier) is assigned 0 value
            //6 the Age property setter will assign the _age private field 0 value 
            //  (_age field it not available for B classes instances because its protection level - private)
            //7 the Age property setter will display this message in the console -> A .Age
            //8 the console is waiting to read user key input  Console.ReadKey()
            //9 "Press any key to continue . . ." message is displayed in the console after a key is pressed

            #endregion
        }
    }

    class A
    {
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;

                Console.WriteLine("A .Age");
            }
        }

        public A()
        {
            Console.WriteLine("A.A()");
        }
    }

    class B : A
    {
        public B()
        {
            Console.WriteLine("B.B()");
            Age = 0;
        }
    }
}