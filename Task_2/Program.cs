internal class Program
{
    private static void Main(string[] args)
    {
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        if (!string.IsNullOrWhiteSpace(name) && (age >= 0 && age <= 15)) {
            Chicken chicken = new Chicken(name, age);
            Console.WriteLine(chicken);
        }
    }
}
class Chicken {
    private string name;
    public string Name {
        get { return name; }
        private set {
            if (!string.IsNullOrWhiteSpace(value))
            {
                name = value;
            }
            else {
                Console.WriteLine("Name cannot be empty.");
                // throw new ArgumentException("Name cannot be empty.");
            }
        }
    }
    private int age;
    public int Age {
        get { return age; }
        private set {
            if (value >= 0 && value <= 15)
            {
                age = value;
            }
            else {
                Console.WriteLine("Age should be between 0 and 15");
            }
        }
    }
    public Chicken(string name, int age) {
        Name = name;
        Age = age;
    }
    private int CalculateProductPerDay(){
        if (Age >= 0 && Age <= 3)
        {
            return 1;
        }
        else if (Age >= 4 && Age <= 7)
        {
            return 2;
        } 
        else if (Age >= 8 && Age <= 11) {
            return 1;
        }
        else { return 0; }
    }
    public override string ToString()
    {
        int ProductPerDay = CalculateProductPerDay();
        return $"Chicken {Name} (age {Age}) can produce {ProductPerDay} eggs per day.";
    }
}