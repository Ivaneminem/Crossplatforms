using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1.Models
{
    public class Order
    {
        public int Ti { get; }
        public int Ci { get; }

        public Order(int ti, int ci)
        {
            Ti = ti;
            Ci = ci;
        }
    }
}
