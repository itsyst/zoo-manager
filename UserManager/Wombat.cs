using System;
using System.Collections.Generic;
using System.Linq;

namespace UserManager
{
    public class Wombat : IZoo
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }

        /// <summary>
        /// Sets a new wombats to FakeApi
        /// </summary>
        /// <returns>returns a new updated FakeApi list</returns>
        public List<IZoo> SetAnimalToList()
        {

        ask:
            try
            {
                var updatedList = FakeDatabase.GetAnimalsList();

                Console.Write($"\nEnter the animal's name: ");
                var name = Console.ReadLine();

                Console.Write($"Enter {name}'s age: ");
                var age = Convert.ToInt32(Console.ReadLine());

                Console.Write($"Enter {name}'s weight: ");
                var weight = Convert.ToInt32(Console.ReadLine());

                updatedList.Add(new Wombat() { Name = name, Age = age, Weight = weight });

                return updatedList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto ask;
            }
        }

        public static void ManageFoodsPerWeek(int week, List<IZoo> animals)
        {
            var wombats = animals;
            var wombatsNum = animals.FindAll(l => l.GetType().Name == "Wombat").Count;


            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"\nThe amount of food needed to feed wombats");

            foreach (var item in from item in wombats
                                 where item.GetType().Name == "Wombat"
                                 select item)

                if (item.Age <= 6 && wombatsNum != 0)
                    Console.WriteLine(
                        $"{item.GetType().Name}: {item.Name} needs {Math.Round(((1 - item.Age * 0.1) * item.Weight) * week, 2)} kg.");

                else if (item.Age > 6 && wombatsNum != 0)
                    Console.WriteLine($"{item.GetType().Name}: {item.Name} needs {Math.Round((item.Weight * 0.6) * week, 2)} kg.");

            if (wombatsNum == 0)
                Console.WriteLine($"You have {wombatsNum} piece of wombats in the zoo");


            Console.ResetColor();
        }



 
        public double CalculateFoodRequirement()
        {

            var foodNeededLessSixYears = (1 - Age * 0.1) * Weight;
            var foodNeededMoreSixYears = (Age * 0.6) * Weight;

            return (Age <= 6) ? Math.Round(foodNeededLessSixYears, 2) :
                   (Age > 6) ? Math.Round(foodNeededMoreSixYears,2):0;
        }

         
    }
}
