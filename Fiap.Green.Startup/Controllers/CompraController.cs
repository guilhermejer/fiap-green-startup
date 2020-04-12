using System.IO;
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
    public class CompraController : Controller
    {
        private readonly OracleContext _context;
        private readonly OracleContext context;

        public CompraController(OracleContext context)
        {
            _context = context;
        }

        // GET: Compra
        public async Task<IActionResult> Index()
        {

            var oracleContext = _context.Compra.Include(c => c.Empresa).Include(c => c.Produto).Include(c => c.TipoProduto);
            return View(await oracleContext.ToListAsync());
        }

        // GET: Compra/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compra
                .Include(c => c.Empresa)
                .Include(c => c.Produto)
                .Include(c => c.TipoProduto)
                .FirstOrDefaultAsync(m => m.IdCompra == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // GET: Compra/Create
        public IActionResult Create()
        {
            ViewData["IdEmpresa"] = new SelectList(_context.Empresa, "IdEmpresa", "IdEmpresa");
            ViewData["IdProduto"] = new SelectList(_context.Produto, "IdProduto", "IdProduto");
            ViewData["IdTipoProduto"] = new SelectList(_context.TipoProduto, "IdTipoProduto", "IdTipoProduto");
            return View();
        }

        // POST: Compra/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCompra,IdProduto,IdTipoProduto,IdEmpresa,IdTipoPagamento,Preco,Ordem")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmpresa"] = new SelectList(_context.Empresa, "IdEmpresa", "IdEmpresa", compra.IdEmpresa);
            ViewData["IdProduto"] = new SelectList(_context.Produto, "IdProduto", "IdProduto", compra.IdProduto);
            ViewData["IdTipoProduto"] = new SelectList(_context.TipoProduto, "IdTipoProduto", "IdTipoProduto", compra.IdTipoProduto);
            return View(compra);
        }

        // GET: Compra/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compra.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }
            ViewData["IdEmpresa"] = new SelectList(_context.Empresa, "IdEmpresa", "IdEmpresa", compra.IdEmpresa);
            ViewData["IdProduto"] = new SelectList(_context.Produto, "IdProduto", "IdProduto", compra.IdProduto);
            ViewData["IdTipoProduto"] = new SelectList(_context.TipoProduto, "IdTipoProduto", "IdTipoProduto", compra.IdTipoProduto);
            return View(compra);
        }

        // POST: Compra/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCompra,IdProduto,IdTipoProduto,IdEmpresa,IdTipoPagamento,Preco,Ordem")] Compra compra)
        {
            if (id != compra.IdCompra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraExists(compra.IdCompra))
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
            ViewData["IdEmpresa"] = new SelectList(_context.Empresa, "IdEmpresa", "IdEmpresa", compra.IdEmpresa);
            ViewData["IdProduto"] = new SelectList(_context.Produto, "IdProduto", "IdProduto", compra.IdProduto);
            ViewData["IdTipoProduto"] = new SelectList(_context.TipoProduto, "IdTipoProduto", "IdTipoProduto", compra.IdTipoProduto);
            return View(compra);
        }

        // GET: Compra/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compra
                .Include(c => c.Empresa)
                .Include(c => c.Produto)
                .Include(c => c.TipoProduto)
                .FirstOrDefaultAsync(m => m.IdCompra == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // POST: Compra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compra = await _context.Compra.FindAsync(id);
            _context.Compra.Remove(compra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraExists(int id)
        {
            return _context.Compra.Any(e => e.IdCompra == id);
        }
    }
}
