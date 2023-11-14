using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabalhoWEBMVC3.Models;

namespace TrabalhoWEBMVC3.Controllers
{
    public class TonnersController : Controller
    {
        private readonly Contexto _context;

        public TonnersController(Contexto context)
        {
            _context = context;
        }

        // GET: Tonners
        public async Task<IActionResult> Index()
        {
              return View(await _context.Tonners.ToListAsync());
        }

        // GET: Tonners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tonners == null)
            {
                return NotFound();
            }

            var tonner = await _context.Tonners
                .FirstOrDefaultAsync(m => m.id == id);
            if (tonner == null)
            {
                return NotFound();
            }

            return View(tonner);
        }

        // GET: Tonners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tonners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,descricao,valor,quantidade")] Tonner tonner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tonner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tonner);
        }

        // GET: Tonners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tonners == null)
            {
                return NotFound();
            }

            var tonner = await _context.Tonners.FindAsync(id);
            if (tonner == null)
            {
                return NotFound();
            }
            return View(tonner);
        }

        // POST: Tonners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,descricao,valor,quantidade")] Tonner tonner)
        {
            if (id != tonner.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tonner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TonnerExists(tonner.id))
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
            return View(tonner);
        }

        // GET: Tonners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tonners == null)
            {
                return NotFound();
            }

            var tonner = await _context.Tonners
                .FirstOrDefaultAsync(m => m.id == id);
            if (tonner == null)
            {
                return NotFound();
            }

            return View(tonner);
        }

        // POST: Tonners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tonners == null)
            {
                return Problem("Entity set 'Contexto.Tonners'  is null.");
            }
            var tonner = await _context.Tonners.FindAsync(id);
            if (tonner != null)
            {
                _context.Tonners.Remove(tonner);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TonnerExists(int id)
        {
          return _context.Tonners.Any(e => e.id == id);
        }
    }
}
