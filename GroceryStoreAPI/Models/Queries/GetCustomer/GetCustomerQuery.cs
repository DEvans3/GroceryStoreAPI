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

            // query to return a single customer based on id
            var queryCustomer = (from cust in customerList.customers
                                 where cust.id == id
                                 select cust.name).FirstOrDefault();

            if (!string.IsNullOrEmpty(queryCustomer))
            {
                customer = queryCustomer;

                return customer;
            }

            return customer;

        }
    }
}
