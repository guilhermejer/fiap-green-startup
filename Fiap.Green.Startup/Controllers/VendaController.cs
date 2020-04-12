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
    public class VendaController : Controller
    {
        private readonly OracleContext _context;

        public VendaController(OracleContext context)
        {
            _context = context;
        }

        // GET: Venda
        public async Task<IActionResult> Index()
        {
            var oracleContext = _context.Venda.Include(v => v.Empresa).Include(v => v.Fornecedor).Include(v => v.Produto);
            return View(await oracleContext.ToListAsync());
        }

        // GET: Venda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .Include(v => v.Empresa)
                .Include(v => v.Fornecedor)
                .Include(v => v.Produto)
                .FirstOrDefaultAsync(m => m.IdVenda == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Venda/Create
        public IActionResult Create()
        {
            ViewData["IdEmpresa"] = new SelectList(_context.Empresa, "IdEmpresa", "IdEmpresa");
            ViewData["IdFornecedor"] = new SelectList(_context.Fornecedor, "IdFornecedor", "IdFornecedor");
            ViewData["IdProduto"] = new SelectList(_context.Produto, "IdProduto", "IdProduto");
            return View();
        }

        // POST: Venda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVenda,IdEmpresa,IdFornecedor,Descricao,Estoque,Preco,IdProduto")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmpresa"] = new SelectList(_context.Empresa, "IdEmpresa", "IdEmpresa", venda.IdEmpresa);
            ViewData["IdFornecedor"] = new SelectList(_context.Fornecedor, "IdFornecedor", "IdFornecedor", venda.IdFornecedor);
            ViewData["IdProduto"] = new SelectList(_context.Produto, "IdProduto", "IdProduto", venda.IdProduto);
            return View(venda);
        }

        // GET: Venda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }
            ViewData["IdEmpresa"] = new SelectList(_context.Empresa, "IdEmpresa", "IdEmpresa", venda.IdEmpresa);
            ViewData["IdFornecedor"] = new SelectList(_context.Fornecedor, "IdFornecedor", "IdFornecedor", venda.IdFornecedor);
            ViewData["IdProduto"] = new SelectList(_context.Produto, "IdProduto", "IdProduto", venda.IdProduto);
            return View(venda);
        }

        // POST: Venda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVenda,IdEmpresa,IdFornecedor,Descricao,Estoque,Preco,IdProduto")] Venda venda)
        {
            if (id != venda.IdVenda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.IdVenda))
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
            ViewData["IdEmpresa"] = new SelectList(_context.Empresa, "IdEmpresa", "IdEmpresa", venda.IdEmpresa);
            ViewData["IdFornecedor"] = new SelectList(_context.Fornecedor, "IdFornecedor", "IdFornecedor", venda.IdFornecedor);
            ViewData["IdProduto"] = new SelectList(_context.Produto, "IdProduto", "IdProduto", venda.IdProduto);
            return View(venda);
        }

        // GET: Venda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .Include(v => v.Empresa)
                .Include(v => v.Fornecedor)
                .Include(v => v.Produto)
                .FirstOrDefaultAsync(m => m.IdVenda == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Venda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venda = await _context.Venda.FindAsync(id);
            _context.Venda.Remove(venda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
            return _context.Venda.Any(e => e.IdVenda == id);
        }
    }
}
