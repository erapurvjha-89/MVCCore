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
    public class CoursesController : Controller
    {
        private readonly ProjDBContext1 _context;

        public CoursesController(ProjDBContext1 context)
        {
            _context = context;    
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var projDBContext = _context.Course.Include(c => c.CourseCategory);
            return View(await projDBContext.ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courses = await _context.Course
                .Include(c => c.CourseCategory)
                .SingleOrDefaultAsync(m => m.CoursesId == id);
            if (courses == null)
            {
                return NotFound();
            }

            return View(courses);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            ViewData["CourseCategoryId"] = new SelectList(_context.CourseCategory, "CourseCategoryId", "CourseCategoryId");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CoursesId,CourseName,CourseDescription,CourseTutor,CourseFees,CourseCategoryId")] Courses courses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courses);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CourseCategoryId"] = new SelectList(_context.CourseCategory, "CourseCategoryId", "CourseCategoryId", courses.CourseCategoryId);
            return View(courses);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courses = await _context.Course.SingleOrDefaultAsync(m => m.CoursesId == id);
            if (courses == null)
            {
                return NotFound();
            }
            ViewData["CourseCategoryId"] = new SelectList(_context.CourseCategory, "CourseCategoryId", "CourseCategoryId", courses.CourseCategoryId);
            return View(courses);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CoursesId,CourseName,CourseDescription,CourseTutor,CourseFees,CourseCategoryId")] Courses courses)
        {
            if (id != courses.CoursesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoursesExists(courses.CoursesId))
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
            ViewData["CourseCategoryId"] = new SelectList(_context.CourseCategory, "CourseCategoryId", "CourseCategoryId", courses.CourseCategoryId);
            return View(courses);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courses = await _context.Course
                .Include(c => c.CourseCategory)
                .SingleOrDefaultAsync(m => m.CoursesId == id);
            if (courses == null)
            {
                return NotFound();
            }

            return View(courses);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courses = await _context.Course.SingleOrDefaultAsync(m => m.CoursesId == id);
            _context.Course.Remove(courses);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CoursesExists(int id)
        {
            return _context.Course.Any(e => e.CoursesId == id);
        }
    }
}
