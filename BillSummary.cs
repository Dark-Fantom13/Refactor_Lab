using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLCExamples01;

namespace RLCExamples01
{
    public class BillSummary
    {
        public decimal TotalAmount;
        public decimal TotalDiscount;
        public string CustomerName;
        public int TotalBonus;
        public List<ItemSummary> items;
    }
}
