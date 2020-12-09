using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_StoreV10.Models
{
    public class Order
    {     
        public int OrderID { get; set; }          
        public Student Student { get; set; }
        public List<OrderLine> orderLines { get; set; }
        public DateTime DateTime { get; set; }
    }
}
