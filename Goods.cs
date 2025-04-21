using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RLCExamples01
{
    // Класс, который представляет данные о товаре 
    public class Goods
    {
        protected String _title;
        //protected int _priceCode;

        //public Goods(String title)
        //{
        //    _title = title;
        //    //_priceCode = priceCode;
        //}
        //public int getPriceCode()
        //{
        //    return _priceCode;
        //}
        //public void setPriceCode(int arg)
        //{
        //    _priceCode = arg;
        //}
        public String getTitle()
        {
            return _title;
        }
        //private double GetSum(Item each)
        //{
        //    return each.getQuantity() * each.getPrice();
        //}
        public virtual int GetBonus(int quantity, double price)
        {
            return 0;
        }
        public virtual double GetDiscount(int quantity, double price)
        {
            return 0;
        }
        public class SaleGoods : Goods
        {
            public SaleGoods(string title)
            {
                _title = title;
            }
            public override int GetBonus(int quantity, double price)
            {
                int bonus = (int)(quantity * price * 0.01);
                return bonus;
            }
            public override double GetDiscount(int quantity, double price)
            {
                double discount = 0;
                if (quantity > 3)
                    discount = quantity * price * 0.01; // 0.1% 
                return discount;
            }
        }
        public class RegularGoods : Goods
        {
            public RegularGoods(string title)
            {
                _title = title;
            }
            public override int GetBonus(int quantity, double price)
            {
                int bonus = (int)(quantity * price * 0.05);
                return bonus;
            }
            public override double GetDiscount(int quantity, double price)
            {
                double discount = 0;
                if (quantity > 2)
                    discount = quantity * price * 0.03; // 3% 
                return discount;
            }

        }
        public class SpecialOrderGoods : Goods
        {
            public SpecialOrderGoods(string title)
            {
                _title = title;
            }
            public override int GetBonus(int quantity, double price)
            {
                return 0;
            }
            public override double GetDiscount(int quantity, double price)
            {
                double discount = 0;
                if (quantity > 10)
                    discount = quantity * price * 0.005; // 0.5% 
                return discount;
            }
         //ttt   
        }
    }
}