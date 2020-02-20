using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace UserManager.Tests
{
    public class WombatTests
    {
        public static int ReturnRemainingPandasInAnimalList(int week, List<Animal> animalList)
        {
            Wombat.ManageFoodsPerWeek(week, animalList);
            var wombatsNum = animalList.FindAll(l => l.GetType().Name == "Wombat").Count;


            return wombatsNum;
        }

        [Fact]
        public void SetPenguinToList_Remove3Pandas_ReturnNumberOfRemainingAnimals()
        {
            // Arrange
            var animalList = FakeDatabase.GetAnimalsList();
            animalList.RemoveAt(0);
            animalList.RemoveAt(1);
            animalList.RemoveAt(2);

            const int expected = 7;

            // Act
            var result = animalList.Count;

            // Assert
            Assert.Equal(expected, result);

        }



        [Theory]
        [InlineData(6)]
        public void ManageFoodsPerWeek_WhenCalled_NumberOfPenguinsEatenByLion(int week)
        {
            // Arrange
            var animalList = FakeDatabase.GetAnimalsList();

            var expected = ReturnRemainingPandasInAnimalList(week, animalList);

            // Act
            var actual = 3;   //Week 4 no more penguins

            // Assert
            Assert.Equal(expected, actual);

        }


        public static double FoodInKgByWeek(int week,Wombat wombat)
        {
            var animalList = FakeDatabase.GetAnimalsList();
            Wombat.CalculateFoodRequirement(week, animalList);

            return  (wombat.Age>=6)?Math.Round(((1 - wombat.Age * 0.1) * wombat.Weight) * week, 2)
                    : Math.Round(((wombat.Age * 0.6) * wombat.Weight) * week, 2);
        }

        [Fact]
        public void ManageFoodsPerWeek_AmountOfFoodsDependFromAge_FoodNeededByWeek()  
        {
            // Arrange
            var animalList = FakeDatabase.GetAnimalsList();
            animalList.Add(new Wombat { Name = "Mambos", Age = 3, Weight = 10 });   // age under 6  
            //animalList.Add(new Wombat { Name = "Mambos", Age = 8, Weight = 10 });   // age more than 6  

            // Act
            int week = 1;
            //Wombat.ManageFoodsPerWeek(week, animalList);
            var expected= FoodInKgByWeek(week, new Wombat {Name = "Mambos", Age = 3, Weight = 10});
            //var expected= FoodInKgByWeek(week, new Wombat {Name = "Mambos", Age = 8, Weight = 10});
            
            var actual= 7;   // age less than 6  
            //var actual= 5;   // 4,8 kg => age more than 6  


            Assert.Equal(expected,actual);

        }
    }
}
