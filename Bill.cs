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

        private string GetHeader()
        {
            String result = "Счет для " + _customer.getName() + "\n";
            result += "\t" + "Название" + "\t" + "Цена" +
                      "\t" + "Кол-во" + "Стоимость" + "\t" + "Скидка" +
                      "\t" + "Сумма" + "\t" + "Бонус" + "\n";
            return result;
        }
        private double GetSum(Item each)
        {
            return each.getQuantity() * each.getPrice();
        }
        private string GetItemString(Item each, double discount, double thisAmount, int bonus)
        {
            String result = "\t" + each.getGoods().getTitle() + "\t" +
            "\t" + each.getPrice() + "\t" + each.getQuantity() +
            "\t" + (GetSum(each)).ToString() +
            "\t" + discount.ToString() + "\t" + thisAmount.ToString() +
            "\t" + bonus.ToString() + "\n";
            return result;
        }
        private string GetFooter(double totalAmount, double totalBonus)
        {
            String result = "Сумма счета составляет " + totalAmount.ToString() + "\n";
            result += "Вы заработали " + totalBonus.ToString() + " бонусных балов";
            return result;
        }
        
        private int GetUsedBonus(double thisAmount)
        {
            int usedBonus = _customer.useBonus((int)(thisAmount));
            return usedBonus;
        }
        public String statement()
        {
            double totalAmount = 0;
            int totalBonus = 0;
            List<Item>.Enumerator items = _items.GetEnumerator();
            String result = GetHeader();
            while (items.MoveNext())
            {
                double thisAmount = 0;

                Item each = (Item)items.Current;
                
                int bonus = each.GetBonus();
                double discount = each.GetDiscount();
                
                // учитываем скидку 
                thisAmount = GetSum(each) - discount;
                int usedBonus = 0;
                // используем бонусы 
                if ((each.getGoods().GetType() ==
                     typeof(RegularGoods)) && each.getQuantity() > 5)
                    usedBonus = GetUsedBonus(thisAmount);

                if ((each.getGoods().GetType() ==
                     typeof(SpecialOrderGoods)) && each.getQuantity() > 1)
                    usedBonus = GetUsedBonus(thisAmount);

                thisAmount -= usedBonus;
                //показать результаты 
                result += GetItemString(each, discount, thisAmount, bonus);

                totalAmount += thisAmount;
                totalBonus += bonus;
            }
            //добавить нижний колонтитул 
            result += GetFooter(totalAmount,totalBonus);

            //Запомнить бонус клиента 
            _customer.receiveBonus(totalBonus);

            return result;
        }


    }
}