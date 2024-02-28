namespace Circustrein
{
    public class Train
    {
        private List<Animal> animals = new List<Animal>();
        public List<Wagon> WagonsResult { get; private set; } = new List<Wagon>();

        private List<Wagon> wagonOption1 = new List<Wagon>();
        private List<Wagon> wagonOption2 = new List<Wagon>();

        public bool AddAnimal(Animal animal)
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
            if (animal == null)
            {
                return false; 
            }
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

            return currentWagonList;
        }
        public void MakeTrain()
        {
            //It seems it's actually better to sort the animals by carnivore status first, then by size.
            //I didn't expect that, but it makes sense if you think long enough about it,
            //  and it's the only option that makes the tests pass.

            wagonOption1 = FillWagons(animals.OrderByDescending(animal => animal.IsCarnivore).ThenByDescending(animal => animal.Size).ToList());
            wagonOption2 = FillWagons(animals.OrderByDescending(animal => animal.Size).ThenByDescending(animal => animal.IsCarnivore).ToList());

            WagonsResult = (wagonOption1.Count < wagonOption2.Count) ? wagonOption1 : wagonOption2;
        }

        public void Clear()
        {
            animals.Clear();
            WagonsResult.Clear();
        }
    }
}
