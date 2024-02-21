namespace Circustrein
{
    public class Train
    {
        private List<Animal> Animals = new List<Animal>();
        public List<Wagon> Wagons { get; private set; } = new List<Wagon>();

        public bool AddAnimal(Animal animal)
        {
            if (animal == null) return false;
            try
            {
                Animals.Add(animal);
                return true;
            }
            catch (Exception) { return false; }
        }

        public void MakeTrain()
        {
            Animals = Animals.OrderByDescending(animal => animal.Size) //Order by size, largest first.
                             .ThenByDescending(animal => animal.IsCarnivore) //Then by carnivore, carnivores first.
                             .ToList(); //Back to list.

            foreach (Animal animal in Animals)
            {
                bool animalAdded = false;
                foreach (Wagon wagon in Wagons)
                {
                    if (wagon.AddAnimal(animal))
                    {
                        animalAdded = true;
                        break;
                    }
                }
                if (!animalAdded) //If the animal wasn't added to any wagon, create a new wagon and add it there.
                {
                    Wagon newWagon = new Wagon();
                    newWagon.AddAnimal(animal);
                    Wagons.Add(newWagon);
                }
            }
        }

        public void Clear()
        {
            Animals.Clear();
            Wagons.Clear();
        }
    }
}
