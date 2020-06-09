using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dalal.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }

        [DisplayName("اسم المنتج")]
        public string ProductName { get; set; }

        [DisplayName("صورة المنتج")]
         public string ProductPhotoPath { get; set; }

        [DisplayName("وصف المنتج")]
        public string Description { get; set; }

        [DisplayName(" سعر المنتج")]
        public Decimal ProductPrice { get; set; }

        [DisplayName("تخفيض على المنتج")]
        public bool IsOnSale { get; set; }

        [DisplayName("متوفر")]
        public bool IsInStock { get; set; }

        [DisplayName("فئة المنتج")]
        public ProductCatagory productCatagory { get; set; }
        public int productCatagoryId { get; set; }
        [DisplayName("المجهز")]

        public Suppliers supplyer { get; set; }
        public int supplyerId { get; set; }
    }
}
