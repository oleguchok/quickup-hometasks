using System.Collections.Generic;

namespace QuickOrder.Entities
{
    public class Product : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int OrderId { get; set; }
        public List<Order> Orders { get; set; }
    }
}
