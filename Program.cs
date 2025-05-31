using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using RLCExamples01;
using static RLCExamples01.Bill;
using static RLCExamples01.BillGenerator;
using static RLCExamples01.Goods;

namespace RLCLab01Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "BillInfo.yaml";
            if (args.Length == 1)
                filename = args[0];

            FileStream fs = new FileStream(filename, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            // Читаем имя клиента
            string line = sr.ReadLine();
            string[] result = line.Split(':');
            string name = result[1].Trim();

            // Читаем бонусы
            line = sr.ReadLine();
            result = line.Split(':');
            int bonus = Convert.ToInt32(result[1].Trim());

            Customer customer = new Customer(name, bonus);
            Bill bill = new Bill(customer); // Больше не передаём view

            // Читаем количество товаров
            line = sr.ReadLine();
            result = line.Split(':');
            int goodsQty = Convert.ToInt32(result[1].Trim());

            Goods[] g = new Goods[goodsQty];

            for (int i = 0; i < g.Length; i++)
            {
                // Пропустить комментарии
                do
                {
                    line = sr.ReadLine();
                } while (line.StartsWith("#"));

                result = line.Split(':');
                result = result[1].Trim().Split();
                string type = result[1].Trim();

                if (type == "REG")
                    g[i] = new RegularGoods(result[0]);
                else if (type == "SAL")
                    g[i] = new SaleGoods(result[0]);
                else if (type == "SPO")
                    g[i] = new SpecialOrderGoods(result[0]);
                else
                    throw new Exception("Неизвестный тип товара: " + type);
            }

            // Читаем количество позиций в чеке
            do
            {
                line = sr.ReadLine();
            } while (line.StartsWith("#"));

            result = line.Split(':');
            int itemsQty = Convert.ToInt32(result[1].Trim());

            for (int i = 0; i < itemsQty; i++)
            {
                do
                {
                    line = sr.ReadLine();
                } while (line.StartsWith("#"));

                result = line.Split(':');
                result = result[1].Trim().Split();

                int gid = Convert.ToInt32(result[0].Trim());
                double price = Convert.ToDouble(result[1].Trim());
                int qty = Convert.ToInt32(result[2].Trim());

                bill.addGoods(new Item(g[gid - 1], qty, price));
            }

            // Используем BillGenerator и View
            IView view = new TxtView(); // Можно заменить на HtmlView
            BillGenerator generator = new BillGenerator( view, bill);
            string output = generator.statement();

            Console.WriteLine(output);
        }
    }
}