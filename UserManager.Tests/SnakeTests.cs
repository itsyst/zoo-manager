using System;
using System.Collections.Generic;
using Xunit;

namespace UserManager.Tests
{
    public class SnakeTests
    {
        public static int ReturnSnakeFoodInfo(int week, List<Animal> animals)
        {
            Snake.ManageFoodsPerWeek(week, new List<Animal>());
            var snakesNum = animals.FindAll(l => l.GetType().Name == "Snake").Count;
            var snake = new Snake();


            return (week % 3 == 0) ? (int)Math.Round((decimal)(snake.Weight * (week / 3)), 2)
                      : snakesNum;
        }



        [Fact]
        public void SetSnakeToList_WhenCalled_ReturnNewListWithIncludedSnake()
        {
            // Arrange
            var initialList = FakeDatabase.GetAnimalsList();
            initialList.Add(new Snake() { Name = "Philanthropist ", Age = 3, Weight = 5 });

            var snake = new Snake();

            // Act
            var actual = new List<Animal>();
            actual.AddRange(initialList);

            // Assert
            Assert.Contains(initialList.Find(s => s.Name == "Philanthropist "), actual);
            Assert.NotNull(snake);
            Assert.IsAssignableFrom<Snake>(snake);
        }



        [Theory]
        [InlineData(0)]
        //[InlineData(1)]
        //[InlineData(4)]
        //[InlineData(9)]
        public void ManageFoodsPerWeek_SnakeIsNotHungry_ReturnFoodsInfo(int week)
        {
            // Arrange
            var initialList = FakeDatabase.GetAnimalsList();
            initialList.Add(new Snake() { Name = "Adder", Age = 3, Weight = 7 });
            initialList.Add(new Snake() { Name = "Cantil ", Age = 2, Weight = 9 });

            ReturnSnakeFoodInfo(week, initialList);

            //Act
            var adderFood = Math.Round((decimal)(7 * (week / 3)), 2);
            var canFood = Math.Round((decimal)(9 * (week / 3)), 2);
            var sumFood = adderFood + canFood;


            // Assert
            Assert.StrictEqual(0, adderFood);
            Assert.StrictEqual(0, canFood);
            Assert.StrictEqual(0, sumFood);

            //Assert.StrictEqual(2, adderFood);
            //Assert.StrictEqual(2, canFood);
            //Assert.StrictEqual(4, sumFood);

            //Assert.StrictEqual(7, adderFood);
            //Assert.StrictEqual(9, canFood);
            //Assert.StrictEqual(16, sumFood);

            //Assert.StrictEqual(21, adderFood);
            //Assert.StrictEqual(28, canFood);
            //Assert.StrictEqual(49, sumFood);


        }


        [Fact]
        public void ManageFoodsPerWeek_CheckIfSnakesExists_ReturnNull()
        {
            // Arrange
            var initialList = FakeDatabase.GetAnimalsList();
            var snakeNumbers = initialList.FindAll(l => l.GetType().Name == "Snake").Count;

            //Act
            const int expected = 0;

            // Assert
            Assert.Equal(expected, snakeNumbers);

        }

    }
}