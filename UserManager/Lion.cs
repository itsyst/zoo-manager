using System;
using System.Collections.Generic;

namespace UserManager
{
    public class Lion : IZoo
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

                updatedList.Add(new Lion() { Name = name, Age = age, Weight = weight });


                Console.ResetColor();
                return updatedList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto ask;
            }
        }


        public static List<IZoo> DeleteAnimalFromList(int week, List<IZoo> modifiedList)  //TODO
        {
            var updatedList = FakeDatabase.GetAnimalsList();
            if (modifiedList.Count != 0)
            {
                updatedList = modifiedList;
            }
            
            for (var i = 0; i < week; i++)
            {
                // Count the number of lions/pandas and sum up inside FakeApi
                var lionsNum = updatedList.FindAll(l => l.GetType().Name == "Lion").Count;
                var pandaNum = updatedList.FindAll(l => l.GetType().Name == "Panda").Count;
                var sumPandaAndLion = lionsNum + pandaNum;

                for (var j = 0; j < lionsNum; j++)
                {
                    choice:
                    var random = new Random();
                    var index = random.Next(updatedList.Count);
                    
                    if (updatedList[index].GetType().Name == "Lion" || updatedList[index].GetType().Name == "Panda")
                        goto choice;
                    if (lionsNum < 1 || updatedList.Count <= sumPandaAndLion ||
                        (updatedList[index].GetType().Name == "Lion" || updatedList[index].GetType().Name == "Panda" ||
                         updatedList[index].GetType().Name == "Snake")) continue;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(($"Lion ate => a {updatedList[index].GetType().Name} \u263a"));
                    updatedList.RemoveAt(index);
                    Console.ResetColor();
                }
                
                if (lionsNum < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"You don't have lions in the Zoo");
                }
                
                else if (updatedList.Count <= sumPandaAndLion)
                {

                    Console.WriteLine($"\nThe lion ate all animals no Wombats/Penguins in the Zoo");
                    Console.ForegroundColor = ConsoleColor.DarkRed;

                    Console.WriteLine($"Very urgent!! you have to feed {lionsNum} lions");

                    Console.ResetColor();
                    break;
                }
            }
            Console.WriteLine($"\nTotal remaining animals: {updatedList.Count}");
            return updatedList;
        }


        
        // Interface implementation
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }

    

        public double CalculateFoodRequirement()
        {
            throw new NotImplementedException();
        }

   
    }
}