using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Models.Queries.GetCustomerList
{
    public class GetCustomerListQuery
    {
        public List<string> CustomerListing()
        {
            CustomerList list = new CustomerList();
            list.LoadJson();

            // Linq query to select all name from customers list
            var queryAllCustomer = from cust in list.customers
                                   select cust.name;

            return queryAllCustomer.ToList();
        }

    }
}
