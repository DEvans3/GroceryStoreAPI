using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Data;

namespace GroceryStoreAPI.Models.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand
    {

        public bool UpdateCustomer(int id, string customerName)
        {
            string fileName = "database.json";
            CustomerList customerList = new CustomerList();
            customerList.LoadJson();

            var index = customerList.customers.FindIndex(c => c.id == id); // finding the index of the given id

            if (index != -1) // checking if an index is not found
            {
                var updateCustomer = customerList.customers[index]; // finding the element of the given id
                
                updateCustomer.name = customerName;

                customerList.customers[index] = updateCustomer; // setting customeList element equal updateCustomer element

                string jsonOutput = JsonSerializer.Serialize(customerList); // serializing customerList object 

                File.WriteAllText(fileName, jsonOutput);

                return true;
            }

            return false;

        }
    }
}
