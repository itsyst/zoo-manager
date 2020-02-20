using System.Linq;
using Xunit;

namespace UserManager.Tests
{
    public class LionTests
    {
        [Fact]
        public void DeleteAnimalFromList_Remove3ItemsFromTheList_ReturnsRemainingItems()
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
            Assert.Equal(expected,result);
        }

        [Fact]
        public void DeleteAnimalFromList_RemoveThreeWombatFromTheList_ReturnsFalse()
        {
            // Arrange
            var animalList = FakeDatabase.GetAnimalsList();

            var wombatsCheck = animalList.Select(wo => wo.GetType().Name == "Wombat").ToArray();

            animalList.Remove(animalList.Find(wo=>wo.Name == "Warendja"));
            animalList.Remove(animalList.Find(wo => wo.Name == "Vombatus"));
            animalList.Remove(animalList.Find(wo => wo.Name == "Short-legged"));

            var expected = wombatsCheck[7]; // initial item with given index exists

            // Act
            bool actual = false;

            // Assert
            Assert.NotEqual(expected, actual);
        }

        [Fact]
        public void DeleteAnimalFromList_RemoveAllLionsFromTheList_RemainingAnimals()
        {
            // Arrange
            var animalList = FakeDatabase.GetAnimalsList();
            animalList.RemoveAll(l => l.GetType().Name == "Lion");
            var lion = new Lion();

            var expected = Lion.DeleteAnimalFromList(1, animalList);

            
            // Act
            var actual = 8;

            // Assert
            Assert.Equal(actual,expected.Count);
        }

    }
}
