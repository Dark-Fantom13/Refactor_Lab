using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RLCExamples01.Goods;

namespace RLCExamples01
{
    public class GoodsFactory
    {
        public Goods Create(string title, string typeCode)
        {
            switch (typeCode)
            {
                case "REG": return new RegularGoods(title);
                case "SAL": return new SaleGoods(title);
                case "SPO": return new SpecialOrderGoods(title);
                default: throw new ArgumentException($"Неизвестный тип товара: {typeCode}");
            }
        }
    }
}
