namespace Circustrein
{
    public class Train
    {
        private List<Animal> animals = new List<Animal>();
        public List<Wagon> WagonsResult { get; private set; } = new List<Wagon>();

        private List<Wagon> wagonOption1 = new List<Wagon>();
        private List<Wagon> wagonOption2 = new List<Wagon>();
        private List<Wagon> wagonOption3 = new List<Wagon>();
        private List<Wagon> wagonOption4 = new List<Wagon>();

        public bool AddAnimal(Animal animal)
        {
            try
            {
                animals.Add(animal);
                return true;
            }
            catch (Exception) { return false; }
        }

        private List<Wagon> FillWagons(List<Animal> sortedAnimals)
        {
            List<Wagon> currentWagonList = new List<Wagon>();
            foreach (Animal animal in sortedAnimals)
            {
                bool animalAdded = false;
                foreach (Wagon wagon in currentWagonList)
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
                    currentWagonList.Add(newWagon);
                }
            }
        }
        public void MakeTrain()
        {
            //It seems it's actually better to sort the animals by carnivore status first, then by size.
            //I didn't expect that, but it makes sense if you think long enough about it,
            //  and it's the only option that makes the tests pass.

            wagonOption1 = FillWagons(animals.OrderBy(animal => animal.IsCarnivore).ThenBy(animal => animal.Size).ToList());
            
            
            animals = animals.OrderByDescending(animal => animal.IsCarnivore) 
                             .ThenByDescending(animal => animal.Size)
                             .ToList(); //Back to list.

            
        }

        public void Clear()
        {
            animals.Clear();
            WagonsResult.Clear();
        }
    }
}
