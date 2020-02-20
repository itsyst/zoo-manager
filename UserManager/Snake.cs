using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserManager
{
    public class Snake :IZoo
    {
        /// <summary>
        /// Sets a new Snake to FakeApi
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

                updatedList.Add(new Snake() { Name = name, Age = age, Weight = weight });
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
            var snakes = restOfAnimals;
            var snakesNum = restOfAnimals.FindAll(l => l.GetType().Name == "Snake").Count;


            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            foreach (var item in from item in snakes
                                 where item.GetType().Name == "Snake"
                                 select item)
                Console.WriteLine(week % 3 == 0
                    ? $"\n{item.GetType().Name}: {item.Name} needs {Math.Round((item.Weight) * (week / 3), 2)} kg."
                    : $"\n{item.GetType().Name}: {item.Name} doesn't need foods for the moment.");

            if (snakesNum == 0)
            {
                Console.WriteLine($" ");
            }
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
