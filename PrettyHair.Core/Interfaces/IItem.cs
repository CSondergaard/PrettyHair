using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHair.Core.Interfaces
{
    public interface IItem
    {
        string Name { get; set; }
        double Price { get; set; }
        int Amount { get; set; }
        string Description { get; set; }

        int id { get; set; }

        void AdjustPrice(double price);
        void AdjustAmount(int offset);
        void AdjustDescription(string desc);
    }
}
