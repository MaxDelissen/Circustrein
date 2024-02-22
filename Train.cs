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
            //It seems it's actually better to sort the animals by carnivore status first, then by size.
            //I didn't expect that, but it makes sense if you think long enough about it,
            //  and it's the only option that makes the tests pass.

            Animals = Animals.OrderByDescending(animal => animal.IsCarnivore) 
                             .ThenByDescending(animal => animal.Size)
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
