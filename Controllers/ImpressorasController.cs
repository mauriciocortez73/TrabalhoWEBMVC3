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
    public class ImpressorasController : Controller
    {

        private readonly Contexto _context;

        public ImpressorasController(Contexto context)
        {
            _context = context;
        }

        // GET: Impressoras
        public async Task<IActionResult> Index()
        {
              return View(await _context.Impressoras.ToListAsync());
        }

        // GET: Impressoras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Impressoras == null)
            {
                return NotFound();
            }

            var impressora = await _context.Impressoras
                .FirstOrDefaultAsync(m => m.id == id);
            if (impressora == null)
            {
                return NotFound();
            }

            return View(impressora);
        }

        // GET: Impressoras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Impressoras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,descricao,patrimonio")] Impressora impressora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(impressora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(impressora);
        }

        // GET: Impressoras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Impressoras == null)
            {
                return NotFound();
            }

            var impressora = await _context.Impressoras.FindAsync(id);
            if (impressora == null)
            {
                return NotFound();
            }
            return View(impressora);
        }

        // POST: Impressoras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,descricao,patrimonio")] Impressora impressora)
        {
            if (id != impressora.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(impressora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImpressoraExists(impressora.id))
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
            return View(impressora);
        }

        // GET: Impressoras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Impressoras == null)
            {
                return NotFound();
            }

            var impressora = await _context.Impressoras
                .FirstOrDefaultAsync(m => m.id == id);
            if (impressora == null)
            {
                return NotFound();
            }

            return View(impressora);
        }

        // POST: Impressoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Impressoras == null)
            {
                return Problem("Entity set 'Contexto.Impressoras'  is null.");
            }
            var impressora = await _context.Impressoras.FindAsync(id);
            if (impressora != null)
            {
                _context.Impressoras.Remove(impressora);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImpressoraExists(int id)
        {
          return _context.Impressoras.Any(e => e.id == id);
        }
    }
}
