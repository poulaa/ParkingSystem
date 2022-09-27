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
    public class car_ownerController : Controller
    {
        private readonly db dbcontext;
        public car_ownerController(db dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        // GET: car_slotController
        public ActionResult Index()
        {
            IQueryable<car_owner> items = from i in dbcontext.car_owner
                                          orderby i.car_owner_id
                                          select i;
            List<car_owner> todoList = items.ToList();
            return View(todoList);

        }


     

        // GET: car_ownerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: car_ownerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(car_owner item)
        {
            if (ModelState.IsValid)
            {
                dbcontext.Add(item);
                dbcontext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(item);
        }


        // GET: car_ownerController/Edit/5
        public ActionResult Edit(int id)
        {
            car_owner item = dbcontext.car_owner.Find(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: car_ownerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(car_owner item)
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
            car_owner item = await dbcontext.car_owner.FindAsync(id);
            
            
                dbcontext.car_owner.Remove(item);
                await dbcontext.SaveChangesAsync();

                

            
            return RedirectToAction("Index");
        }

    }
}

