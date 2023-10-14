using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TradoGlobal.Data;
using TradoGlobal.Models;

namespace TradoGlobal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public TradoDb config;
        public HomeController(TradoDb _config)
        {
            config = _config;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        public IActionResult Privacy()
        {
            try
            {
                IEnumerable<Form> model = config.Set<Form>().ToList().Select(s => new Form
                {
                    Id = s.Id,
                    Name = s.Name,
                    Gender = s.Gender,
                    Hobby = s.Hobby

                }


            );
                return View("Privacy", model);
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpPost]
        public ActionResult Create(Form teacher, string[] Hobby)
        {
            try
            {
                teacher.Hobby = string.Join(",", Hobby);
                config.Forms.Add(teacher);
                config.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Privacy");
        }

        public IActionResult Edit(int id)
        {
            var record = config.Forms.FirstOrDefault(r => r.Id == id);
            if (record == null)
            {
                return NotFound();
            }

            return View(record);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Form record)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingRecord = config.Forms.FirstOrDefault(r => r.Id == record.Id);
                    if (existingRecord != null)
                    {
                        existingRecord.Name = record.Name;
                        existingRecord.Gender = record.Gender;
                        existingRecord.Hobby = record.Hobby;

                        config.SaveChanges();
                        return RedirectToAction("Privacy");
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Handle concurrency exception
                    throw;
                }
            }

            return View(record);
        }

        public IActionResult Delete(int id)
        {
            var record = config.Forms.FirstOrDefault(r => r.Id == id);
            if (record == null)
            {
                return NotFound();
            }

            return View(record);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var record = config.Forms.FirstOrDefault(r => r.Id == id);
            if (record == null)
            {
                return NotFound();
            }

            config.Forms.Remove(record);
            config.SaveChanges();
            return RedirectToAction("Privacy");
        }
    }
}