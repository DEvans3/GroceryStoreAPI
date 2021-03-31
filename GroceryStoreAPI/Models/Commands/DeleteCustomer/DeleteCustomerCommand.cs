using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Models.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand
    {
        public bool DeleteCustomer(int id)
        {
            string fileName = "database.json";
            CustomerList customerList = new CustomerList();
            customerList.LoadJson();

            var index = customerList.customers.FindIndex(c => c.id == id); // find the index of the given id

            if (index != -1)
            {
                customerList.customers.RemoveAt(index); // removing element at provided index

                string jsonOutput = JsonSerializer.Serialize(customerList); // serializing customerList object 

                File.WriteAllText(fileName, jsonOutput); // Overwritting database.json

                return true;
            }

            return false;

        }
    }
}
