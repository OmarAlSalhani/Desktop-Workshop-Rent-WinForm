using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app7.products_forms
{
    public class products_model
    {
        public string product_name { get; set; }
        public int quantity { get; set; }
        public double daily_rent_before_tax { get; set; }
        public double daily_rent_tax { get; set; }
        public double total { get; set; }
    }
}
