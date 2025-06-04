using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLCExamples01
{
    public interface IFileSource
    {
        public Customer GetCustomer();
        public int GetGoodsCount();
        public (string title, string type, string bonusStrategySt, string discountStrategySt) GetNextGood();
        public int GetItemsCount();
        public (int gid, double price, int qty) GetNextItem();
    }
}
