internal class Program
{
    private static void Main(string[] args)
    {
        List<Person> people = new List<Person>();
        List<Product> products = new List<Product>();
        try
        {
            string[] input_people = Console.ReadLine().Split(' '); // пропускати пробіли
            for (int i = 0; i < input_people.Length; i += 2)
            {
                string name_person = input_people[i];
                int money = int.Parse(input_people[i + 1]);
                if (IsValidName(name_person) && IsValidMoney(money))
                {
                    Person person = new Person(name_person, money);
                    people.Add(person);
                }
            }
            string[] input_product = Console.ReadLine().Split(' ');
            for (int i = 0; i < input_product.Length; i += 2)
            {
                string name_product = input_product[i];
                int cost = int.Parse(input_product[i + 1]);
                if (IsValidName(name_product) && IsValidMoney(cost))
                {
                    Product product = new Product(name_product, cost);
                    products.Add(product);
                }
            }
            
            List<Bag> purchases = new List<Bag>();
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "END") { break; }
                else
                {
                    for (int i = 0; i < input.Length; i += 2)
                    {
                        string input_name_person = input[i];
                        string input_name_product = input[i + 1];
                        bool purcha = BuyProduct(products, people, input_name_person, input_name_product);
                        if (purcha)
                        {
                            Bag bag = new Bag(input_name_person, input_name_product);
                            purchases.Add(bag);
                        }

                    }
                }
            }
            Print(purchases, people);
        }
        catch (ArgumentException e) {
            Console.WriteLine(e.Message);
        }
    }
    public static void Print(List<Bag> purchases, List<Person> people)
    {
        for (int i = 0; i < people.Count; i++) {
            Console.Write("\n"+ people[i].Name + " - ");
            for(int j = 0; j < purchases.Count; j++)
            {
                if (purchases[j].Name == people[i].Name)
                {
                    Console.Write(purchases[j].Product + " ");
                }
            }
            
        }
    }
    public static bool BuyProduct(List<Product> products, List<Person> people, string name_person, string name_product) {
        for (int i = 0; i < people.Count; i++) {
            if (people[i].Name == name_person) {
                for (int j = 0; j < products.Count; j++) {
                    if (products[j].Name == name_product) {
                        int new_money = people[i].Money - products[j].Cost;
                        if (new_money >= 0)
                        {
                            people[i].Money = new_money;
                            Console.WriteLine($"{name_person} bought {name_product}");
                            return true;
                            break;
                        }
                        else {
                            Console.WriteLine($"{name_person} can't afford {name_product}");
                        }
                    }
                }
            }
        }
        return false;
    }
    private static bool IsValidName(string name)
    {
        return !string.IsNullOrEmpty(name);
    }
    private static bool IsValidMoney(int money) { return money > 0; }
}
internal class Person
{
    private string name;
    public string Name
    {
        get { return name; }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                name = value;
            }
            else
            {
                throw new ArgumentException("Name cannot be empty");
            }
        }
    }
    private int money;
    public int Money
    {
        get { return money; }
        set { 
            if (value >= 0) money = value;
            else { throw new ArgumentException("Money cannot be negative"); }
        }
    }
    public Person(string name, int money)
    {
        this.name = name;
        this.money = money;
    }
}
internal class Product
{
    private string name;
    public string Name
    {
        get { return name; }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                name = value;
            }
            else
            {
                throw new ArgumentException("Name cannot be empty");
            }
        }
    }
    private int cost;
    public int Cost {
        get { return cost; }
        set {
            if (value > 0) cost = value;
            else { throw new ArgumentException("Cost cannot be negative"); }
        }
    }

    public Product(string name, int cost)
    {
        this.name = name;
        this.cost = cost;
    }
}
class Bag {
    private string name;
    private string product;
    public string Name {
        get { return name; }
        set { name = value; }
    }
    public string Product {
        get { return product; }
        set { product = value; }
    }
    public Bag(string name, string product)
    {
        this.Name = name;
        this.Product = product;
    }
}