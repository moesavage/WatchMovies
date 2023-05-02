using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchMovies.Models;
using WatchMovies.Models.Domain;

namespace WatchMovies.Controllers
{
    public class ProducersController : Controller
    {
        private readonly DatabaseContext _context;

        public ProducersController(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allProducers = await _context.Producers.ToListAsync();
            return View(allProducers);
        }

        // GET: Producer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Producers == null)
            {
                return NotFound();
            }

            var producerDetails = await _context.Producers
                .FirstOrDefaultAsync(p => p.Id == id);
            if (producerDetails == null)
            {
                return NotFound();
            }

            return View(producerDetails);
        }

        // GET: Producer/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            if (ModelState.IsValid)
            {
                return View(producer);
            }
            _context.Producers.Add(producer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Producer/Edit
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.Producers == null)
            {
                return NotFound();
            }

            var producerDetails = await _context.Producers.FindAsync(id);
            if (producerDetails == null)
            {
                return NotFound();
            }
            return View(producerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            if (id != producer.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Producers.Update(producer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActorExists(producer.Id))
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
            return View(producer);
        }

        private bool ActorExists(int id)
        {
            return (_context.Producers?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Producers == null)
            {
                return NotFound();
            }

            var producerDetails = await _context.Producers
                .FirstOrDefaultAsync(p => p.Id == id);
            if (producerDetails == null)
            {
                return NotFound();
            }

            return View(producerDetails);
        }
        // POST: Actors/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Producers.FindAsync(id) == null)
            {
                return Problem("Entity set 'DatabaseContext.Producers'  is null.");
            }
            var producerDetails = await _context.Producers.FindAsync(id);
            if (producerDetails != null)
            {
                _context.Producers.Remove(producerDetails);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }

}