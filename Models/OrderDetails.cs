using System.ComponentModel.DataAnnotations;

namespace SneakerShopPostgreSQL.Models
{
    public class OrderDetails
    {
        public int ID { get; set; }
        public int InventoryID { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public Inventory Inventory { get; set; }
        public Order Order { get; set; }
    }
}
