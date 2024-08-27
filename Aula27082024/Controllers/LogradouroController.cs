using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aula27082024.Data;
using Aula27082024.Models;

namespace Aula27082024.Controllers
{
    public class LogradouroController : Controller
    {
        private readonly Aula27082024Context _context;

        public LogradouroController(Aula27082024Context context)
        {
            _context = context;
        }

        // GET: Logradouro
        public async Task<IActionResult> Index()
        {
            return View(await _context.Logradouro.ToListAsync());
        }

        // GET: Logradouro/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logradouro = await _context.Logradouro
                .FirstOrDefaultAsync(m => m.id == id);
            if (logradouro == null)
            {
                return NotFound();
            }

            return View(logradouro);
        }

        // GET: Logradouro/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Logradouro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cep,Endereco,Numero,Cidade,Estado,Pais,id")] Logradouro logradouro)
        {
            if (ModelState.IsValid)
            {
                logradouro.id = Guid.NewGuid();
                _context.Add(logradouro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(logradouro);
        }

        // GET: Logradouro/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logradouro = await _context.Logradouro.FindAsync(id);
            if (logradouro == null)
            {
                return NotFound();
            }
            return View(logradouro);
        }

        // POST: Logradouro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Cep,Endereco,Numero,Cidade,Estado,Pais,id")] Logradouro logradouro)
        {
            if (id != logradouro.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logradouro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogradouroExists(logradouro.id))
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
            return View(logradouro);
        }

        // GET: Logradouro/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logradouro = await _context.Logradouro
                .FirstOrDefaultAsync(m => m.id == id);
            if (logradouro == null)
            {
                return NotFound();
            }

            return View(logradouro);
        }

        // POST: Logradouro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var logradouro = await _context.Logradouro.FindAsync(id);
            _context.Logradouro.Remove(logradouro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogradouroExists(Guid id)
        {
            return _context.Logradouro.Any(e => e.id == id);
        }
    }
}
