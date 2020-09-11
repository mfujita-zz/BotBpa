using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotBpa
{
    class Product
    {
        public string Name { get; set; }
        public string Price { get; set; }

        public Product(string _n, string _p)
        {
            Name = _n;
            Price = _p;
        }
    }
}
