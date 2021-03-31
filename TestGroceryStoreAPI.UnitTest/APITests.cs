using GroceryStoreAPI.Models;
using GroceryStoreAPI.Models.Commands.AddCustomer;
using GroceryStoreAPI.Models.Queries.GetCustomer;
using GroceryStoreAPI.Models.Queries.GetCustomerList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace TestGroceryStoreAPI.UnitTest
{
    [TestClass]
    public class APITests
    {
        [TestMethod]
        public void LoadJson_DeserializeFile_FileElements()
        {
            // Arrange
            string jsonFile = "datafile.json";
            var load = new CustomerList();

            // Act
            load.LoadJson();
            dynamic input = JsonConvert.DeserializeObject(jsonFile);

            //Assert
            Assert.IsNotNull(input);
        }

        [TestMethod]
        public void IdTracker_TrackCustomerIds_ReturnsInt()
        {
            // Arrange
            int countId = 0;
            int countNum;
            var count = new CustomerList();

            // Act
            countNum = count.IdTracker();
            foreach (Customer id in count.customers)
            {
                countId++;
            }
            // Assert
            Assert.AreEqual(countId, countNum);
        }

        [TestMethod]
        public void GetCustomer_CustomerName_ReturnsString()
        {
            // Arrange
            var customer = new GetCustomerQuery();
            int id = 0;
            // Act
            var result = customer.GetCustomer(id);
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetCustomerList_CustomerNameList_ReturnsList()
        {
            // Arrange
            var customerList = new GetCustomerListQuery();
            // Act
            var result = customerList.CustomerListing();
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AddCustomer_AddCustomertoJsonFile_FileAppend()
        {
            // Arrange
            string name = "Doe";
            var addCustomer = new AddCustomerCommend();

            // Act
            addCustomer.AddCustomer(name);

            // Assert
            

        }

        [TestMethod]
        public void UpdateCustomer_UpdateCustomerinJsonFile_FileUpdate()
        {
            // Arrange

            // Act

            // Assert
        }

        [TestMethod]
        public void DeleteCustomer_DeleteCustomerfromJsonFile_DeleteElement()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
