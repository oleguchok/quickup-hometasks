using System;

namespace QuickOrder.Entities
{
    public class Order : IEntityBase
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
