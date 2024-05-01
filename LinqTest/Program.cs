using System;

namespace LinqTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>
            {
    new Person { Name = "Alice", Age = 58, City = "New York" },
    new Person { Name = "Bob", Age = 34, City = "Los Angeles" },
    new Person { Name = "Charlie", Age = 18, City = "New York" },
    new Person { Name = "David", Age = 25, City = "Chicago" },
    new Person { Name = "Søren", Age = 19, City = "København" }
};
            var groupedPeople = people.GroupBy(p => p.City);

            foreach (var group in groupedPeople)
            {
                Console.WriteLine($"By: {group.Key}");
                foreach (var person in group)
                {
                    Console.WriteLine($"  - {person.Name}, {person.Age} år");
                }
            }

            var names = people
                .OrderBy(p => p.Age)
            //    .Select(p => p.Name);
                .Select(p => $"Navn: {p.Name}, Alder: {p.Age} år");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nSorteret på alder:");
            Console.ResetColor();
            foreach (var person in names)
            {
                Console.WriteLine(($"{person}"));
            }

            var firstAdult = people.FirstOrDefault(p => p.Age <= 20);
            Console.WriteLine($"\nFørste person under 20 år: {firstAdult.Name}");

            var anyAdults = people.Any(p => p.Age > 40);
            Console.Write("Er der nogle personer, som er over 40 år?: ");
            if (anyAdults)
            {
                Console.WriteLine("Ja");
            }
            else
            {
                Console.WriteLine("Nej");
            }
            //Console.WriteLine(anyAdults.ToString());

            var average = people.Average(p => p.Age);
            var max = people.Max(p => p.Age);
            Console.WriteLine($"Gennemsnitsalder: {average} år. Ældste persons alder: {max} år");
        }
    }
}
