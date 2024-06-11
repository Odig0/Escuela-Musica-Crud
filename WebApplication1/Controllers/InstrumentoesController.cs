using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class InstrumentoesController : Controller
    {
        private readonly EscuelaMusicaContext _context;

        public InstrumentoesController(EscuelaMusicaContext context)
        {
            _context = context;
        }

        // GET: Instrumentoes
        public async Task<IActionResult> Index()
        {
              return _context.Instrumentos != null ? 
                          View(await _context.Instrumentos.ToListAsync()) :
                          Problem("Entity set 'EscuelaMusicaContext.Instrumentos'  is null.");
        }

        // GET: Instrumentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Instrumentos == null)
            {
                return NotFound();
            }

            var instrumento = await _context.Instrumentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instrumento == null)
            {
                return NotFound();
            }

            return View(instrumento);
        }

        // GET: Instrumentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instrumentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Instrumento instrumento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instrumento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instrumento);
        }

        // GET: Instrumentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Instrumentos == null)
            {
                return NotFound();
            }

            var instrumento = await _context.Instrumentos.FindAsync(id);
            if (instrumento == null)
            {
                return NotFound();
            }
            return View(instrumento);
        }

        // POST: Instrumentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Instrumento instrumento)
        {
            if (id != instrumento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instrumento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstrumentoExists(instrumento.Id))
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
            return View(instrumento);
        }

        // GET: Instrumentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Instrumentos == null)
            {
                return NotFound();
            }

            var instrumento = await _context.Instrumentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instrumento == null)
            {
                return NotFound();
            }

            return View(instrumento);
        }

        // POST: Instrumentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Instrumentos == null)
            {
                return Problem("Entity set 'EscuelaMusicaContext.Instrumentos'  is null.");
            }
            var instrumento = await _context.Instrumentos.FindAsync(id);
            if (instrumento != null)
            {
                _context.Instrumentos.Remove(instrumento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstrumentoExists(int id)
        {
          return (_context.Instrumentos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
