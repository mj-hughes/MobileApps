using System;
using System.Collections.Generic;

namespace Program2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mobile Apps Program 2!");
            //Program must include a single Collection.
            List<Person> people = new List<Person>();

            //Program asks user to enter the data for Students and teachers.
            Boolean done = false;
            while (!done)
            {
                Console.Write("Please enter a 1) Student; 2) Teacher; any other integer to end: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice) {
                        case 1:
                            people.Add(new Student());
                            break;
                        case 2:
                            people.Add(new Teacher());
                            break;
                        default:
                            done = true;
                            break;
                    }
                } 
                else
                {
                    Console.WriteLine("Please enter a valid choice");
                }
            }
            // Once all data is entered, a formatted listing of all Persons.
            Console.WriteLine("List of people: ");
            foreach (Person p in people)
            {
                Console.WriteLine(p.ToString());
            }
        }
    }

    enum Programs
    {
        None = 0,
        ComputerScience, 
        Accounting, 
        English, 
        Math,
        Marketing,
        Nursing
    }
    class Person
    {
        string name;
        double age;
        string id;

        public Person()
        {
            Console.Write("Enter name: ");
            name = Console.ReadLine();
            Console.Write("Enter age: ");
            if (!Double.TryParse(Console.ReadLine(), out age)) 
            {
                age = 0;
            }
            Console.Write("Enter id: ");
            id = Console.ReadLine();
        }

        override public String ToString()
        {
            return String.Format($"{id} {name} {age} ");
        }
    }

    class Student: Person
    {
        int creditsEarned;
        Programs program;

        public Student(): base ()
        {
            string[] pgms = Enum.GetNames(typeof(Programs));
            for (int i=0; i<pgms.Length; i++)
            {
                Console.WriteLine($"{i} - {pgms[i]}");
            }
            Console.Write("Enter degree program: ");
            int programNum = 0;
            if (!int.TryParse(Console.ReadLine(), out programNum))
            {
                programNum = 0;
            }
            program = (Programs) programNum;

            Console.Write("Enter credits earned: ");
            if (!int.TryParse(Console.ReadLine(), out creditsEarned))
            {
                creditsEarned = 0;
            }
        }
        override public String ToString()
        {
            return base.ToString()+
                String.Format($"{Enum.GetName(typeof(Programs), program)} - {creditsEarned} Credits Earned");
        }

    }

    class Teacher: Person
    {
        int yearsOfService;
        public Teacher(): base()
        {
            Console.Write("Enter years of service: ");
            if (!int.TryParse(Console.ReadLine(), out yearsOfService))
            {
                yearsOfService = 0;
            }
        }
        override public String ToString()
        {
            return base.ToString() + 
                String.Format($" - {yearsOfService} Years of Service");
        }

    }

}
