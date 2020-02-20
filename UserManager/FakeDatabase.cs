using System.Collections.Generic;

namespace UserManager
{


    public static class FakeDatabase
    {

        /// <summary>
        /// Hard coded List of FakeApi
        /// </summary>
        /// <returns> Returns a full list of 10 animals</returns>
        public static List<IZoo> GetAnimalsList()
        {
            List<IZoo> animals = new List<IZoo>
            {
                new Lion {Name = "Leonard", Age = 9, Weight = 125},
                new Lion {Name = "Leonel", Age = 5, Weight = 105},

                new Panda {Name = "Gun", Age = 5, Weight = 46},
                new Panda {Name = "Guano", Age = 11, Weight = 90},


                new Penguin {Name = "Adeline", Age = 3, Weight = 22},
                new Penguin {Name = "Pygoscelis ", Age = 5, Weight = 32},
                new Penguin {Name = "Jackass)", Age = 7, Weight = 49},

                new Wombat {Name = "Short-legged", Age = 3, Weight = 10},
                new Wombat {Name = "Vombatus", Age = 9, Weight = 30},
                new Wombat {Name = "Warendja", Age = 5, Weight = 25}
            };
            return animals;
        }

    }
        
}