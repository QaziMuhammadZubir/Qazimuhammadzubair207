using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Qazi_Muhammad_Zubair_207.Data;
using Qazi_Muhammad_Zubair_207.Models;

namespace Qazi_Muhammad_Zubair_207
{
    public class OrdermodelsController : Controller
    {
        private readonly StoreDb _context;

        public OrdermodelsController(StoreDb context)
        {
            _context = context;
        }

        // GET: Ordermodels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ordermodel.ToListAsync());
        }

        // GET: Ordermodels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordermodel = await _context.Ordermodel
                .FirstOrDefaultAsync(m => m.id == id);
            if (ordermodel == null)
            {
                return NotFound();
            }
            double total = 0;
            total = ordermodel.quantity * ordermodel.price;
            ViewBag.message = total;

            return View(ordermodel);
        }

        // GET: Ordermodels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ordermodels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,descirption,quantity,price")] Ordermodel ordermodel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordermodel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ordermodel);
        }

        // GET: Ordermodels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordermodel = await _context.Ordermodel.FindAsync(id);
            if (ordermodel == null)
            {
                return NotFound();
            }
            return View(ordermodel);
        }

        // POST: Ordermodels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,descirption,quantity,price")] Ordermodel ordermodel)
        {
            if (id != ordermodel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordermodel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdermodelExists(ordermodel.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ordermodel);
        }

        // GET: Ordermodels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordermodel = await _context.Ordermodel
                .FirstOrDefaultAsync(m => m.id == id);
            if (ordermodel == null)
            {
                return NotFound();
            }

            return View(ordermodel);
        }

        // POST: Ordermodels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordermodel = await _context.Ordermodel.FindAsync(id);
            _context.Ordermodel.Remove(ordermodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdermodelExists(int id)
        {
            return _context.Ordermodel.Any(e => e.id == id);
        }
    }
}
