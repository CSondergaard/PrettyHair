using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrettyHair.Core.Entities;
using PrettyHair.Core.Interfaces;

namespace PrettyHair.Core.Repositories
{
    public class OrderlineRepository
    {
        private Dictionary<int, IOrderline> Orderlines = new Dictionary<int, IOrderline>();
        private int ID;

        public Dictionary<int, IOrderline> GetAllOrderlines()
        {
            return Orderlines;
        }

        public void CreateOrderline(IOrderline orderline)
        {
            AddOrderline(orderline, NextID());
        }

        private void AddOrderline(IOrderline orderline, int ID)
        {
            Orderlines.Add(ID, orderline);
        }

        public void RemoveByID(int ID)
        {
            Orderlines.Remove(ID);
        }

        public void Clear()
        {
            Orderlines.Clear();
        }

        public IOrderline GetOrderlineByID(int ID)
        {
            return Orderlines[ID];
        }

        private int NextID()
        {
            return EntityKeyGenerator.Instance.NextKey;

        }
    }
}
