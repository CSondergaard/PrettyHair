using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrettyHair.Core.Interfaces;
using PrettyHair.Core.Repositories;
using PrettyHair.Core.Entities;

namespace PrettyHair.Test
{
    [TestClass]
    public class CustomerTest
    {
        CustomerRepository CR = new CustomerRepository();
        ICustomer tina = new Customer("Tina", "Gurli", 1);
        ICustomer lone = new Customer("Lone", "Andersen", 2);
        ICustomer ulla = new Customer("", "", 3);
        ICustomer karl = new Customer("", "", 4);

        [TestMethod]
        public void EmptyRepo()
        {
            Assert.AreEqual(0, CR.GetAllCustomers().Count);
        }

        [TestMethod]
        public void CanAddCustomers()
        {
            Assert.AreEqual(0, CR.GetAllCustomers().Count);

            CR.CreateCustomer(tina);
            CR.CreateCustomer(lone);
            CR.CreateCustomer(ulla);
            CR.CreateCustomer(karl);

            Assert.AreEqual(4, CR.GetAllCustomers().Count);
        }

        [TestMethod]
        public void CanRemove()
        {
            CanAddCustomers();

            CR.RemoveCustomerByID(1);

            Assert.AreEqual(3, CR.GetAllCustomers().Count);
        }

        [TestMethod]
        public void CanClear()
        {
            CanAddCustomers();
            Assert.AreEqual(4, CR.GetAllCustomers().Count);

            CR.Clear();
            Assert.AreEqual(0, CR.GetAllCustomers().Count);
        }

        [TestMethod]
        public void CanCheckIfUserExists()
        {
            CanAddCustomers();

            Assert.IsTrue(CR.CustomerExistFromID(1));
            Assert.IsFalse(CR.CustomerExistFromID(5));
        }

        [TestMethod]
        public void CanGetCustomer()
        {
            CanAddCustomers();

            Assert.AreSame(ulla, CR.GetCustomerByID(3));
        }

        [TestMethod]
        public void CanWriteToString()
        {
            Assert.AreEqual("[Name: Tina Gurli]", tina.ToString());
        }
    }
}
