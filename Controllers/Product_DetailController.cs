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
    public class Product_DetailController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly ILogger<Product_DetailController> _logger;

        public Product_DetailController(AppDbContext context, ILogger<Product_DetailController> logger) : base(logger, context)
        {
            _context = context;
            _logger = logger;
        }
        // GET: Product_Detail
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Product_Details.Include(p => p.Measurement).Include(p => p.OrderDetails);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Product_Detail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_Detail = await _context.Product_Details
                .Include(p => p.Measurement)
                .Include(p => p.OrderDetails)
                .FirstOrDefaultAsync(m => m.Order_Details_ID == id);
            if (product_Detail == null)
            {
                return NotFound();
            }

            return View(product_Detail);
        }

        // GET: Product_Detail/Create
        public IActionResult Create()
        {
            ViewData["Measurement_ID"] = new SelectList(_context.Measurements, "Measurement_ID", "Measurement_Type");
            ViewData["Order_Details_ID"] = new SelectList(_context.Order_Details, "Order_Details_ID", "Order_Details_ID");
            return View();
        }

        // POST: Product_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Order_Details_ID,Measurement_ID,Value")] Product_Detail product_Detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product_Detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Measurement_ID"] = new SelectList(_context.Measurements, "Measurement_ID", "Measurement_Type", product_Detail.Measurement_ID);
            ViewData["Order_Details_ID"] = new SelectList(_context.Order_Details, "Order_Details_ID", "Order_Details_ID", product_Detail.Order_Details_ID);
            return View(product_Detail);
        }

        // GET: Product_Detail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_Detail = await _context.Product_Details.FindAsync(id);
            if (product_Detail == null)
            {
                return NotFound();
            }
            ViewData["Measurement_ID"] = new SelectList(_context.Measurements, "Measurement_ID", "Measurement_Type", product_Detail.Measurement_ID);
            ViewData["Order_Details_ID"] = new SelectList(_context.Order_Details, "Order_Details_ID", "Order_Details_ID", product_Detail.Order_Details_ID);
            return View(product_Detail);
        }

        // POST: Product_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Order_Details_ID,Measurement_ID,Value")] Product_Detail product_Detail)
        {
            if (id != product_Detail.Order_Details_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product_Detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Product_DetailExists(product_Detail.Order_Details_ID))
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
            ViewData["Measurement_ID"] = new SelectList(_context.Measurements, "Measurement_ID", "Measurement_Type", product_Detail.Measurement_ID);
            ViewData["Order_Details_ID"] = new SelectList(_context.Order_Details, "Order_Details_ID", "Order_Details_ID", product_Detail.Order_Details_ID);
            return View(product_Detail);
        }

        // GET: Product_Detail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_Detail = await _context.Product_Details
                .Include(p => p.Measurement)
                .Include(p => p.OrderDetails)
                .FirstOrDefaultAsync(m => m.Order_Details_ID == id);
            if (product_Detail == null)
            {
                return NotFound();
            }

            return View(product_Detail);
        }

        // POST: Product_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product_Detail = await _context.Product_Details.FindAsync(id);
            if (product_Detail != null)
            {
                _context.Product_Details.Remove(product_Detail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Product_DetailExists(int id)
        {
            return _context.Product_Details.Any(e => e.Order_Details_ID == id);
        }
    }
}
