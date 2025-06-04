using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RLCExamples01.Goods;
using static РРУК_лаб_1.Strateges;

namespace RLCExamples01
{
    public class GoodsFactory
    {
        public Goods Create(string title, string typeCode, string bonusStrategySt, string discountStrategySt)
        {
            BonusStrategy bonusStrategy;
            DiscountStrategy discountStrategy;

            switch (bonusStrategySt)
            {
                case "AFQ": bonusStrategy = new AmountForQuantity(); break;
                case "FA": bonusStrategy = new FixedAmount(); break;
                case "AFS": bonusStrategy = new AmountForSum(); break;
                default: throw new ArgumentException($"Неизвестный тип товара: {typeCode}");
            }
            switch (discountStrategySt)
            {
                case "PFQ": discountStrategy = new PercentForQuantity(); break;
                case "PFS": discountStrategy = new PercentForSum(); break;
                case "FPA": discountStrategy = new FixedPercentAllways(); break;
                default: throw new ArgumentException($"Неизвестный тип товара: {typeCode}");
            }
            switch (typeCode)
            {
                case "REG": return new RegularGoods(title, bonusStrategy, discountStrategy);
                case "SAL": return new SaleGoods(title, bonusStrategy, discountStrategy);
                case "SPO": return new SpecialOrderGoods(title, bonusStrategy, discountStrategy);
                default: throw new ArgumentException($"Неизвестный тип товара: {typeCode}");
            }
        }
    }
}
