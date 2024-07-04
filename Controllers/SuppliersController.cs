using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ENTPROG_XTIS3_Abo.Models;
using ENTPROG_XTIS3_Abo.Controllers;


namespace ENTPROG_XTIS3_Abo.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly AppDbContext _context;

        public SuppliersController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var suppliers = await _context.SuppliersINV.ToListAsync();
            return View(suppliers);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierID,CompanyName,Address,Representative,ContactNo")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                supplier.DateAdded = DateTime.Now;  // Automatically set DateAdded
                _context.Add(supplier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.SuppliersINV.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplierID,CompanyName,Address,Representative,ContactNo,DateAdded")] Supplier supplier)
        {
            if (id != supplier.SupplierID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingSupplier = await _context.SuppliersINV.FindAsync(id);
                    if (existingSupplier == null)
                    {
                        return NotFound();
                    }

                    existingSupplier.CompanyName = supplier.CompanyName;
                    existingSupplier.Address = supplier.Address;
                    existingSupplier.Representative = supplier.Representative;
                    existingSupplier.ContactNo = supplier.ContactNo;
                    existingSupplier.DateModified = DateTime.Now;

                    _context.Update(existingSupplier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierExists(supplier.SupplierID))
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
            return View(supplier);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.SuppliersINV
                .FirstOrDefaultAsync(m => m.SupplierID == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplier = await _context.SuppliersINV.FindAsync(id);
            if (supplier != null)
            {
                _context.SuppliersINV.Remove(supplier);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool SupplierExists(int id)
        {
            return _context.SuppliersINV.Any(e => e.SupplierID == id);
        }
    }
}
