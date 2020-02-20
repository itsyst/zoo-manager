using System;
using System.Collections.Generic;

namespace UserManager
{
    public class Penguin : IZoo
    {

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

                updatedList.Add(new Penguin() { Name = name, Age = age, Weight = weight });

                return updatedList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto ask;
            }
        }


        public static void ManageFoodsPerWeek(int week, List<IZoo> restOfAnimals)
        {
            var penguins = restOfAnimals;

            var penguinsNum = penguins.FindAll(l => l.GetType().Name == "Penguin").Count;

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine($"\nPenguin ate a lot of fish! No need for extra food");

            Console.WriteLine($"You have {penguinsNum} piece of penguins");

            Console.ResetColor();



        }

        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }

    

        public double CalculateFoodRequirement()
        {
            return 0;
        }
    }
}
