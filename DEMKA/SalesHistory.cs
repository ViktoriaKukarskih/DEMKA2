﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMKA
{
    public class SalesHistory
    {
        public int ParthnerProductsId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
