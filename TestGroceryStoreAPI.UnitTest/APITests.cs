using GroceryStoreAPI.Models;
using GroceryStoreAPI.Models.Commands.AddCustomer;
using GroceryStoreAPI.Models.Commands.DeleteCustomer;
using GroceryStoreAPI.Models.Commands.UpdateCustomer;
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
        public void IdTracker_TrackCustomerIds_ReturnsInt()
        {
            // Arrange
            var count = new CustomerList();
            // Act
            var countNum = count.IdTracker();
            // Assert
            Assert.IsNotNull(countNum);
        }

        [TestMethod]
        public void GetCustomer_CustomerName_ReturnsString()
        {
            // Arrange
            var customer = new GetCustomerQuery();
            // Act
            var result = customer.GetCustomer(2);
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetCustomer_CustomerNameNotFound_ReturnsString()
        {
            // Arrange
            var customer = new GetCustomerQuery();
            // Act
            var result = customer.GetCustomer(0);
            // Assert
            Assert.AreEqual(result, "Customer not found");
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
        public void AddCustomer_AddCustomertoJsonFile_ReturnsTrue()
        {
            // Arrange
            string name = "Doe";
            var addCustomer = new AddCustomerCommend();

            // Act
            var result = addCustomer.AddCustomer(name);

            // Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void AddCustomer_AddCustomertoJsonFile_ReturnsFalse()
        {
            // Arrange
            string name = null;
            var addCustomer = new AddCustomerCommend();

            // Act
            var result = addCustomer.AddCustomer(name);

            // Assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void UpdateCustomer_UpdateCustomerinJsonFile_ReturnsTrue()
        {
            // Arrange
            var updateCustomer = new UpdateCustomerCommand();
            // Act
            var result = updateCustomer.UpdateCustomer(2, "Larry");
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UpdateCustomer_UpdateCustomerinJsonFile_ReturnsFalse()
        {
            // Arrange
            var updateCustomer = new UpdateCustomerCommand();
            // Act
            var result = updateCustomer.UpdateCustomer(-1, "Larry");
            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DeleteCustomer_DeleteCustomerfromJsonFile_ReturnsFalse()
        {
            // Arrange
            var deleteCustomer = new DeleteCustomerCommand();
            // Act
            var result = deleteCustomer.DeleteCustomer(-1);
            // Assert
            Assert.IsFalse(result);
        }

    }
}
