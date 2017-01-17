using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrettyHair.Core.Entities;
using PrettyHair.Core.Interfaces;

namespace PrettyHair.Core.Repositories
{
    public class OrderRepository
    {
        private Dictionary<int, IOrder> Orders = new Dictionary<int, IOrder>();
        public int ID;

        public Dictionary<int, IOrder> GetAllOrders()
        {
            return Orders;
        }

        public void CreateOrder(IOrder order)
        {
            AddOrder(order, NextID());
        }

        private void AddOrder(IOrder order, int ID)
        {
            Orders.Add(ID, order);
        }
        
        public void RemoveByID(int ID)
        {
            Orders.Remove(ID);
        }

        public void Clear()
        {
            Orders.Clear();
        }

        public IOrder GetOrderByID(int ID)
        {
            return Orders[ID];
        }

        private int NextID()
        {
            ID = KeyFactory.GetKey(1);
            
            return ID;
        }
    }
}
