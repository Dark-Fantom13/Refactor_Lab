using System;
using System.IO;

namespace RLCExamples01
{
    public class YamlFileSource:IFileSource
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
            } while (line != null && line.StartsWith("#"));
            return line;
        }

        public Customer GetCustomer()
        {
            string line = GetNextLine();
            string[] result = line.Split(':');
            string name = result[1].Trim();

            line = GetNextLine();
            result = line.Split(':');
            int bonus = Convert.ToInt32(result[1].Trim());

            return new Customer(name, bonus);
        }

        public int GetGoodsCount()
        {
            string line = GetNextLine();
            string[] result = line.Split(':');
            return Convert.ToInt32(result[1].Trim());
        }

        public (string title, string type) GetNextGood()
        {
            string line = GetNextLine();
            string[] result = line.Split(':');
            string[] parts = result[1].Trim().Split();
            return (parts[0], parts[1]);
        }

        public int GetItemsCount()
        {
            string line = GetNextLine();
            string[] result = line.Split(':');
            return Convert.ToInt32(result[1].Trim());
        }

        public (int gid, double price, int qty) GetNextItem()
        {
            string line = GetNextLine();
            string[] result = line.Split(':');
            string[] parts = result[1].Trim().Split();

            int gid = Convert.ToInt32(parts[0].Trim());
            double price = Convert.ToDouble(parts[1].Trim());
            int qty = Convert.ToInt32(parts[2].Trim());

            return (gid, price, qty);
        }
    }
}
