using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyNetCoreMVC.Models;

namespace MyNetCoreMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly TodoContext _context;

        public ProductController(TodoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

       

        public IActionResult Create()
        {
            return View(_context.TodoItems.ToList());
        }

        
       
        [HttpPost]
        public IActionResult Save(Product pr )
        {
            _context.TodoItems.Add(pr);
            _context.SaveChanges();
            return new RedirectResult("Create");
        }
        [HttpPost]
        public IActionResult Edit(int id, Product product)
        {
            var exisProduct = _context.TodoItems.Find(product.Id);
            if (exisProduct == null)
            {
                return NotFound();
            }

            exisProduct.Name = product.Name;
            exisProduct.Price = product.Price;
            _context.TodoItems.Update(exisProduct);
            _context.SaveChanges();
            
            return new RedirectResult("Create");
        }
        [HttpPost]
        public IActionResult Delete(int id, Product product)
        {
            var exisProduct = _context.TodoItems.Find(product.Id);
            if (exisProduct == null)
            {
                return NotFound();
            }

            
            _context.TodoItems.Remove(exisProduct);
            _context.SaveChanges();

            return new RedirectResult("Create");
        }
        public IActionResult Delete(int id)
        {
           return new JsonResult(new Product
               {
               Id = id
               });
        }
    }
}