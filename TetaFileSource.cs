using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RLCExamples01
{
    public class TetaFileSource:IFileSource
    {
        private TextReader _reader;
        public void SetSource(TextReader reader)
        {
            _reader = reader;
        }
        private string GetNextLine()
        {
            string line;
            do
            {
                line = _reader.ReadLine();
            } while (line != null && line.StartsWith("X_X"));
            return line;
        }
        public Customer GetCustomer()
        {
            string line = GetNextLine();
            string[] result = line.Split(" cust");
            string name = result[1].Trim();

            line = GetNextLine();
            result = line.Split(" cust");
            int bonus = Convert.ToInt32(result[1].Trim());

            return new Customer(name, bonus);
        }
        public int GetGoodsCount()
        {
            string line = GetNextLine();
            string[] result = line.Split(" good");
            return Convert.ToInt32(result[1].Trim());
        }

        public (string title, string type, string bonusStrategySt, string discountStrategySt) GetNextGood()
        {
            string line = GetNextLine();
            string[] result = line.Split(" good");
            string[] parts = result[1].Trim().Split();
            return (parts[0], parts[1], parts[2], parts[3]);
        }

        public int GetItemsCount()
        {
            string line = GetNextLine();
            string[] result = line.Split(" item");
            return Convert.ToInt32(result[1].Trim());
        }

        public (int gid, double price, int qty) GetNextItem()
        {
            string line = GetNextLine();
            string[] result = line.Split(" item");
            string[] parts = result[1].Trim().Split();

            int gid = Convert.ToInt32(parts[0].Trim());
            double price = Convert.ToDouble(parts[1].Trim());
            int qty = Convert.ToInt32(parts[2].Trim());

            return (gid, price, qty);
        }
    }
}
