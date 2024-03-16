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
    public class InstallationsController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly ILogger<InstallationsController> _logger;

        public InstallationsController(AppDbContext context, ILogger<InstallationsController> logger) : base(logger, context)
        {
            _context = context;
            _logger = logger;
        }


        // GET: Installations
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Installation.Include(i => i.Order).Include(i => i.Project);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Installations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var installation = await _context.Installation
                .Include(i => i.Order)
                .Include(i => i.Project)
                .FirstOrDefaultAsync(m => m.Installation_ID == id);
            if (installation == null)
            {
                return NotFound();
            }

            return View(installation);
        }

        // GET: Installations/Create
        public IActionResult Create()
        {
            ViewData["Order_ID"] = new SelectList(_context.Orders, "Order_ID", "Order_ID");
            ViewData["Project_ID"] = new SelectList(_context.Projects, "Project_ID", "Project_Name");
            return View();
        }

        // POST: Installations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Installation_ID,Project_ID,Order_ID")] Installation installation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(installation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Order_ID"] = new SelectList(_context.Orders, "Order_ID", "Order_ID", installation.Order_ID);
            ViewData["Project_ID"] = new SelectList(_context.Projects, "Project_ID", "Project_Name", installation.Project_ID);
            return View(installation);
        }

        // GET: Installations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var installation = await _context.Installation.FindAsync(id);
            if (installation == null)
            {
                return NotFound();
            }
            ViewData["Order_ID"] = new SelectList(_context.Orders, "Order_ID", "Order_ID", installation.Order_ID);
            ViewData["Project_ID"] = new SelectList(_context.Projects, "Project_ID", "Project_Name", installation.Project_ID);
            return View(installation);
        }

        // POST: Installations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Installation_ID,Project_ID,Order_ID")] Installation installation)
        {
            if (id != installation.Installation_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(installation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstallationExists(installation.Installation_ID))
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
            ViewData["Order_ID"] = new SelectList(_context.Orders, "Order_ID", "Order_ID", installation.Order_ID);
            ViewData["Project_ID"] = new SelectList(_context.Projects, "Project_ID", "Project_Name", installation.Project_ID);
            return View(installation);
        }

        // GET: Installations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var installation = await _context.Installation
                .Include(i => i.Order)
                .Include(i => i.Project)
                .FirstOrDefaultAsync(m => m.Installation_ID == id);
            if (installation == null)
            {
                return NotFound();
            }

            return View(installation);
        }

        // POST: Installations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var installation = await _context.Installation.FindAsync(id);
            if (installation != null)
            {
                _context.Installation.Remove(installation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstallationExists(int id)
        {
            return _context.Installation.Any(e => e.Installation_ID == id);
        }
    }
}
