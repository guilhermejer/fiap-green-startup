using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fiap.Green.Startup.Models;
using Fiap.Green.Startup.Repository.Context;

namespace Fiap.Green.Startup.Controllers
{
    public class PagamentoController : Controller
    {
        private readonly OracleContext _context;

        public PagamentoController(OracleContext context)
        {
            _context = context;
        }

        // GET: Pagamento
        public async Task<IActionResult> Index()
        {
            var oracleContext = _context.Pagamento.Include(p => p.TipoPagamento);
            return View(await oracleContext.ToListAsync());
        }

        // GET: Pagamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamento
                .Include(p => p.TipoPagamento)
                .FirstOrDefaultAsync(m => m.IdPagamento == id);
            if (pagamento == null)
            {
                return NotFound();
            }

            return View(pagamento);
        }

        // GET: Pagamento/Create
        public IActionResult Create()
        {
            ViewData["IdTipoPagamento"] = new SelectList(_context.TipoPagamento, "IdTipoPagamento", "IdTipoPagamento");
            return View();
        }

        // POST: Pagamento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPagamento,IdTipoPagamento,DadosPagamento")] Pagamento pagamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoPagamento"] = new SelectList(_context.TipoPagamento, "IdTipoPagamento", "IdTipoPagamento", pagamento.IdTipoPagamento);
            return View(pagamento);
        }

        // GET: Pagamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamento.FindAsync(id);
            if (pagamento == null)
            {
                return NotFound();
            }
            ViewData["IdTipoPagamento"] = new SelectList(_context.TipoPagamento, "IdTipoPagamento", "IdTipoPagamento", pagamento.IdTipoPagamento);
            return View(pagamento);
        }

        // POST: Pagamento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPagamento,IdTipoPagamento,DadosPagamento")] Pagamento pagamento)
        {
            if (id != pagamento.IdPagamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagamentoExists(pagamento.IdPagamento))
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
            ViewData["IdTipoPagamento"] = new SelectList(_context.TipoPagamento, "IdTipoPagamento", "IdTipoPagamento", pagamento.IdTipoPagamento);
            return View(pagamento);
        }

        // GET: Pagamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamento
                .Include(p => p.TipoPagamento)
                .FirstOrDefaultAsync(m => m.IdPagamento == id);
            if (pagamento == null)
            {
                return NotFound();
            }

            return View(pagamento);
        }

        // POST: Pagamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pagamento = await _context.Pagamento.FindAsync(id);
            _context.Pagamento.Remove(pagamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagamentoExists(int id)
        {
            return _context.Pagamento.Any(e => e.IdPagamento == id);
        }
    }
}
