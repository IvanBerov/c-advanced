﻿using System;

namespace FilterByAge1
{
    public class Person
    {
        public string Neme { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Person[] people = new Person[n];

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(", ");

                people[i] = new Person();
                people[i].Neme = input[0];
                people[i].Age = int.Parse(input[1]);
            }

            string filter = Console.ReadLine();
            int filterAge = int.Parse(Console.ReadLine());

            Func<Person, bool> condition = GetAgeCondition(filter, filterAge);
            Func<Person, string> formatter = GetFormatter(Console.ReadLine());

            PrintPeople(people, condition,formatter);


        }
        static Func<Person, bool> GetAgeCondition(string filter, int filterAge)
        {
            switch (filter)
            {
                case "younger": return p => p.Age < filterAge;
                case "older": return P => P.Age >= filterAge;
                default:
                    return null;
            }
        }
        static void PrintPeople(Person[] people, Func<Person, bool> condition, Func<Person, string> formatter)
        {
            foreach (var person in people)
            {
                if (condition(person))
                {
                    Console.WriteLine(formatter(person));
                }
            }
        }
        static Func<Person, string> GetFormatter(string format)
        {
            switch (format)
            {
                case "name": return p => $"{p.Neme}";
                case "age": return P => $"{P.Age}";
                case "name age": return p => $"{p.Neme} - {p.Age}";
                default:
                    return null;
            }

        }
    }

}

