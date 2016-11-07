﻿namespace TestApp.DAL.Model
{
    public class Order
    {
        public int Id { get; set; }
        public double Amount { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
