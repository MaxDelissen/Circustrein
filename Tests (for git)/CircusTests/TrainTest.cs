using Circustrein;

namespace CircusTests
{
    [TestClass]
    public class TrainTest
    {
        [TestMethod]
        public void TestHowToMakeTests()
        {
            //Arrange
            Train train;

            //Act
            train = new();

            //Assert
            Assert.IsNotNull(train);
        }


        [TestMethod]
        public void TestAddAnimal()
        {
            // Arrange
            Train train = new Train();
            Animal animal = new Animal(Size.Medium, false);

            // Act
            bool result = train.AddAnimal(animal);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestAddAnimalNull()
        {
            // Arrange
            Train train = new Train();

            // Act
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type. (null is needed for testing)
            bool result = train.AddAnimal(null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMakeTrain()
        {
            // Arrange
            Train train = new Train();
            List<Animal> animals = new List<Animal>
            {
                new Animal(Size.Small, true),
                new Animal(Size.Medium, false),
                new Animal(Size.Medium, false),
                new Animal(Size.Large, false),
                new Animal(Size.Medium, false),
                new Animal(Size.Large, false)
            };
            foreach (var animal in animals)
            {
                train.AddAnimal(animal);
            }

            // Act
            train.MakeTrain();

            // Assert
            Assert.IsTrue(train.Wagons.Count > 0);
        }

        [TestMethod]
        public void TestMakeTrainEmptyTrain()
        {
            // Arrange
            Train train = new Train();

            // Act
            train.MakeTrain();

            // Assert
            Assert.AreEqual(0, train.Wagons.Count);
        }

        [TestMethod]
        public void TestMakeGiantTrain()
        {
            // Arrange
            Train train = new Train();
            Random random = new Random();

            Array sizes = Enum.GetValues(typeof(Size));

            for (int i = 0; i < 1000; i++)
            {
                // Generate random size
#pragma warning disable CS8605 // Unboxing a possibly null value.
                Size randomSize = (Size)sizes.GetValue(random.Next(sizes.Length));
#pragma warning restore CS8605 // Unboxing a possibly null value.

                // Generate random carnivore status
                bool randomCarnivore = random.Next(0, 2) == 0 ? false : true;

                train.AddAnimal(new Animal(randomSize, randomCarnivore));
            }


            // Act
            train.MakeTrain();

            // Assert
            Assert.IsTrue(train.Wagons.Count > 1);
        }

        [TestMethod]
        public void TestClearTrain()
        {
            // Arrange
            Train train = new Train();
            Animal animal = new Animal(Size.Medium, false);
            train.AddAnimal(animal);

            // Act
            train.Clear();

            // Assert
            Assert.AreEqual(0, train.Wagons.Count);
        }

        [TestMethod]
        public void TestClearEmptyTrain()
        {
            // Arrange
            Train train = new Train();

            // Act
            train.Clear();

            // Assert
            Assert.AreEqual(0, train.Wagons.Count);
        }
    }
}