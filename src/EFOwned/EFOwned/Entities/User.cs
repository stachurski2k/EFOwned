namespace EFOwned.Entities;

public class User 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Address HomeAddress { get; set; }
    public Address WorkAddress { get; set; }
}
