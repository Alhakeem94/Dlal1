using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dalal.Data;
using Dalal.Interfaces;
using Dalal.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Dalal.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IProducts _Iproducts;
        public ProductsController(ApplicationDbContext db,IProducts _products)
        {
            _db = db;
            _Iproducts = _products;
        }

        public IActionResult Index()
        {
            var allproducts = _Iproducts.GetAllProducts.ToList();
            return View(allproducts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var catagories = _db.ProductCatagories.ToList();
            var Suppliers = _db.Suppliers.ToList();
            var requirments = new CreateProductViewModel
            {

                productCatagory = catagories,
                supplyer = Suppliers

            };
            return View(requirments);
        }

        [HttpPost]
        public IActionResult Create(CreateProductViewModel product)
        {
            _Iproducts.CreateProduct(product);
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult Details(int ProductId)
        {
            var Product =  _Iproducts.GetProductById(ProductId);
            return View(Product);
        }

        public IActionResult DeleteProduct(int ProductId)
        {
            _Iproducts.DeleteProduct(ProductId);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Edit(int ProductId)
        {
            var editeditem = _db.Products.SingleOrDefault(c => c.ProductId == ProductId);
            var viewmodel = new EditProductViewModel
            {

                ProductName = editeditem.ProductName,
                ProductPrice = editeditem.ProductPrice,
                Description = editeditem.Description,
                productCatagory = _db.ProductCatagories.ToList(),
                productCatagoryId = editeditem.productCatagoryId,
                supplyerId = editeditem.supplyerId,
                supplyer = _db.Suppliers.ToList(),
                ExistingPhotoPath = editeditem.ProductPhotoPath


            };
            return View(viewmodel);
        }

        [HttpPost]
        public IActionResult Edit(EditProductViewModel EditedProduct)
        {
            _Iproducts.EditProduct(EditedProduct);
            return RedirectToAction(nameof(Index));

        }


        public IActionResult Search(HomePageViewModel ProductName)
        {
            if (ProductName !=null)
            {
                string name = ProductName.SearchedProduct;
                var searchedproducts =  _Iproducts.SearchProduct(name);
                return View(searchedproducts);
            }
            return RedirectToAction("Index","Home");

        }
    }
}