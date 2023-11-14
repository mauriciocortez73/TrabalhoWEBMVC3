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
    public class PedidosController : Controller
    {
        private readonly Contexto _context;

        public PedidosController(Contexto context)
        {
            _context = context;
        }

        // GET: Pedidos
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Pedidos.Include(p => p.impressoras).Include(p => p.tonners);
            return View(await contexto.ToListAsync());
        }

        // GET: Pedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.impressoras)
                .Include(p => p.tonners)
                .FirstOrDefaultAsync(m => m.id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidos/Create
        public IActionResult Create()
        {
            ViewData["impressorasID"] = new SelectList(_context.Impressoras, "id", "descricao");
            ViewData["tonnersID"] = new SelectList(_context.Tonners, "id", "descricao");
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,impressorasID,tonnersID,quantidade,valor")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                //atualizando lista de tonner após um pedido subtraindo a quantidade do pedido
                //realizou um pedido de tonner e o estoque diminui o quanto foi pedido
                Tonner tonner = await _context.Tonners.FindAsync(pedido.tonnersID);
                tonner.quantidade = tonner.quantidade - pedido.quantidade;
                pedido.valor = tonner.valor * pedido.quantidade;
                _context.Update(tonner);

                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["impressorasID"] = new SelectList(_context.Impressoras, "id", "descricao", pedido.impressorasID);
            ViewData["tonnersID"] = new SelectList(_context.Tonners, "id", "descricao", pedido.tonnersID);
            return View(pedido);
        }

        // GET: Pedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["impressorasID"] = new SelectList(_context.Impressoras, "id", "descricao", pedido.impressorasID);
            ViewData["tonnersID"] = new SelectList(_context.Tonners, "id", "descricao", pedido.tonnersID);
            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,impressorasID,tonnersID,quantidade,valor")] Pedido pedido)
        {
            if (id != pedido.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.id))
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
            ViewData["impressorasID"] = new SelectList(_context.Impressoras, "id", "descricao", pedido.impressorasID);
            ViewData["tonnersID"] = new SelectList(_context.Tonners, "id", "descricao", pedido.tonnersID);
            return View(pedido);
        }

        // GET: Pedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.impressoras)
                .Include(p => p.tonners)
                .FirstOrDefaultAsync(m => m.id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pedidos == null)
            {
                return Problem("Entity set 'Contexto.Pedidos'  is null.");
            }
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
          return _context.Pedidos.Any(e => e.id == id);
        }
    }
}
