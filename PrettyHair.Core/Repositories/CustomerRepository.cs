using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrettyHair.Core.Entities;
using PrettyHair.Core.Interfaces;

namespace PrettyHair.Core.Repositories
{
    public class CustomerRepository
    {
        private Dictionary<int, ICustomer> Customers = new Dictionary<int, ICustomer>();
        public int ID;

        public Dictionary<int, ICustomer> GetAllCustomers()
        {
            return Customers;
        }

        public void CreateCustomer(ICustomer customer)
        {
            // Database call

            AddCustomer(customer, NextID());
        }

        public void RemoveCustomerByID(int ID)
        {
            Customers.Remove(ID);
        }

        public void Clear()
        {
            Customers.Clear();
        }

        public bool CustomerExistFromID(int ID)
        {
            return Customers.ContainsKey(ID);
        }

        public ICustomer GetCustomerByID(int ID)
        {
            return Customers[ID];
        }

        private int NextID()
        {
            ID = EntityKeyGenerator.Instance.NextKey;
            return ID;
        }

        private void AddCustomer(ICustomer customer, int ID)
        {
            Customers.Add(ID, customer);
        }

        public int GetCustomerID(ICustomer customer)
        {
            return ID;
        }
    }
}
