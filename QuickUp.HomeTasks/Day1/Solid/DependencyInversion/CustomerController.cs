using System;

namespace Solid.DependencyInversion
{
    public class CustomerController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            if (customerService == null)
            {
                throw new ArgumentException("customerService");
            }

            _customerService = customerService;
        }
    }
}
