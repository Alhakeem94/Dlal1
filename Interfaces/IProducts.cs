using Dalal.Models;
using Dalal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dalal.Interfaces
{
   public interface IProducts
    {
        IEnumerable<Products> GetAllProducts { get; }
        IEnumerable<Products> GetProductsOnSale { get; }
        IEnumerable<Products> GetProductsByCatagory(string productCatagory);
        Products GetProductById(int ProductId);
        Products CreateProduct(CreateProductViewModel newproduct);
        void DeleteProduct(int ProductId);
        Products EditProduct(EditProductViewModel EditedProduct);
       List <Products> SearchProduct(string name);
        
    }
}
