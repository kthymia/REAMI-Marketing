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
    public class Order_DetailController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly ILogger<Order_DetailController> _logger;

        public Order_DetailController(AppDbContext context, ILogger<Order_DetailController> logger) : base(logger, context)
        {
            _context = context;
            _logger = logger;
        }


        // GET: Order_Detail
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Order_Details.Include(o => o.Order).Include(o => o.Product);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Order_Detail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order_Detail = await _context.Order_Details
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.Order_Details_ID == id);
            if (order_Detail == null)
            {
                return NotFound();
            }

            return View(order_Detail);
        }

        // GET: Order_Detail/Create
        public IActionResult Create()
        {
            ViewData["Order_ID"] = new SelectList(_context.Orders, "Order_ID", "Order_ID");
            ViewData["Product_ID"] = new SelectList(_context.Products, "Product_ID", "Product_ID");
            return View();
        }

        // POST: Order_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Order_Details_ID,Order_ID,Product_ID,Quantity,Price,Unit")] Order_Detail order_Detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order_Detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Order_ID"] = new SelectList(_context.Orders, "Order_ID", "Order_ID", order_Detail.Order_ID);
            ViewData["Product_ID"] = new SelectList(_context.Products, "Product_ID", "Product_ID", order_Detail.Product_ID);
            return View(order_Detail);
        }

        // GET: Order_Detail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order_Detail = await _context.Order_Details.FindAsync(id);
            if (order_Detail == null)
            {
                return NotFound();
            }
            ViewData["Order_ID"] = new SelectList(_context.Orders, "Order_ID", "Order_ID", order_Detail.Order_ID);
            ViewData["Product_ID"] = new SelectList(_context.Products, "Product_ID", "Product_ID", order_Detail.Product_ID);
            return View(order_Detail);
        }

        // POST: Order_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Order_Details_ID,Order_ID,Product_ID,Quantity,Price,Unit")] Order_Detail order_Detail)
        {
            if (id != order_Detail.Order_Details_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order_Detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Order_DetailExists(order_Detail.Order_Details_ID))
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
            ViewData["Order_ID"] = new SelectList(_context.Orders, "Order_ID", "Order_ID", order_Detail.Order_ID);
            ViewData["Product_ID"] = new SelectList(_context.Products, "Product_ID", "Product_ID", order_Detail.Product_ID);
            return View(order_Detail);
        }

        // GET: Order_Detail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order_Detail = await _context.Order_Details
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.Order_Details_ID == id);
            if (order_Detail == null)
            {
                return NotFound();
            }

            return View(order_Detail);
        }

        // POST: Order_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order_Detail = await _context.Order_Details.FindAsync(id);
            if (order_Detail != null)
            {
                _context.Order_Details.Remove(order_Detail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Order_DetailExists(int id)
        {
            return _context.Order_Details.Any(e => e.Order_Details_ID == id);
        }
    }
}
