using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static РРУК_лаб_1.Strateges;

namespace RLCExamples01
{
    public static class BillFactory
    {
        public static Bill CreateBill(IFileSource content)
        {
            Customer customer = content.GetCustomer();
            Bill bill = new Bill(customer);
            GoodsFactory goodsFactory = new GoodsFactory();

            int goodsCount = content.GetGoodsCount();
            Goods[] goods = new Goods[goodsCount];

            for (int i = 0; i < goodsCount; i++)
            {
                var (title, type, bonusStrategySt, discountStrategySt) = content.GetNextGood();
                goods[i] = goodsFactory.Create(title, type, bonusStrategySt, discountStrategySt);
            }

            int itemsCount = content.GetItemsCount();
            for (int i = 0; i < itemsCount; i++)
            {
                var (gid, price, qty) = content.GetNextItem();
                bill.addGoods(new Item(goods[gid - 1], qty, price));
            }

            return bill;
        }
    }
}

