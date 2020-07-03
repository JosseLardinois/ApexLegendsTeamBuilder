using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApexLegendsTeamBuilder.Models;
using Microsoft.AspNetCore.Authorization;

namespace ApexLegendsTeamBuilder.Controllers
{
    [Authorize]
    public class ApexLegendsController : Controller
    {
        private readonly LegendsContext _context;

        public ApexLegendsController(LegendsContext context)
        {
            _context = context;
        }

        // GET: ApexLegends
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApexLegends.ToListAsync());
        }

        // GET: ApexLegends/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apexLegend = await _context.ApexLegends
                .FirstOrDefaultAsync(m => m.LegendId == id);
            if (apexLegend == null)
            {
                return NotFound();
            }

            return View(apexLegend);
        }

        // GET: ApexLegends/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApexLegends/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LegendId,LegendName,LegendType")] ApexLegend apexLegend)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apexLegend);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(apexLegend);
        }

        // GET: ApexLegends/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apexLegend = await _context.ApexLegends.FindAsync(id);
            if (apexLegend == null)
            {
                return NotFound();
            }
            return View(apexLegend);
        }

        // POST: ApexLegends/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LegendId,LegendName,LegendType")] ApexLegend apexLegend)
        {
            if (id != apexLegend.LegendId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apexLegend);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApexLegendExists(apexLegend.LegendId))
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
            return View(apexLegend);
        }

        // GET: ApexLegends/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apexLegend = await _context.ApexLegends
                .FirstOrDefaultAsync(m => m.LegendId == id);
            if (apexLegend == null)
            {
                return NotFound();
            }

            return View(apexLegend);
        }

        // POST: ApexLegends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apexLegend = await _context.ApexLegends.FindAsync(id);
            _context.ApexLegends.Remove(apexLegend);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApexLegendExists(int id)
        {
            return _context.ApexLegends.Any(e => e.LegendId == id);
        }
    }
}
