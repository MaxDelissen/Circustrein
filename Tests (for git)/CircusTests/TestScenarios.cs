using Circustrein;

namespace CircusTests
{
    [TestClass]
    public class TestScenarios
    {
        [TestMethod]
        public void TestCase1()
        {
            // Arrange
            Train train = new Train();
            train.AddAnimal(new Animal(Size.Small, true));
            train.AddAnimal(new Animal(Size.Large, false));
            train.AddAnimal(new Animal(Size.Large, false));
            train.AddAnimal(new Animal(Size.Medium, false));
            train.AddAnimal(new Animal(Size.Medium, false));
            train.AddAnimal(new Animal(Size.Medium, false));

            // Act
            train.MakeTrain();

            // Assert
            Assert.AreEqual(2, train.Wagons.Count);
        }

        [TestMethod]
        public void TestCase2()
        {
            // Arrange
            Train train = new Train();
            train.AddAnimal(new Animal(Size.Small, true));
            train.AddAnimal(new Animal(Size.Large, false));
            train.AddAnimal(new Animal(Size.Medium, false));
            train.AddAnimal(new Animal(Size.Medium, false));
            train.AddAnimal(new Animal(Size.Small, false));
            train.AddAnimal(new Animal(Size.Small, false));
            train.AddAnimal(new Animal(Size.Small, false));
            train.AddAnimal(new Animal(Size.Small, false));
            train.AddAnimal(new Animal(Size.Small, false));

            // Act
            train.MakeTrain();

            // Assert
            Assert.AreEqual(2, train.Wagons.Count);
        }

        [TestMethod]
        public void TestCase3()
        {
            // Arrange
            Train train = new Train();
            train.AddAnimal(new Animal(Size.Small, true));
            train.AddAnimal(new Animal(Size.Medium, true));
            train.AddAnimal(new Animal(Size.Large, true));
            train.AddAnimal(new Animal(Size.Small, false));
            train.AddAnimal(new Animal(Size.Medium, false));
            train.AddAnimal(new Animal(Size.Large, false));

            // Act
            train.MakeTrain();

            // Assert
            Assert.AreEqual(4, train.Wagons.Count);
        }

        [TestMethod]
        public void TestCase4()
        {
            // Arrange
            Train train = new Train();
            train.AddAnimal(new Animal(Size.Large, true));
            train.AddAnimal(new Animal(Size.Large, true));
            train.AddAnimal(new Animal(Size.Medium, true));
            train.AddAnimal(new Animal(Size.Small, true));
            train.AddAnimal(new Animal(Size.Large, false));
            train.AddAnimal(new Animal(Size.Medium, false));
            train.AddAnimal(new Animal(Size.Medium, false));
            train.AddAnimal(new Animal(Size.Medium, false));
            train.AddAnimal(new Animal(Size.Medium, false));
            train.AddAnimal(new Animal(Size.Medium, false));
            train.AddAnimal(new Animal(Size.Small, false));
            

            // Act
            train.MakeTrain();

            // Assert
            Assert.AreEqual(5, train.Wagons.Count);
        }

        [TestMethod]
        public void TestCase5()
        {
            // Arrange
            Train train = new Train();
            train.AddAnimal(new Animal(Size.Small, true));
            train.AddAnimal(new Animal(Size.Large, false));
            train.AddAnimal(new Animal(Size.Large, false));
            train.AddAnimal(new Animal(Size.Small, false));
            train.AddAnimal(new Animal(Size.Medium, false));

            // Act
            train.MakeTrain();

            // Assert
            Assert.AreEqual(2, train.Wagons.Count);
        }

        [TestMethod]
        public void TestCase6()
        {
            // Arrange
            Train train = new Train();
            train.AddAnimal(new Animal(Size.Small, true));
            train.AddAnimal(new Animal(Size.Small, true));
            train.AddAnimal(new Animal(Size.Small, true));
            train.AddAnimal(new Animal(Size.Large, false));
            train.AddAnimal(new Animal(Size.Large, false));
            train.AddAnimal(new Animal(Size.Large, false));
            train.AddAnimal(new Animal(Size.Medium, false));
            train.AddAnimal(new Animal(Size.Medium, false));

            // Act
            train.MakeTrain();

            // Assert
            Assert.AreEqual(3, train.Wagons.Count);
        }

        [TestMethod]
        public void TestCase7()
        {
            // Arrange
            Train train = new Train();
            //3 large carnivores, 3 medium carnivores, 7 small carnivores, 6 large herbivores, 5 medium herbivores, 0 small herbivores:
            for (int i = 0; i < 3; i++) // 3 large carnivores
                train.AddAnimal(new Animal(Size.Large, true));

            for (int i = 0; i < 3; i++) // 3 medium carnivores
                train.AddAnimal(new Animal(Size.Medium, true));

            for (int i = 0; i < 7; i++) // 7 small carnivores
                train.AddAnimal(new Animal(Size.Small, true));

            for (int i = 0; i < 6; i++) // 6 large herbivores
                train.AddAnimal(new Animal(Size.Large, false));

            for (int i = 0; i < 5; i++) // 5 medium herbivores
                train.AddAnimal(new Animal(Size.Medium, false));

            // Act
            train.MakeTrain();

            // Assert
            Assert.AreEqual(13, train.Wagons.Count);
        }

        [TestMethod]
        public void TestCaseH33H55C11()
        {
            // Arrange
            Train train = new Train();
            train.AddAnimal(new Animal(Size.Large, false));
            train.AddAnimal(new Animal(Size.Large, false));
            train.AddAnimal(new Animal(Size.Medium, false));
            train.AddAnimal(new Animal(Size.Medium, false));
            train.AddAnimal(new Animal(Size.Small, true));
            train.AddAnimal(new Animal(Size.Small, true));

            // Act
            train.MakeTrain();

            // Assert
            Assert.AreEqual(2, train.Wagons.Count);
        }
    }
}
