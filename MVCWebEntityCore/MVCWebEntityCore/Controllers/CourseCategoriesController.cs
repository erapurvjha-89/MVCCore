using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCWebEntityCore.Models;

namespace MVCWebEntityCore.Controllers
{
    public class CourseCategoriesController : Controller
    {
        private readonly ProjDBContext1 _context;

        public CourseCategoriesController(ProjDBContext1 context)
        {
            _context = context;    
        }

        // GET: CourseCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.CourseCategory.ToListAsync());
        }

        // GET: CourseCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseCategory = await _context.CourseCategory
                .SingleOrDefaultAsync(m => m.CourseCategoryId == id);
            if (courseCategory == null)
            {
                return NotFound();
            }

            return View(courseCategory);
        }

        // GET: CourseCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CourseCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseCategoryId,CategegoryName,CategoryDescription")] CourseCategory courseCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(courseCategory);
        }

        // GET: CourseCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseCategory = await _context.CourseCategory.SingleOrDefaultAsync(m => m.CourseCategoryId == id);
            if (courseCategory == null)
            {
                return NotFound();
            }
            return View(courseCategory);
        }

        // POST: CourseCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseCategoryId,CategegoryName,CategoryDescription")] CourseCategory courseCategory)
        {
            if (id != courseCategory.CourseCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseCategoryExists(courseCategory.CourseCategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(courseCategory);
        }

        // GET: CourseCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseCategory = await _context.CourseCategory
                .SingleOrDefaultAsync(m => m.CourseCategoryId == id);
            if (courseCategory == null)
            {
                return NotFound();
            }

            return View(courseCategory);
        }

        // POST: CourseCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseCategory = await _context.CourseCategory.SingleOrDefaultAsync(m => m.CourseCategoryId == id);
            _context.CourseCategory.Remove(courseCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CourseCategoryExists(int id)
        {
            return _context.CourseCategory.Any(e => e.CourseCategoryId == id);
        }
    }
}
