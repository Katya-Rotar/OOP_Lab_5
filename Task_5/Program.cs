internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Console.Write("Pizza ");
            string namePizza = Console.ReadLine();
            Pizza pizza = new Pizza(namePizza); //перевірка імені

            Console.Write("Dough ");
            string[] inputDough = Console.ReadLine().Split(' ');
            string flourType = inputDough[0];
            string bakingTechnique = inputDough[1];
            int weight = int.Parse(inputDough[2]);
            Dough dough = new Dough(flourType, bakingTechnique, weight);
            pizza.SetDough(dough);
            double caloriesDough = CalculateCaloriesDough(flourType, bakingTechnique, weight);

            double caloriesToppings = 0;
            while (true)
            {
                string[] inputTopping = Console.ReadLine().Split(' ');
                if (inputTopping[0] == "END") { break; }
                else
                {
                    string topping = inputTopping[1];
                    int weightTopping = int.Parse(inputTopping[2]);
                    double calories = CalculateCaloriesToppings(topping, weightTopping);

                    caloriesToppings += calories;
                    Toppings toppings = new Toppings(topping, weightTopping);
                    pizza.AddTopping(toppings);
                }
            }
            double sumCalories = caloriesDough + caloriesToppings;
            Console.WriteLine($"{namePizza} - {sumCalories} Calories.");
        }
        catch (ArgumentException e) {
            Console.WriteLine(e.Message);
        }
    }
    public static double CalculateCaloriesDough(string flourType, string bakingTechnique, int weight)
    {
        double calories = 2 * weight;

        if (flourType.ToLower() == "white")
        {
            calories *= 1.5;
        }

        if (bakingTechnique.ToLower() == "crispy")
        {
            calories *= 0.9;
        }
        else if (bakingTechnique.ToLower() == "chewy")
        {
            calories *= 1.1;
        }

        return calories;
    }
    public static double CalculateCaloriesToppings(string topping, int weightTopping)
    {
        double calories = 2 * weightTopping;

        switch (topping.ToLower())
        {
            case "meat":
                calories *= 1.2;
                break;
            case "veggies":
                calories *= 0.8;
                break;
            case "cheese":
                calories *= 1.1;
                break;
            case "sauce":
                calories *= 0.9;
                break;
        }

        return calories;
    }
}