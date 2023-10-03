class Pizza{
    private string name;
    public string Name { 
        get { return name; }
        set {
            if (!string.IsNullOrEmpty(value) || value.Length <= 15)
            {
                name = value;
            }
            else {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
        }
    }
    private Dough dough;

    private List<Toppings> toppings;

    public Pizza(string name)
    {
        this.Name = name;
        this.toppings = new List<Toppings>();
    }
    public void SetDough(Dough dough)
    {
        this.dough = dough;
    }

    public void AddTopping(Toppings topping)
    {
        if (toppings.Count < 10)
        {
            toppings.Add(topping);
        }
        else
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
    }
}