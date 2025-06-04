using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RLCExamples01
{
    // Класс, представляющий данные о чеке 
    public class Item
    {
        private Goods _Goods;
        private int _quantity;
        private double _price;

        public Item(Goods Goods, int quantity, double price)
        {
            _Goods = Goods;
            _quantity = quantity;
            _price = price;
        }

        public int getQuantity()
        {
            return _quantity;
        }

        public double getPrice()
        {
            return _price;
        }

        public Goods getGoods()
        {
            return _Goods;
        }
        public int GetBonus()
        {
            return _Goods.bonusStrategy.GetBonus(this.getQuantity(), this.getPrice());
        }
        public double GetDiscount()
        {
            return _Goods.discountStrategy.GetDiscount(this.getQuantity(), this.getPrice());
        }
    }
}