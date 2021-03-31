using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Models.Queries.GetCustomer
{
    public class GetCustomerQuery
    {
        public string GetCustomer(int id)
        {
            string customer = "Customer not found"; // default output
            CustomerList customerList = new CustomerList();
            customerList.LoadJson();

            var queryCustomer = (from cust in customerList.customers
                                 where cust.id == id
                                 select cust.name).FirstOrDefault();

            if (queryCustomer != null)
            {
                customer = queryCustomer;
            }


            return customer;

        }
    }
}
