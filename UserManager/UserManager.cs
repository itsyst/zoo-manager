using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace UserManager
{
    internal class UserManager 
    {
        
        private static int NewWeek()
        {
            label: Console.Write($"\nEnter week(s) Nº to get respective food needed: ");
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;
                var input = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                if (input >= 0) return input;
                Console.WriteLine($"Day(s) can not be negative");
                Console.ResetColor();
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto label;
            }
        }


        //public static List<Animal> Animals { get; set; }

        //public UserManager(FakeDatabase animals )
        //{
        //    Animals = animals.GetAnimalsList();
        //}

        //public static int NewWeek()
        //{
        //    var totalFoodNeeded = 0d;
        //    foreach (var element in Animals)
        //    {
        //        totalFoodNeeded += element.CalculateFoodRequirement();
        //    }
        //    return (int)totalFoodNeeded;

        //}


        public  double CalculateFoodRequirement()
        {
            var totalFood = NewWeek();

            return totalFood;
        }


        private static void ManageFoodsPerWeek(int weeksInput, List<IZoo> modifiedList)
        {
            var remainingAnimals = Lion.DeleteAnimalFromList(weeksInput, modifiedList);

            Penguin.ManageFoodsPerWeek(weeksInput, remainingAnimals);
            Wombat.ManageFoodsPerWeek(weeksInput, remainingAnimals);
            Panda.ManageFoodsPerWeek(weeksInput, remainingAnimals);
            Snake.ManageFoodsPerWeek(weeksInput, remainingAnimals);
            Console.ReadLine();
        }



        private static void CreateNewAnimal()
        {
            Console.Write($"Enter the type of animal to be added to Zoo: ");
            var newAnimal = Console.ReadLine();

            if (newAnimal != null && newAnimal.ToLower() == "lion")
            {
                var lion = new Lion();
                ShowListInfo(lion.SetAnimalToList());
            }

            if (newAnimal != null && newAnimal.ToLower() == "panda")
            {
                var panda = new Panda();
                ShowListInfo(panda.SetAnimalToList());
            }

            if (newAnimal != null && newAnimal.ToLower() == "penguin")
            {
                var penguin = new Penguin();
                ShowListInfo(penguin.SetAnimalToList());
            }

            if (newAnimal != null && newAnimal.ToLower() == "wombat")
            {
                var wombat= new Wombat();
                ShowListInfo(wombat.SetAnimalToList());
            }

            if (newAnimal != null && newAnimal.ToLower() == "snake")
            {
                var snake = new Snake();
                ShowListInfo(snake.SetAnimalToList());
            }
            else if (newAnimal != null && newAnimal.ToLower() == " ")
            {
                Console.Write("Enter to return: ");
                Console.ReadKey(true);
            }
        }

        public static void ShowListInfo(List<IZoo> modifiedList)
        {
            Console.WriteLine($"\n{"Name",-20}{"Age",-10}{"Weight",-10}{"Species",-10}\n");

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var element in modifiedList)
                Console.WriteLine(
                $"{element.Name,-20}{element.Age,-10}{element.Weight,-10}{element.GetType().Name,-10}");
            Console.ResetColor();

            Console.WriteLine($"\nTotal number of animals: { modifiedList.Count}");
            Console.ReadKey(true);

            ManageFoodsPerWeek(NewWeek(), modifiedList);   //TODO
        }

        internal static void Launch()
        {
            Banner();
            Console.WriteLine("\n [Enter] to Start.");
            Console.WriteLine(" [Esc] to quit.");
            Console.Write("\n Selection: ");

            var input = Console.ReadKey();
            if (input.Key == ConsoleKey.Enter)
            {
                Banner();
                Console.Write("\n Verifying the number of animals...");
                Thread.Sleep(2500);
                Banner();

                var animalNumber = FakeDatabase.GetAnimalsList().Count;

                if (animalNumber < 10)
                {
                    Console.WriteLine($"\nSorry !! Insufficient animal number");
                    Console.WriteLine($"You have to add more animals in the Zoo\n");
                    Environment.Exit(0);
                }
                else
                {
                    Console.Write($"\n You have {animalNumber} animals...");
                    Thread.Sleep(2200);
                    Start();
                }
            }
            else if (input.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
        }

        private static void Start()
        {
            var running = true;
            while (running)
            {
                Banner();
                Console.WriteLine("\n1.Create a new animal" +
                                  "\n2.Manage the animal food" +
                                  "\n0.Exit");
                Console.Write("\n> Selection: ");
                var intake = Console.ReadLine();

                if (intake == "1")
                {
                    CreateNewAnimal();
                }
                else if (intake == "2")
                {
                    var weeks = NewWeek();
                    ManageFoodsPerWeek(weeks, new List<IZoo>());

                }
                else if (intake == "0")
                {
                    running = false;
                }
                else
                {
                    Console.WriteLine("\nType a valid selection.");
                    Console.Write("Hit enter to start again... ");
                    Console.ReadLine();
                }
            }
        }

        private static void Banner()
        {
            Console.Clear();
            var builder = new StringBuilder();
            builder.Append('*', 50);
            Console.WriteLine(builder);
            Console.WriteLine("*          Welcome to the Zoo manager            *");
            Console.WriteLine(builder);
        }
    }
}