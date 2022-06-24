using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SolucaoSimpar2.Models;
using SolucaoSimpar2.ViewModel;

namespace SolucaoSimpar2.Controllers
{
    public class MotoristasController : Controller
    {
        private readonly Context _context;

        public MotoristasController(Context context)
        {
            _context = context;
        }

        // GET: Motoristas
        public async Task<IActionResult> Index()
        {
            var context = _context.Motoristas.Include(m => m.Caminhao);
            return View(await context.ToListAsync());
        }

        // GET: Motoristas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Motoristas == null)
            {
                return NotFound();
            }

            var motorista = await _context.Motoristas
                .Include(m => m.Caminhao)
                .FirstOrDefaultAsync(m => m.MotoristaId == id);
            if (motorista == null)
            {
                return NotFound();
            }

            return View(motorista);
        }

        // GET: Motoristas/Create
        public IActionResult Create()
        {
            MotoristaCreateModel modelVM = new MotoristaCreateModel();

            List<SelectListItem> caminhoes = _context.Caminhoes
                .Select(n =>
                new SelectListItem
                {
                    Value = n.CaminhaoId.ToString(),
                    Text = n.Marca + " Placa" + n.Placa
                }).ToList();

            if (caminhoes.Count == 0)
            {
                TempData["alertMessage"] = "Inclua pelo menos um caminhão antes de continuar!!!";
            }

            modelVM.Caminhoes = caminhoes;

            return View(modelVM);
        }

        // POST: Motoristas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MotoristaId,PrimeiroNome,UltimoNome,CaminhaoId,Endereco")] Motorista motorista)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(motorista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            //ViewData["CaminhaoId"] = new SelectList(_context.Caminhoes, "CaminhaoId", "CaminhaoId", motorista.CaminhaoId);
            //return View(motorista);
        }

        // GET: Motoristas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Motoristas == null)
            {
                return NotFound();
            }

            var motorista = await _context.Motoristas.FindAsync(id);

            MotoristaCreateModel modelVM = new MotoristaCreateModel();

            List<SelectListItem> caminhoes = _context.Caminhoes
                .Select(n =>
                new SelectListItem
                {
                    Value = n.CaminhaoId.ToString(),
                    Text = n.Marca + " Placa" + n.Placa
                }).ToList();

            foreach (var item in caminhoes)
            {
                if (item.Value == id.ToString())
                {
                    item.Selected = true;
                    break;
                }
            }

            if (motorista == null)
            {
                return NotFound();
            }

            modelVM.Caminhoes = caminhoes;
            return View(modelVM);
        }

        // POST: Motoristas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MotoristaId,PrimeiroNome,UltimoNome,CaminhaoId,Endereco")] Motorista motorista)
        {
            if (id != motorista.MotoristaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motorista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotoristaExists(motorista.MotoristaId))
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
            ViewData["CaminhaoId"] = new SelectList(_context.Caminhoes, "CaminhaoId", "CaminhaoId", motorista.CaminhaoId);
            return View(motorista);
        }

        // GET: Motoristas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Motoristas == null)
            {
                return NotFound();
            }

            var motorista = await _context.Motoristas
                .Include(m => m.Caminhao)
                .FirstOrDefaultAsync(m => m.MotoristaId == id);
            if (motorista == null)
            {
                return NotFound();
            }

            return View(motorista);
        }

        // POST: Motoristas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Motoristas == null)
            {
                return Problem("Entity set 'Context.Motoristas'  is null.");
            }
            var motorista = await _context.Motoristas.FindAsync(id);
            if (motorista != null)
            {
                _context.Motoristas.Remove(motorista);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotoristaExists(int id)
        {
          return (_context.Motoristas?.Any(e => e.MotoristaId == id)).GetValueOrDefault();
        }
    }
}
