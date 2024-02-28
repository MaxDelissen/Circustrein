namespace Circustrein
{
    internal class Program
    {
        static readonly Train Train = new Train();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("What do you want to do? (Add animal (A)/Make train (M)/Add preconfigured animals (R)/Clear Train (C)/Exit (E) : ");
                string? input = Console.ReadLine()?.ToLower();
                switch (input)
                {
                    case "a":
                        Animal newAnimal = MakeAnimal();
                        Train.AddAnimal(newAnimal);
                        break;
                    case "m":
                        Train.MakeTrain();
                        Print();
                        break;
                    case "r": //Default for testing.
                        Train.AddAnimal(new Animal(Size.Small, true));
                        Train.AddAnimal(new Animal(Size.Large, false));
                        Train.AddAnimal(new Animal(Size.Large, false));
                        Train.AddAnimal(new Animal(Size.Small, false));
                        Train.AddAnimal(new Animal(Size.Medium, false));
                        Console.WriteLine("Preconfigured animals added\n");
                        break;
                    case "c":
                        Train.Clear();
                        Console.WriteLine("Train cleared\n");
                        break;
                    case "e":
                        return;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }

        private static Animal MakeAnimal()
        {
            while (true)
            {
                Console.WriteLine("What size is the animal? (S/M/L)");
                string? size = Console.ReadLine()?.ToLower();
                Console.WriteLine("Is the animal a Carnivore or Herbivore? (C/H)");
                string? isCarnivore = Console.ReadLine()?.ToLower();
                Console.WriteLine(); //Empty line for readability
                if (size != null && isCarnivore != null && CheckInput(size, isCarnivore))
                {
                    return new Animal(size, isCarnivore);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }

        private static bool CheckInput(string? size, string? isCarnivore)
        {
            bool validSize = size == "s" || size == "m" || size == "l";
            bool validCarnivore = isCarnivore == "c" || isCarnivore == "h";
            return validSize && validCarnivore;
        }

        private static void Print()
        {
            Console.WriteLine("\n");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine();
            int totalSpaceLeft = 0;
            foreach (Wagon wagon in Train.WagonsResult.OrderBy(wagon => wagon.SpaceLeft).ToList())
            {
                int wagonNumber = Train.WagonsResult.IndexOf(wagon) + 1;
                Console.WriteLine($"Wagon {wagonNumber}:");


                foreach (Animal animal in wagon.GetAnimals())
                {
                    string eats = animal.IsCarnivore ? "carnivore" : "herbivore";
                    Console.WriteLine($"{animal.Size} {eats},");
                }
                Console.WriteLine($"This wagon is filled for {10 - wagon.SpaceLeft} points");
                totalSpaceLeft += wagon.SpaceLeft;
                Console.WriteLine(); //Empty line for readability
            }
            Console.WriteLine($"Total space unused: {totalSpaceLeft}\n");
            Console.WriteLine("-------------------------------------------------------------------------\n\n");
        }
    }
}
