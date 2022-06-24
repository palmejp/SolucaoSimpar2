using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SolucaoSimpar2.Models;

namespace SolucaoSimpar2.Controllers
{
    public class CaminhoesController : Controller
    {
        private readonly Context _context;

        public CaminhoesController(Context context)
        {
            _context = context;
        }

        // GET: Caminhoes
        public async Task<IActionResult> Index()
        {
              return _context.Caminhoes != null ? 
                          View(await _context.Caminhoes.ToListAsync()) :
                          Problem("Entity set 'Context.Caminhoes'  is null.");
        }

        // GET: Caminhoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Caminhoes == null)
            {
                return NotFound();
            }

            var caminhao = await _context.Caminhoes
                .FirstOrDefaultAsync(m => m.CaminhaoId == id);
            if (caminhao == null)
            {
                return NotFound();
            }

            return View(caminhao);
        }

        // GET: Caminhoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Caminhoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CaminhaoId,Marca,Modelo,Placa,Eixo")] Caminhao caminhao)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(caminhao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            //return View(caminhao);
        }

        // GET: Caminhoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Caminhoes == null)
            {
                return NotFound();
            }

            var caminhao = await _context.Caminhoes.FindAsync(id);
            if (caminhao == null)
            {
                return NotFound();
            }
            return View(caminhao);
        }

        // POST: Caminhoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CaminhaoId,Marca,Modelo,Placa,Eixo")] Caminhao caminhao)
        {
            if (id != caminhao.CaminhaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caminhao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaminhaoExists(caminhao.CaminhaoId))
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
            return View(caminhao);
        }

        // GET: Caminhoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Caminhoes == null)
            {
                return NotFound();
            }

            var caminhao = await _context.Caminhoes
                .FirstOrDefaultAsync(m => m.CaminhaoId == id);
            if (caminhao == null)
            {
                return NotFound();
            }

            return View(caminhao);
        }

        // POST: Caminhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Caminhoes == null)
            {
                return Problem("Entity set 'Context.Caminhoes'  is null.");
            }
            var caminhao = await _context.Caminhoes.FindAsync(id);
            if (caminhao != null)
            {
                _context.Caminhoes.Remove(caminhao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaminhaoExists(int id)
        {
          return (_context.Caminhoes?.Any(e => e.CaminhaoId == id)).GetValueOrDefault();
        }
    }
}
