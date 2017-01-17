using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrettyHair.Core.Interfaces;

namespace PrettyHair.Core.Entities
{
    public class Order : IOrder
    {
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int CustomerID { get; set; }
        public bool Processed { get; set; }

        public int ID { get; set; }

        public Order(DateTime deliverydate, DateTime orderdate, int cID)
        {
            if ((DateTime.Compare(deliverydate, orderdate)) < 0)
                throw new ArgumentOutOfRangeException();

            DeliveryDate = deliverydate;
            OrderDate    = orderdate;
            CustomerID   = cID;
            Processed    = false;
        }
    }
}
