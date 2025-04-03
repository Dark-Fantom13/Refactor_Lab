using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RLCExamples01
{
    // Класс, который представляет данные о товаре 
    public class Goods
    {
        public const int REGULAR = 0;
        public const int SALE = 1;
        public const int SPECIAL_OFFER = 2;

        private String _title;
        private int _priceCode;

        public Goods(String title, int priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }
        public int getPriceCode()
        {
            return _priceCode;
        }
        public void setPriceCode(int arg)
        {
            _priceCode = arg;
        }
        public String getTitle()
        {
            return _title;
        }
        private double GetSum(Item each)
        {
            return each.getQuantity() * each.getPrice();
        }
        //public int GetBonus(Item each)
        //{
        //    int bonus = 0;
        //    switch (each.getGoods().getPriceCode())
        //    {
        //        case Goods.REGULAR:
        //            bonus = (int)(GetSum(each) * 0.05);
        //            break;
        //        case Goods.SALE:
        //            bonus = (int)(GetSum(each) * 0.01);
        //            break;
        //    }
        //    return bonus;
        //}
        public int GetBonus(int quantity, double price)
        {
            int bonus = 0;
            switch (_priceCode)
            {
                case Goods.REGULAR:
                    bonus = (int)(quantity* price * 0.05);
                    break;
                case Goods.SALE:
                    bonus = (int)(quantity * price * 0.01);
                    break;
            }
            return bonus;
        }    
        public double GetDiscount(int quantity, double price)
        {
            double discount = 0;
            switch (_priceCode)
            {
                case Goods.REGULAR:

                    if (quantity > 2)
                        discount = quantity * price * 0.03; // 3% 
                    break;
                case Goods.SPECIAL_OFFER:
                    if (quantity > 10)
                        discount = quantity * price * 0.005; // 0.5% 
                    break;
                case Goods.SALE:
                    if (quantity > 3)
                        discount = quantity * price * 0.01; // 0.1% 
                    break;
            }
            return discount;
        }
    }
}