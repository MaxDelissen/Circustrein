using Circustrein;
namespace CircusTests
{
    [TestClass]
    public class WagonTest
    {
        [TestMethod]
        public void TestAddAnimal()
        {
            // Arrange
            Wagon wagon = new Wagon();
            Animal animal = new Animal(Size.Medium, false);

            // Act
            bool result = wagon.AddAnimal(animal);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestSpaceLeft()
        {
            // Arrange
            Wagon wagon = new Wagon();
            Animal animal = new Animal(Size.Medium, false);

            // Act
            wagon.AddAnimal(animal);

            // Assert
            Assert.AreEqual(7, wagon.SpaceLeft);
        }

        [TestMethod]
        public void TestAddAnimalNull()
        {
            // Arrange
            Wagon wagon = new Wagon();

            // Act
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type. (null is needed for testing)
            bool result = wagon.AddAnimal(null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestAddAnimalNoSpace()
        {
            // Arrange
            Wagon wagon = new Wagon();
            Animal animal = new Animal(Size.Large, false);
            wagon.AddAnimal(animal); //add two large animals to fill the wagon
            wagon.AddAnimal(animal);

            // Act
            bool result = wagon.AddAnimal(animal); //try to stuff a third large animal in the wagon, which should fail

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestAddAnimalCarnivore()
        {
            // Arrange
            Wagon wagon = new Wagon();
            Animal animal = new Animal(Size.Medium, true);

            // Act
            bool result = wagon.AddAnimal(animal);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestAddTwoCarnivores()
        {
            // Arrange
            Wagon wagon = new Wagon();
            Animal animal = new Animal(Size.Medium, true);
            wagon.AddAnimal(animal);

            // Act
            bool result = wagon.AddAnimal(animal);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestCarnivoreAndHerbivore()
        {
            // Arrange
            Wagon wagon = new Wagon();
            Animal animal = new Animal(Size.Medium, true);
            wagon.AddAnimal(animal);

            // Act
            bool result = wagon.AddAnimal(new Animal(Size.Medium, false));

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestAddTwoHerbivores()
        {
            // Arrange
            Wagon wagon = new Wagon();
            Animal animal = new Animal(Size.Medium, false);
            wagon.AddAnimal(animal);

            // Act
            bool result = wagon.AddAnimal(animal);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestLargeHerbivoreAndSmallCarnivore() //Small carnivore can't eat large herbivore
        {
            // Arrange
            Wagon wagon = new Wagon();
            Animal animal = new Animal(Size.Large, false);
            wagon.AddAnimal(animal);

            // Act
            bool result = wagon.AddAnimal(new Animal(Size.Small, true));

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestAddCarnivoreToHerbivoreWagon()
        {
            // Arrange
            Wagon wagon = new Wagon();
            Animal animal = new Animal(Size.Medium, false);
            wagon.AddAnimal(animal);
            wagon.AddAnimal(animal);

            // Act
            bool result = wagon.AddAnimal(new Animal(Size.Medium, true));

            // Assert
            Assert.IsFalse(result);
        }
    }
}
