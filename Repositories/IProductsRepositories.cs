using Dalal.Data;
using Dalal.Interfaces;
using Dalal.Models;
using Dalal.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Dalal.Repositories
{
    public class IProductsRepositories : IProducts
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public IProductsRepositories(ApplicationDbContext db,IWebHostEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
        }

        public IEnumerable<Products> GetAllProducts
        {

           get {
                var allproducts = _db.Products.Include(c => c.supplyer);
                return (allproducts);

            }
           
        }

        private string processuploadedfile(EditProductViewModel EditedProduct)
        {
            string uniqefilename = null;
            string uploadsfolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
            uniqefilename = Guid.NewGuid().ToString() + "_" + EditedProduct.Photo.FileName;
            string filepath = Path.Combine(uploadsfolder, uniqefilename);
            EditedProduct.Photo.CopyTo(new FileStream(filepath, FileMode.Create));
            return uniqefilename;
        }

        public IEnumerable<Products> GetProductsOnSale
        {
            get
            {
                var productsonsale = _db.Products.Include(c => c.IsOnSale);
                return (productsonsale);

            }
        }

        public Products CreateProduct(CreateProductViewModel newprodect)
        {
            string uniqefilename = null;
            string uploadsfolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
            uniqefilename = Guid.NewGuid().ToString() + "_" + newprodect.Photo.FileName;
            string filepath = Path.Combine(uploadsfolder, uniqefilename);
            newprodect.Photo.CopyTo(new FileStream(filepath, FileMode.Create));

            var product = new Products
            {

                ProductName=newprodect.ProductName,
                ProductPhotoPath = uniqefilename,
                Description = newprodect.Description,
                ProductPrice =newprodect.ProductPrice,
                IsOnSale=newprodect.IsOnSale,
                IsInStock=newprodect.IsInStock,
                productCatagoryId=newprodect.productCatagoryId,
                supplyerId=newprodect.supplyerId,
                
                
                
            };
            _db.Products.Add(product);
            _db.SaveChanges();
            return product;
        }

        public void DeleteProduct(int ProductId)
        {
            var deletedproduct = _db.Products.SingleOrDefault(c => c.ProductId == ProductId);
            _db.Remove(deletedproduct);
            _db.SaveChanges();
        }

       

        public Products EditProduct(EditProductViewModel EditedProduct)
        {

            var oldproduct = _db.Products.SingleOrDefault(c => c.ProductId == EditedProduct.ProductId);

            oldproduct.ProductName = EditedProduct.ProductName;
            oldproduct.ProductPrice = EditedProduct.ProductPrice;
            oldproduct.Description = EditedProduct.Description;
            oldproduct.supplyerId = EditedProduct.supplyerId;
            oldproduct.IsOnSale = EditedProduct.IsOnSale;
            oldproduct.productCatagoryId = EditedProduct.productCatagoryId;
            if (EditedProduct.Photo != null)
            {
                oldproduct.ProductPhotoPath = processuploadedfile(EditedProduct);
            }


            _db.Products.Update(oldproduct);
            _db.SaveChanges();
            return oldproduct;
        }

        public Products GetProductById(int ProductId)
        {
            var product = _db.Products.Include(c=>c.productCatagory).Include(a=>a.supplyer).SingleOrDefault(c => c.ProductId == ProductId);
            return (product);
        }

        public IEnumerable<Products> GetProductsByCatagory(string productCatagory)
        {

            var ProductsByCatagory = _db.Products.Where(c=>c.productCatagory.CatagoryName == productCatagory);
            return (ProductsByCatagory);

        }

        public List<Products> SearchProduct(string name)
        {
            var SearchedProduct = _db.Products.Include(c=>c.productCatagory).Include(c=>c.supplyer).Where(c => c.ProductName.Contains(name)).ToList();
            return SearchedProduct;
        }
    }
}
