using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static RLCExamples01.Goods;

namespace RLCExamples01
{  
    public class Bill
    {
        private List<Item> _items;
        private Customer _customer;
        public Bill(Customer customer)
        {
            this._customer = customer;
            this._items = new List<Item>();
        }
        public void addGoods(Item arg)
        {
            _items.Add(arg);
        }
        private int GetUsedBonus(decimal thisAmount)
        {
            int usedBonus = _customer.useBonus((int)(thisAmount));
            return usedBonus;
        }
        public BillSummary Process()
        {
            BillSummary billsum = new BillSummary();
            billsum.CustomerName = _customer.getName();
            billsum.items = new List<ItemSummary>();
            List<Item>.Enumerator items = _items.GetEnumerator();
            while (items.MoveNext())
            {
                Item each = (Item)items.Current;
                ItemSummary itemsum = new ItemSummary();

                itemsum.Name =each.getGoods().getTitle();
                itemsum.Bonus = each.GetBonus();
                itemsum.Discount = (decimal)each.GetDiscount();
                itemsum.Quantity = each.getQuantity();
                itemsum.Price = (decimal)each.getPrice();
                // учитываем скидку 
                itemsum.Sum = (decimal)itemsum.Quantity * itemsum.Price - itemsum.Discount;
                int usedBonus = 0;
                // используем бонусы 
                if ((each.getGoods().GetType() ==
                     typeof(RegularGoods)) && itemsum.Quantity > 5)
                    usedBonus = GetUsedBonus(itemsum.Sum);

                if ((each.getGoods().GetType() ==
                     typeof(SpecialOrderGoods)) && itemsum.Quantity > 1)
                    usedBonus = GetUsedBonus(itemsum.Sum);

                itemsum.Sum -= usedBonus;
                //показать результаты 

                billsum.TotalAmount += itemsum.Sum;
                billsum.TotalBonus += itemsum.Bonus;
                billsum.items.Add(itemsum);
            }
            //добавить нижний колонтитул 
            //Запомнить бонус клиента 
            _customer.receiveBonus(billsum.TotalBonus);
            return billsum;
        }
    }
}