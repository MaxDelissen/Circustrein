namespace Circustrein
{
    public class Animal
    {
        public Size Size { get; private set; }
        public bool IsCarnivore { get; private set; }

        public Animal(string size, string isCarnivore)
        {
            switch (size)
            {
                case "s":
                    Size = Size.Small;
                    break;
                case "m":
                    Size = Size.Medium;
                    break;
                case "l":
                    Size = Size.Large;
                    break;
                default:
                    throw new ArgumentException("Invalid size");
            }

            switch (isCarnivore)
            {
                case "c": //Carnivore
                    IsCarnivore = true;
                    break;
                case "h": //Herbivore
                    IsCarnivore = false;
                    break;
                default:
                    throw new ArgumentException("Invalid input");
            }
        }
    }
}
