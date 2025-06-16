using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace DEMKA
{
    public class Partner
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string Phone { get; set; }
        public int Rating { get; set; }
        public int Quantity { get; set; }
        public int Discount => CalculateDiscount(Quantity);

        private int CalculateDiscount (decimal totalSales)
        {
            if (Quantity < 10000) return 0;
            if (Quantity < 50000) return 5;
            if (Quantity < 300000) return 10;
            return 15;
        }
    }

}
