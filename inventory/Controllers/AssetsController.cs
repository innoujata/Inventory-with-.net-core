using inventory.Data;
using inventory.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventory.Controllers
{
    public class AssetsController : Controller
    {
        private readonly AppDBContext _db;

        public AssetsController(AppDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<assets> objList = _db.assets;
            return View(objList);
        }

        //Get - create 
        public IActionResult Create()
        {
            return View();
        }
        
        // Post - create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(assets obj)
        {
            if(ModelState.IsValid)
            {
                _db.assets.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
           
        }

        //Get - Edit 
        public IActionResult Edit(int? id)
        {
            if (id==null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.assets.Find(id);
            if (obj==null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // Post - Edit or Update 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(assets obj)
        {
            if (ModelState.IsValid)
            {
                _db.assets.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //Get - DELETE 
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.assets.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // Post - DELETE 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.assets.Find(id);
            if (obj==null)
            {
                return NotFound();
            }
            
                _db.assets.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            
        }
    }
}
