namespace Circustrein
{
    public class Wagon
    {
        public List<Animal> WagonAnimals { get; private set; } = new List<Animal>();
        public int SpaceLeft { get; private set; } = 10;

        public bool AddAnimal(Animal animal)
        {
            if (animal == null) return false;
            if (CheckSpace(animal)) //Check for space first, to improve performance, as this is a less expensive operation.
            {
                if (CheckCarnivore(animal))
                {
                    WagonAnimals.Add(animal);
                    SpaceLeft -= (int)animal.Size;
                    return true;
                }
            }
            return false;
        }

        private bool CheckSpace(Animal animal)
        {
            return SpaceLeft >= (int)animal.Size;
        }

        private bool CheckCarnivore(Animal animal)
        {
            foreach (Animal wagonAnimal in WagonAnimals)
            {
                //If the new animal is a carnivore, and bigger or as big as one of the animals in the wagon, return false.
                //If the new animal is smaller or as small as a carnivore in the wagon, return false.
                if ((animal.IsCarnivore && animal.Size >= wagonAnimal.Size) || (animal.Size <= wagonAnimal.Size && wagonAnimal.IsCarnivore))
                {
                    return false;
                }
            }
            return true;
        }


    }
}
