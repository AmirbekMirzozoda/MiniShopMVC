namespace MiniShopMVC.Models.Entities;

public class Order : BaseEntity
{
    public DateTime OrderDate { get; set; }
    public string CustomerName { get; set; } = null!;
    public string CustomerPhone { get; set; } = null!;
    public int Status { get; set; }
    
    public ICollection<ProductOrder> ProductOrders { get; set; } = null!;
}