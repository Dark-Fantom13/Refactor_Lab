using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_лаб_1
{
    public class Strateges
    {
        public interface DiscountStrategy
        {
            public double GetDiscount(int quantity, double price);                
        }
        public interface BonusStrategy
        {
            public int GetBonus(int quantity, double price);
        }
        public class PercentForQuantity: DiscountStrategy
        {
            public double GetDiscount(int quantity, double price)
            {
                double discount = 0;
                if (quantity > 3)
                    discount = quantity * price * 0.01; // 0.1% 
                return discount;
            }
        }
        public class PercentForSum : DiscountStrategy
        {
            public double GetDiscount(int quantity, double price)
            {
                double discount = 0;
                if (quantity * price > 1000)
                    discount = quantity * price * 0.05;
                return discount;
            }
        }

        public class FixedPercentAllways : DiscountStrategy
        {
            public double GetDiscount(int quantity, double price)
            {
                double discount = quantity * price * 0.02;
                return discount;
            }
        }

        public class AmountForQuantity : BonusStrategy
        {
            public int GetBonus(int quantity, double price)
            {
                int bonus = 0;
                if (quantity > 3)
                {
                    bonus = (int)(quantity * price * 0.06);

                }
                return bonus;
            }
        }

        public class FixedAmount : BonusStrategy
        {
            public int GetBonus(int quantity, double price)
            {
                int bonus = (int)(quantity * price * 0.05);
                return bonus;
            }
        }

        public class AmountForSum : BonusStrategy
        {
            public int GetBonus(int quantity, double price)
            {
                int bonus = 0;
                if (quantity > 1000)
                {
                    bonus = (int)(quantity * price * 0.07);

                }
                return bonus;
            }
        }
    }
}
