using System;
using System.Collections.Generic;
using System.Linq;

namespace UserManager
{
    public class Panda : IZoo
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

                updatedList.Add(new Panda() { Name = name, Age = age, Weight = weight });

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
            var pandas = restOfAnimals;
            var pandasNum = restOfAnimals.FindAll(l => l.GetType().Name == "Panda").Count;


            Console.WriteLine($"\nThe amount of food needed to feed pandas");


            foreach (var item in from element in pandas where element.GetType().Name == "Panda" select element)
            {

                if (item != null && item.Age <= 6)
                {

                    Console.WriteLine(
                        $"{item.GetType().Name}: {item.Name} needs {Math.Round((2 * item.Weight) * week, 2)} kg.");
                }

                else if (item != null && item.Age > 6)
                {

                    Console.WriteLine(
                        $"{item.GetType().Name}: {item.Name} needs {Math.Round((item.Weight) * week, 2)} kg.");
                }


            }
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
