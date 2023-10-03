class Dough{
    private string flourType;
    public string FlourType {
        get { return flourType; }
        set
        {
            if (value.ToLower() == "white" || value.ToLower() == "wholegrain")
            {
                flourType = value;
            }
            else {
                throw new ArgumentException("Invalid type of dough.");
            }
        }
    }
    private string bakingTechnique;
    public string BakingTechnique {
        get { return bakingTechnique; }
        set {
            if (value.ToLower() == "crispy" || value.ToLower() == "chewy" || value.ToLower() == "homemade")
            {
                bakingTechnique = value;
            }
            else {
                throw new ArgumentException("Invalid type of dough.");
            }
        }
    }
    private int weight;
    public int Weight {
        get { return weight; } 
        set {
            if (value > 1 && value < 200)
            {
                weight = value;
            }
            else
            {
                throw new ArgumentException("Dough weight should be in the range [1..200]");
            }
        }
    }
    public Dough(string flourType, string bakingTechnique, int weight) {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }
}