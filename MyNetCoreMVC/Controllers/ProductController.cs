using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            TempData["ss"] = "sssss";
            return new RedirectResult("Create");
        }
        [HttpPost]
        public IActionResult Edit(long id, Product product)
        {
            var exisProduct = _context.TodoItems.Find(id);
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
        public IActionResult Delete(long id)
        {
            var exisProduct = _context.TodoItems.Find(id);
            if (exisProduct == null)
            {
                return NotFound();
            }

            
            _context.TodoItems.Remove(exisProduct);
            _context.SaveChanges();

            return new RedirectResult("Create");
        }
      

        public IActionResult DeleteMany(string ids)
        {
            var num = ids.Split(",").Length;
            
            foreach (var id in ids.Split(","))
            {
                var exisProduct = _context.TodoItems.Find(Convert.ToInt64(id));
                if (exisProduct == null)
                {
                    return NotFound();
                }

                _context.TodoItems.Remove(exisProduct ?? throw  new InvalidAsynchronousStateException());
            }

            _context.SaveChanges();
            return new RedirectResult("Create");
        }
    }
}