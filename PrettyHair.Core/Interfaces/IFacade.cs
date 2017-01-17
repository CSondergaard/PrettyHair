using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHair.Core.Interfaces
{
    interface IFacade
    {
        void CreateNewCustomer(ICustomer customer);

        void RemoveCustomer(ICustomer customer);

        void AddItem(IItem item);

        void RemoveItem(IItem item);

        void CreateOrder(IOrder order);

        void RemoveOrder(IOrder order);
    }
}
