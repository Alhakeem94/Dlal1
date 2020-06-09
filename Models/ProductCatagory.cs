using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dalal.Models
{
    public class ProductCatagory
    {
        [Key]
        public int CatagoryId { get; set; }
        public string CatagoryName { get; set; }
      

    }
}
