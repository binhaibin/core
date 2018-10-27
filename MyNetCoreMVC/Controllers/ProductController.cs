using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyNetCoreMVC.Models;

namespace MyNetCoreMVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetList()
        {
            return View();
        }

        public IActionResult Create(string name , int price)
        {
            ViewData["Name"] = name;
            ViewData["Price"] = price;
            return View();
        }

        public IActionResult Update()
        {
            return View();
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