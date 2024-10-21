using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppExamJobMVC.Models;

namespace WebAppExamJobMVC.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        private readonly StudentContext _context;

        public StudentsController(StudentContext context)
        {
            _context = context;
        }


        // GET: Students
        public async Task<IActionResult> Index()
        {
            var studentContext = _context.Students.Include(s => s.Discipline);
            return View(await studentContext.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Discipline)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["DisciplineId"] = new SelectList(_context.Disciplines, "Id", "Name");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,FirstName,LastName,Group,Phone,Email,Score,DisciplineId")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DisciplineId"] = new SelectList(_context.Disciplines, "Id", "Name", student.DisciplineId);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["DisciplineId"] = new SelectList(_context.Disciplines, "Id", "Name", student.DisciplineId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,FirstName,LastName,Group,Phone,Email,Score,DisciplineId")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
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
            ViewData["DisciplineId"] = new SelectList(_context.Disciplines, "Id", "Name", student.DisciplineId);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Discipline)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }



        // Сумма баллов
        public IActionResult TotalScore()
        {
            var totalScore = _context.Students.Sum(s => s.Score);
            return View(totalScore);
        }

        // Пять лучших студентов
        public IActionResult TopStudents()
        {
            var topStudents = _context.Students.OrderByDescending(s => s.Score).Take(5).Include(s => s.Discipline).ToList();
            return View(topStudents);
        }

        // Пять худших студентов
        public IActionResult BottomStudents()
        {
            var bottomStudents = _context.Students.OrderBy(s => s.Score).Take(5).Include(s => s.Discipline).ToList();
            return View(bottomStudents);
        }

        // Экспорт в текстовый файл
        public IActionResult ExportToFile()
        {
            var students = _context.Students.Include(s => s.Discipline).ToList();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "students.txt");
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var student in students)
                {
                    writer.WriteLine($"{student.FirstName} {student.LastName} {student.Group} {student.Phone} {student.Email} ({student.Discipline.Name}): {student.Score}");
                }
            }
            return File("/students.txt", "text/plain", "students.txt");
        }

    }
}

