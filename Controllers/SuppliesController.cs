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
    public class SuppliesController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly ILogger<SuppliesController> _logger;

        public SuppliesController(AppDbContext context, ILogger<SuppliesController> logger) : base(logger, context)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Supplies
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Supplies.Include(s => s.Company);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Supplies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supply = await _context.Supplies
                .Include(s => s.Company)
                .FirstOrDefaultAsync(m => m.Supply_ID == id);
            if (supply == null)
            {
                return NotFound();
            }

            return View(supply);
        }

        // GET: Supplies/Create
        public IActionResult Create()
        {
            ViewData["Company_ID"] = new SelectList(_context.Companies, "Company_ID", "Company_Name");
            return View();
        }

        // POST: Supplies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Supply_ID,Company_ID,Date")] Supply supply)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supply);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Company_ID"] = new SelectList(_context.Companies, "Company_ID", "Company_Name", supply.Company_ID);
            return View(supply);
        }

        // GET: Supplies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supply = await _context.Supplies.FindAsync(id);
            if (supply == null)
            {
                return NotFound();
            }
            ViewData["Company_ID"] = new SelectList(_context.Companies, "Company_ID", "Company_Name", supply.Company_ID);
            return View(supply);
        }

        // POST: Supplies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Supply_ID,Company_ID,Date")] Supply supply)
        {
            if (id != supply.Supply_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supply);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplyExists(supply.Supply_ID))
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
            ViewData["Company_ID"] = new SelectList(_context.Companies, "Company_ID", "Company_Name", supply.Company_ID);
            return View(supply);
        }

        // GET: Supplies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supply = await _context.Supplies
                .Include(s => s.Company)
                .FirstOrDefaultAsync(m => m.Supply_ID == id);
            if (supply == null)
            {
                return NotFound();
            }

            return View(supply);
        }

        // POST: Supplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supply = await _context.Supplies.FindAsync(id);
            if (supply != null)
            {
                _context.Supplies.Remove(supply);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplyExists(int id)
        {
            return _context.Supplies.Any(e => e.Supply_ID == id);
        }
    }
}
