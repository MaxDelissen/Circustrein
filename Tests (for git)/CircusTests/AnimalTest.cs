using Circustrein;

namespace CircusTests
{
    [TestClass]
    public class AnimalTest
    {
        [TestMethod]
        public void TestAnimalConstructor()
        {
            // Arrange
            string size = "m";
            string isCarnivore = "h";

            // Act
            Animal animal = new Animal(size, isCarnivore);

            // Assert
            Assert.AreEqual(Size.Medium, animal.Size);
            Assert.IsFalse(animal.IsCarnivore);
        }

        [TestMethod]
        public void TestEnumBasedConstructor()
        {
            // Arrange
            Size size = Size.Medium;
            bool isCarnivore = false;

            // Act
            Animal animal = new Animal(size, isCarnivore);

            // Assert
            Assert.AreEqual(Size.Medium, animal.Size);
            Assert.IsFalse(animal.IsCarnivore);
        }

        [TestMethod]
        public void TestAnimalConstructorInvalidSize()
        {
            // Arrange
            string size = "invallid!";
            string isCarnivore = "h";

            // Act
            try
            {
                Animal animal = new Animal(size, isCarnivore);
            }
            catch (ArgumentException e)
            {
                // Assert
                Assert.AreEqual("Invalid size", e.Message);
            }
        }

        [TestMethod]
        public void TestAnimalConstructorInvalidIsCarnivore()
        {
            // Arrange
            string size = "m";
            string isCarnivore = "invallid!";

            // Act
            try
            {
                Animal animal = new Animal(size, isCarnivore);
            }
            catch (ArgumentException e)
            {
                // Assert
                Assert.AreEqual("Invalid input", e.Message);
            }
        }
    }
}
