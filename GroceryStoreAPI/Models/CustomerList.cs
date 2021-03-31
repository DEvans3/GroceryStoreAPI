using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GroceryStoreAPI.Models
{

    public class CustomerList
    {
        public List<Customer> customers { get; set; }

        public CustomerList() // contructor to initialize teh customer object
        {
            customers = new List<Customer>();
        }

        public void LoadJson() // method to load and deserialize json file
        {
            string fileName = "database.json";
            int tempId;
            string tempName;

            StreamReader streamReader = new StreamReader(fileName);
            string json = streamReader.ReadToEnd();

            dynamic input = JsonConvert.DeserializeObject(json);

            foreach (var inputAttribute in input.customers) // loop to grab data from json file and add values to a dynamic list
            {

                tempId = (int)inputAttribute.id;
                tempName = (string)inputAttribute.name;

                customers.Add(new Customer()
                {
                    id = tempId,
                    name = tempName
                });

                
            }

            streamReader.Close();
        }

        public int IdTracker() // medthod to keep track of customer id
        {
            int count = 0;
            foreach(Customer id in customers)
            {
                count++;
            }

            return count;
        }
    }
}


