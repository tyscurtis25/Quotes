using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quotes.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.Controllers
{
    public class HomeController : Controller
    {
        private IQuotesRepository _repo { get; set; }

        //constructor
        public HomeController(IQuotesRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            var blah = _repo.Quotes.ToList();
            return View(blah);
        }

        //FORM
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Quote q)
        {
            if (ModelState.IsValid) //validation for form
            {
                _repo.AddQuote(q);
                _repo.Save(q);

                return View(q);
            }
            else //if invalid
            {
                ViewBag.Categories = _repo.Quotes.ToList();
                return View(q);
            }
        }

        public IActionResult Details(int quoteid)
        {
            var entry = _repo.Quotes
                .Single(x => x.quoteID == quoteid);

            return View(quoteid);
        }

        //EDIT + DELETE SECTION
        [HttpGet]
        public IActionResult Edit(int quoteid)
        {

            var entry = _repo.Quotes
                .Single(x => x.quoteID == quoteid);

            return View("Add", entry);
        }

        [HttpPost]
        public IActionResult Edit(Quote instance) //instance is just an instance of Movies on the form
        {
            if (ModelState.IsValid)
            {
                _repo.Edit(instance);
                _repo.Save(instance);

                return RedirectToAction("Index");
            }
            else //if invalid
            {
                ViewBag.Categories = _repo.Quotes.ToList();
                return View(instance);
            }
        }

        [HttpGet]
        public IActionResult Delete(int quoteid)
        {
            var entry = _repo.Quotes.Single(x => x.quoteID == quoteid);

            return View(entry);
        }

        [HttpPost]
        public IActionResult Delete(Quote q_uote)
        {
            _repo.Delete(q_uote);
            _repo.Save(q_uote);

            return RedirectToAction("Index");
        }

        //PRE-BUILT actions

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
