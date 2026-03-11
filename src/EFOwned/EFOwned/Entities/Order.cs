namespace EFOwned.Entities;

public class Order
{
   public DateTime OrderDate { get; set; } 
   public Bucket Bucket { get; set; }
}