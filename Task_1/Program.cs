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
        Console.WriteLine($"Площа поверхні = {box.Surface_Area()}\n" +
            $"Площа бічної поверхні = {box.Lateral_Surface_Area()}\n" +
            $"Об’єм = {box.Volume()}");
    }
}
class Box {
    private double Length { get; set; }
    private double Width { get; set; }
    private double Height { get; set; }

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