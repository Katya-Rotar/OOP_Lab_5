class Toppings{
    private string toppingType;
    public string ToppingType {
        get { return toppingType; }
        set
        {
            string[] validTypes = { "meat", "veggies", "cheese", "sauce" };
            if (!validTypes.Contains(value.ToLower()))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            toppingType = value;
            
        }
    }
    private int weight;
    public int Weight {
        get { return weight; }
        set
        {
            if (value > 0 && value <= 50)
            {
                weight = value;
            }
            else {
                throw new ArgumentException($"{ToppingType} weight should be in the range [1..50].");
            }
        }
    }
    public Toppings(string toppingType, int weight) {
        this.ToppingType = toppingType;
        this.Weight = weight;
    }
}