using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GroceryStoreAPI.Models;
using GroceryStoreAPI.Models.Commands.AddCustomer;
using GroceryStoreAPI.Models.Commands.DeleteCustomer;
using GroceryStoreAPI.Models.Commands.UpdateCustomer;
using GroceryStoreAPI.Models.Queries.GetCustomer;
using GroceryStoreAPI.Models.Queries.GetCustomerList;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IList<string>> Get()
        {
            GetCustomerListQuery listing = new GetCustomerListQuery();
            List<string> names = listing.CustomerListing();

            return names;
        }                

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            GetCustomerQuery customer = new GetCustomerQuery();
            string customerName = customer.GetCustomer(id);

            return customerName;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromForm] string value)
        {
            AddCustomerCommend newCustomer = new AddCustomerCommend();
            newCustomer.AddCustomer(value);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm] string value)
        {
            UpdateCustomerCommand updateCustomer = new UpdateCustomerCommand();
            updateCustomer.UpdateCustomer(id, value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DeleteCustomerCommand deleteCustomer = new DeleteCustomerCommand();
            deleteCustomer.DeleteCustomer(id);
        }
    }
}
