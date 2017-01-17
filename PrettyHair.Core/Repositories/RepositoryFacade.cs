using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrettyHair.Core.Interfaces;

namespace PrettyHair.Core.Repositories
{
    class RepositoryFacade : IFacade
    {
        private static RepositoryFacade instance;

        private RepositoryFacade() { }

        public static RepositoryFacade Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new RepositoryFacade();
                }
                return instance;
            }
        }

        public void AddItem(IItem item)
        {
            ItemRepository it = new ItemRepository();
            it.CreateItem(item);
        }

        public void CreateNewCustomer(ICustomer customer)
        {
            CustomerRepository cr = new CustomerRepository();
            cr.CreateCustomer(customer);
        }

        public void CreateOrder(IOrder order)
        {
            throw new NotImplementedException();
        }

        public void RemoveCustomer(ICustomer customer)
        {
            CustomerRepository cr = new CustomerRepository();
            cr.RemoveCustomerByID(customer.id);
        }

        public void RemoveItem(IItem item)
        {
            ItemRepository it = new ItemRepository();
            it.RemoveItemByID(item.id);
        }

        public void RemoveOrder(IOrder order)
        {
            throw new NotImplementedException();
        }
    }
}
