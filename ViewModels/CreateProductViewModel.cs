using Dalal.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dalal.ViewModels
{
    public class CreateProductViewModel
    {
        public string ProductName { get; set; }
        public IFormFile Photo { get; set; }
        public string Description { get; set; }
        public Decimal ProductPrice { get; set; }
        public bool IsOnSale { get; set; }
        public bool IsInStock { get; set; }
        public List<ProductCatagory> productCatagory { get; set; }
        public int productCatagoryId { get; set; }
        public List<Suppliers> supplyer { get; set; }
        public int supplyerId { get; set; }

    }
}
