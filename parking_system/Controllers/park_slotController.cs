using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using parking_system.infrastructure;
using parking_system.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parking_system.Controllers
{
    public class park_slotController : Controller
    {
        private readonly db dbcontext;

        public park_slotController(db dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        // GET: car_slotController
        public ActionResult Index()
        {
            IQueryable<park_slot> items = from i in dbcontext.park_slot.Include("car_owner")
                                          orderby i.id
                                          select i;
            List<park_slot> todoList =  items.ToList();
            return View(todoList);
           
        }

      
        // GET: car_slotController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: car_slotController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(park_slot item)
        {
            if (ModelState.IsValid)
            {
                dbcontext.Add(item);
                 dbcontext.SaveChanges();   

                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET: car_slotController/Edit/5
        public ActionResult Edit(int id)
        {
            park_slot item = dbcontext.park_slot.Find(id);
            if (item == null)
                return NotFound();

            return View(item);
        }


        // POST: car_slotController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(park_slot item)
        {
            if (ModelState.IsValid)
            {
                dbcontext.Update(item);
                dbcontext.SaveChanges();



                return RedirectToAction("Index");
            }
            return View(item);
        }

        public async Task<ActionResult> Delete(int id)
        {
            park_slot item = await dbcontext.park_slot.FindAsync(id);


            dbcontext.park_slot.Remove(item);
            await dbcontext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
