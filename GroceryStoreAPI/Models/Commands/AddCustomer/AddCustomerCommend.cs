using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Models.Commands.AddCustomer
{
    public class AddCustomerCommend
    {
        public bool AddCustomer(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                CustomerList customer = new CustomerList();
                string fileName = "database.json";

                customer.LoadJson();

                int count = customer.IdTracker();

                customer.customers.Add(new Customer() // adding new element to CustommerList
                {
                    id = count + 1,
                    name = name
                });                
                
                string jsonOutput = JsonSerializer.Serialize(customer); // serializing customerList object 
                File.WriteAllText(fileName, jsonOutput);

                return true;
            }

            return false;
        }

    }
}
