public class LoyalityProgramUser
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int LoyalityPoints { get; set; }
    public LoyalityProgramSettings Settings { get; set; }
}