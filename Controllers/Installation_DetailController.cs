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
    public class Installation_DetailController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly ILogger<Installation_DetailController> _logger;

        public Installation_DetailController(AppDbContext context, ILogger<Installation_DetailController> logger) : base(logger, context)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Installation_Detail
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Installation_Details.Include(i => i.Employee).Include(i => i.Role);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Installation_Detail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var installation_Detail = await _context.Installation_Details
                .Include(i => i.Employee)
                .Include(i => i.Role)
                .FirstOrDefaultAsync(m => m.Installation_ID == id);
            if (installation_Detail == null)
            {
                return NotFound();
            }

            return View(installation_Detail);
        }

        // GET: Installation_Detail/Create
        public IActionResult Create()
        {
            ViewData["Employee_ID"] = new SelectList(_context.Employees, "Employee_ID", "Last_Name");
            ViewData["Role_ID"] = new SelectList(_context.Role, "Role_ID", "Role_Name");
            return View();
        }

        // POST: Installation_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Installation_ID,Employee_ID,Role_ID")] Installation_Detail installation_Detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(installation_Detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Employee_ID"] = new SelectList(_context.Employees, "Employee_ID", "Employee_ID", installation_Detail.Employee_ID);
            ViewData["Role_ID"] = new SelectList(_context.Role, "Role_ID", "Role_ID", installation_Detail.Role_ID);
            return View(installation_Detail);
        }

        // GET: Installation_Detail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var installation_Detail = await _context.Installation_Details.FindAsync(id);
            if (installation_Detail == null)
            {
                return NotFound();
            }
            ViewData["Employee_ID"] = new SelectList(_context.Employees, "Employee_ID", "Employee_Name", installation_Detail.Employee_ID);
            ViewData["Role_ID"] = new SelectList(_context.Set<Role>(), "Role_ID", "Role_Name", installation_Detail.Role_ID);
            return View(installation_Detail);
        }

        // POST: Installation_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Installation_ID,Employee_ID,Role_ID")] Installation_Detail installation_Detail)
        {
            if (id != installation_Detail.Installation_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(installation_Detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Installation_DetailExists(installation_Detail.Installation_ID))
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
            ViewData["Employee_ID"] = new SelectList(_context.Employees, "Employee_ID", "Employee_Name", installation_Detail.Employee_ID);
            ViewData["Role_ID"] = new SelectList(_context.Set<Role>(), "Role_ID", "Role_Name", installation_Detail.Role_ID);
            return View(installation_Detail);
        }

        // GET: Installation_Detail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var installation_Detail = await _context.Installation_Details
                .Include(i => i.Employee)
                .Include(i => i.Role)
                .FirstOrDefaultAsync(m => m.Installation_ID == id);
            if (installation_Detail == null)
            {
                return NotFound();
            }

            return View(installation_Detail);
        }

        // POST: Installation_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var installation_Detail = await _context.Installation_Details.FindAsync(id);
            if (installation_Detail != null)
            {
                _context.Installation_Details.Remove(installation_Detail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Installation_DetailExists(int id)
        {
            return _context.Installation_Details.Any(e => e.Installation_ID == id);
        }
    }
}
