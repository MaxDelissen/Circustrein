﻿namespace Circustrein
{
    public class Train
    {
        public List<Animal> Animals { get; private set; } = new List<Animal>();
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
            Animals = Animals.OrderByDescending(animal => animal.Size).ToList();

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
                if (!animalAdded)
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