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
    public class ProdutoController : Controller
    {
        private readonly OracleContext _context;

        public ProdutoController(OracleContext context)
        {
            _context = context;
        }

        // GET: Produto
        public async Task<IActionResult> Index()
        {
            var oracleContext = _context.Produto.Include(p => p.Fornecedor).Include(p => p.TipoProduto);
            return View(await oracleContext.ToListAsync());
        }

        // GET: Produto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .Include(p => p.Fornecedor)
                .Include(p => p.TipoProduto)
                .FirstOrDefaultAsync(m => m.IdProduto == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produto/Create
        public IActionResult Create()
        {
            ViewData["IdFornecedor"] = new SelectList(_context.Fornecedor, "IdFornecedor", "IdFornecedor");
            ViewData["IdTipoProduto"] = new SelectList(_context.TipoProduto, "IdTipoProduto", "IdTipoProduto");
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProduto,NomeProduto,Quantidade,Ativo,Preco,DataAtualizacao,IdTipoProduto,IdFornecedor")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFornecedor"] = new SelectList(_context.Fornecedor, "IdFornecedor", "IdFornecedor", produto.IdFornecedor);
            ViewData["IdTipoProduto"] = new SelectList(_context.TipoProduto, "IdTipoProduto", "IdTipoProduto", produto.IdTipoProduto);
            return View(produto);
        }

        // GET: Produto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["IdFornecedor"] = new SelectList(_context.Fornecedor, "IdFornecedor", "IdFornecedor", produto.IdFornecedor);
            ViewData["IdTipoProduto"] = new SelectList(_context.TipoProduto, "IdTipoProduto", "IdTipoProduto", produto.IdTipoProduto);
            return View(produto);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProduto,NomeProduto,Quantidade,Ativo,Preco,DataAtualizacao,IdTipoProduto,IdFornecedor")] Produto produto)
        {
            if (id != produto.IdProduto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.IdProduto))
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
            ViewData["IdFornecedor"] = new SelectList(_context.Fornecedor, "IdFornecedor", "IdFornecedor", produto.IdFornecedor);
            ViewData["IdTipoProduto"] = new SelectList(_context.TipoProduto, "IdTipoProduto", "IdTipoProduto", produto.IdTipoProduto);
            return View(produto);
        }

        // GET: Produto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .Include(p => p.Fornecedor)
                .Include(p => p.TipoProduto)
                .FirstOrDefaultAsync(m => m.IdProduto == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produto.Any(e => e.IdProduto == id);
        }
    }
}
