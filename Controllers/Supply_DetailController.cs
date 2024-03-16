using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using REAMI_Marketing_Sales___Inventory_System.Data;
using REAMI_Marketing_Sales___Inventory_System.Models;

namespace REAMI_Marketing_Sales___Inventory_System.Controllers
{
    public class Supply_DetailController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly ILogger<Supply_DetailController> _logger;

        public Supply_DetailController(AppDbContext context, ILogger<Supply_DetailController> logger) : base(logger, context)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Supply_Detail
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Supply_Details.Include(p => p.Product);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Supply_Detail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supply_Detail = await _context.Supply_Details.Include(p=>p.Product)
                .FirstOrDefaultAsync(m => m.Supply_ID == id);
            if (supply_Detail == null)
            {
                return NotFound();
            }

            return View(supply_Detail);
        }

        // GET: Supply_Detail/Create
        public IActionResult Create()
        {
            ViewData["Product_ID"] = new SelectList(_context.Products, "Product_ID", "Product_ID");
            return View();
        }

        // POST: Supply_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Supply_ID,Product_ID,Quantity_Supplied,Price,Unit")] Supply_Detail supply_Detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supply_Detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Product_ID"] = new SelectList(_context.Products, "Product_ID", "Product_ID");

            return View(supply_Detail);
        }

        // GET: Supply_Detail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supply_Detail = await _context.Supply_Details.FindAsync(id);
            if (supply_Detail == null)
            {
                return NotFound();
            }
            ViewData["Product_ID"] = new SelectList(_context.Products, "Product_ID", "Product_ID");

            return View(supply_Detail);
        }

        // POST: Supply_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Supply_ID,Product_ID,Quantity_Supplied,Price,Unit")] Supply_Detail supply_Detail)
        {
            if (id != supply_Detail.Supply_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supply_Detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Supply_DetailExists(supply_Detail.Supply_ID))
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
            ViewData["Product_ID"] = new SelectList(_context.Products, "Product_ID", "Product_ID");

            return View(supply_Detail);
        }

        // GET: Supply_Detail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supply_Detail = await _context.Supply_Details.Include(p=>p.Product)
                .FirstOrDefaultAsync(m => m.Supply_ID == id);
            if (supply_Detail == null)
            {
                return NotFound();
            }

            return View(supply_Detail);
        }

        // POST: Supply_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supply_Detail = await _context.Supply_Details.FindAsync(id);
            if (supply_Detail != null)
            {
                _context.Supply_Details.Remove(supply_Detail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Supply_DetailExists(int id)
        {
            return _context.Supply_Details.Any(e => e.Supply_ID == id);
        }
    }
}
