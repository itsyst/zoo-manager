using System;
using System.Collections.Generic;
using Xunit;

namespace UserManager.Tests
{
    public class PenguinTests
    {
        public static int ReturnRemainingPenguinsInAnimalList(int week,List<Animal> animalList)
        {
            Penguin.ManageFoodsPerWeek(week, animalList);
            var penguinsNum = animalList.FindAll(l => l.GetType().Name == "Penguin").Count;


            return penguinsNum;
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
        [InlineData(4)]
        public void ManageFoodsPerWeek_WhenCalled_NumberOfPenguinsEatenByLion(int week)
        {
            // Arrange
            var animalList = FakeDatabase.GetAnimalsList();

            var expected = ReturnRemainingPenguinsInAnimalList(week, animalList);

            // Act
            var actual = 3;   //Week 4 no more penguins

            // Assert
            Assert.Equal(expected, actual);

        }


    }
}
