using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLCExamples01;
using static RLCExamples01.Goods;

namespace RLCExamples01
{
    public class BillGenerator
    {
        private IView view;
        private Bill _bill;
        public interface IView
        {
            string GetBill(BillSummary billsum);
            string GetOutput(BillSummary billsum);
            string GenerateBill(ItemSummary itemInfo);
        }
        public BillGenerator(IView view, Bill bill)
        {
            this.view = view;
            _bill = bill;
        }
        public void addGoods(Item arg)
        {
            _bill.addGoods(arg);
        }
        public class TxtView : IView
        {
            public string GetBill(BillSummary billsum)
            {
                String result = "Счет для " + billsum.CustomerName + "\n";
                result += "\t" + "Название" + "\t" + "Цена" +
                          "\t" + "Кол-во" + "Стоимость" + "\t" + "Скидка" +
                          "\t" + "Сумма" + "\t" + "Бонус" + "\n";
                return result;
            }
            public string GetOutput(BillSummary billsum)
            {
                String result = "Сумма счета составляет " + billsum.TotalAmount.ToString() + "\n";
                result += "Вы заработали " + billsum.TotalBonus.ToString() + " бонусных балов";
                return result;
            }
            public string GenerateBill(ItemSummary itemInfo)
            {
                String result = "\t" + itemInfo.Name + "\t" +
                "\t" + itemInfo.Price + "\t" + itemInfo.Quantity +
                "\t" + ((decimal)itemInfo.Quantity * itemInfo.Price).ToString() +
                "\t" + itemInfo.Discount + "\t" + itemInfo.Sum.ToString() +
                "\t" + itemInfo.Bonus.ToString() + "\n";
                return result;
            }
        }
        public class HtmlView : IView
        {
            public string GetBill(BillSummary billsum)
            {
                String result = "Счет для " + billsum.CustomerName + "\n";
                result += "\t" + "Название" + "\t" + "Цена" +
                          "\t" + "Кол-во" + "Стоимость" + "\t" + "Скидка" +
                          "\t" + "Сумма" + "\t" + "Бонус" + "\n";
                return result;
            }
            public string GetOutput(BillSummary billsum)
            {
                String result = "Сумма счета составляет " + billsum.TotalAmount.ToString() + "\n";
                result += "Вы заработали " + billsum.TotalBonus.ToString() + " бонусных балов";
                return result;
            }
            public string GenerateBill(ItemSummary itemInfo)
            {
                String result = "\t" + itemInfo.Name + "\t" +
                "\t" + itemInfo.Price + "\t" + itemInfo.Quantity +
                "\t" + ((decimal)itemInfo.Quantity * itemInfo.Price).ToString() +
                "\t" + itemInfo.Discount + "\t" + itemInfo.Sum.ToString() +
                "\t" + itemInfo.Bonus.ToString() + "\n";
                return result;
            }
        }
        public String statement()
        {
            BillSummary billsum = _bill.Process();
            List<ItemSummary>.Enumerator items = billsum.items.GetEnumerator();
            String result = view.GetBill(billsum);
            while (items.MoveNext())
            {
                ItemSummary each = (ItemSummary)items.Current;
                result += view.GenerateBill(each);
            }
            //добавить нижний колонтитул 
            result += view.GetOutput(billsum);
            return result;
        }
    }
}
