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
    public class ViagensController : Controller
    {
        private readonly Context _context;

        public ViagensController(Context context)
        {
            _context = context;
        }

        // GET: Viagens
        public async Task<IActionResult> Index()
        {
            var context = _context.Viagem.Include(v => v.Motorista);
            return View(await context.ToListAsync());
        }

        // GET: Viagens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Viagem == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagem
                .Include(v => v.Motorista)
                .FirstOrDefaultAsync(m => m.ViagemId == id);
            if (viagem == null)
            {
                return NotFound();
            }

            return View(viagem);
        }

        // GET: Viagens/Create
        public IActionResult Create()
        {
            ViagemCreateModel modelVM = new ViagemCreateModel();

            List<SelectListItem> motoristas = _context.Motoristas
                .Select(n =>
                new SelectListItem
                {
                    Value = n.MotoristaId.ToString(),
                    Text = n.PrimeiroNome + " " + n.UltimoNome
                }).ToList();

            if (motoristas.Count == 0)
            {
                TempData["alertMessage"] = "Inclua pelo menos um motorista antes de continuar!!!";
            }

            modelVM.Motoristas = motoristas;

            return View(modelVM);
        }

        // POST: Viagens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ViagemId,DataViagem,LocalEntrega,LocalSaida,KmTotal,MotoristaId")] Viagem viagem)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(viagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            //ViewData["MotoristaId"] = new SelectList(_context.Motoristas, "MotoristaId", "MotoristaId", viagem.MotoristaId);
            //return View(viagem);
        }

        // GET: Viagens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Viagem == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagem.FindAsync(id);

            ViagemCreateModel modelVM = new ViagemCreateModel();

            List<SelectListItem> motoristas = _context.Motoristas
                .Select(n =>
                new SelectListItem
                {
                    Value = n.MotoristaId.ToString(),
                    Text = n.PrimeiroNome + " " + n.UltimoNome,
                }).ToList();

            foreach (var item in motoristas)
            {
                if (item.Value == id.ToString())
                {
                    item.Selected = true;
                    break;
                }
            }

            if (viagem == null)
            {
                return NotFound();
            }

            modelVM.Motoristas = motoristas;
            return View(modelVM);
        }

        // POST: Viagens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ViagemId,DataViagem,LocalEntrega,LocalSaida,KmTotal,MotoristaId")] Viagem viagem)
        {
            if (id != viagem.ViagemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViagemExists(viagem.ViagemId))
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
            ViewData["MotoristaId"] = new SelectList(_context.Motoristas, "MotoristaId", "MotoristaId", viagem.MotoristaId);
            return View(viagem);
        }

        // GET: Viagens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Viagem == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagem
                .Include(v => v.Motorista)
                .FirstOrDefaultAsync(m => m.ViagemId == id);
            if (viagem == null)
            {
                return NotFound();
            }

            return View(viagem);
        }

        // POST: Viagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Viagem == null)
            {
                return Problem("Entity set 'Context.Viagem'  is null.");
            }
            var viagem = await _context.Viagem.FindAsync(id);
            if (viagem != null)
            {
                _context.Viagem.Remove(viagem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViagemExists(int id)
        {
          return (_context.Viagem?.Any(e => e.ViagemId == id)).GetValueOrDefault();
        }
    }
}
