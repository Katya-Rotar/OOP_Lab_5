internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Довжина: ");
        double length = double.Parse(Console.ReadLine());
        Console.Write("Ширина: ");
        double width = double.Parse(Console.ReadLine());
        Console.Write("Висота: ");
        double height = double.Parse(Console.ReadLine());
        Box box = new Box(length, width, height);
        if (length > 0 && width > 0 && height > 0)
        {
            Console.WriteLine($"Площа поверхні = {box.Surface_Area()}\n" +
                $"Площа бічної поверхні = {box.Lateral_Surface_Area()}\n" +
                $"Об’єм = {box.Volume()}");
        }
    }
}
class Box {
    private double length;
    public double Length {
        get { return length; }
        private set
        {
            if (value > 0)
            {
                length = value;
            }
            else {
                Console.WriteLine("Length cannot be zero or negative.");
            }
        } 
    }
    private double width;
    public double Width {
        get { return width; }
        private set
        {
            if (value > 0)
            {
                width = value;
            }
            else
            {
                Console.WriteLine("Width cannot be zero or negative.");
            }
        } 
    }
    private double height;
    public double Height {
        get { return height; }
        private set
        {
            if (value > 0)
            {
                height = value;
            }
            else
            {
                Console.WriteLine("Width cannot be zero or negative.");
            }
        }
    }

    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }
    public double Volume() {
        return Length * Width * Height;
    }
    public double Lateral_Surface_Area() {
        return (2 * Length * Height) + (2 * Width * Height);
    }
    public double Surface_Area() {
        return (2 * Length * Width) + (2 * Length * Height) + (2 * Width * Height);
    }
}