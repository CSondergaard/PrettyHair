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
        public void CreateCustomer(ICustomer customer)
        {
            CustomerRepository cr = new CustomerRepository();
            cr.CreateCustomer(customer);
        }
    }
}
