using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchMovies.Data.Services;
using WatchMovies.Models;
using WatchMovies.Models.Domain;

namespace WatchMovies.Controllers
{
    public class ActorsController : Controller
    {
        private readonly DatabaseContext _context;

        public ActorsController(DatabaseContext context)
        {
            _context = context;   
        }

        public async Task<IActionResult> Index()
        {
            var allActors = await _context.Actors.ToListAsync();
            return View(allActors);
        }


        // GET: Actors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Actors == null)
            {
                return NotFound();
            }

            var actorDetails  = await _context.Actors
                .FirstOrDefaultAsync(a => a.Id == id);
            if (actorDetails == null)
            {
                return NotFound();
            }

            return View(actorDetails);
        }

        // GET: Actors/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
        {
            if (ModelState.IsValid)
            {
                return View(actor);
            }
            _context.Actors.Add(actor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Actors/Edit
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.Actors == null)
            {
                return NotFound();
            }

            var actorDetails = await _context.Actors.FindAsync(id);
            if (actorDetails == null)
            {
                return NotFound();
            }
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (id != actor.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Actors.Update(actor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActorExists(actor.Id))
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
            return View(actor);
        }

        private bool ActorExists(int id)
        {
            return (_context.Actors?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Actors == null)
            {
                return NotFound();
            }

            var actorDetails = await _context.Actors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actorDetails == null)
            {
                return NotFound();
            }

            return View(actorDetails);
        }

        // POST: Actors/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Actors.FindAsync(id) == null)
            {
                return Problem("Entity set 'DatabaseContext.Actors'  is null.");
            }
            var actorDetails = await _context.Actors.FindAsync(id);
            if (actorDetails != null)
            {
                _context.Actors.Remove(actorDetails);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}