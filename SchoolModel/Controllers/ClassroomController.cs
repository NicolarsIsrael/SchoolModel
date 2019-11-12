using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolModel.Core;
using SchoolModel.Models;
using SchoolModel.Data;

namespace SchoolModel.Controllers
{
    public class ClassroomController : Controller
    {
        private readonly SchoolContextData _context;

        public ClassroomController(SchoolContextData context)
        {
            _context = context;
        }

        // GET: Classroom
        public async Task<IActionResult> Index()
        {
            return View(await _context.Classroom.Include(c=>c.Students).ToListAsync());
        }

        public ActionResult AllStudents(string className)
        {
            return View(_context.Student.Where(s => string.Compare(s.Class.ClassName, className,true) == 0).ToList());
        }

        // GET: Classroom/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classroom = await _context.Classroom
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classroom == null)
            {
                return NotFound();
            }

            return View(classroom);
        }

        // GET: Classroom/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Classroom/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClassName,TutorName")] Classroom classroom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classroom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classroom);
        }

        // GET: Classroom/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classroom = await _context.Classroom.FindAsync(id);
            if (classroom == null)
            {
                return NotFound();
            }
            return View(classroom);
        }

        // POST: Classroom/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClassName,TutorName")] Classroom classroom)
        {
            if (id != classroom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classroom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassroomExists(classroom.Id))
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
            return View(classroom);
        }

        // GET: Classroom/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classroom = await _context.Classroom
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classroom == null)
            {
                return NotFound();
            }

            return View(classroom);
        }

        // POST: Classroom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classroom = await _context.Classroom.FindAsync(id);
            _context.Classroom.Remove(classroom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassroomExists(int id)
        {
            return _context.Classroom.Any(e => e.Id == id);
        }

        public async Task<IActionResult> CreateAttendance(int classId)
        {
            Classroom classroom = _context.Classroom.Include(c => c.Students)
                .Where(c => c.Id == classId).FirstOrDefault();
            if (classroom == null)
            {
                return NotFound();
            }
            ViewBag.Students = classroom.Students.Select(s=>s.MatricNumber).ToList() ;
            ViewBag.ClassroomName = classroom.ClassName;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAttendance(AddAttendanceViewModel attendance, List<string> studentList)
        {
            {
                Classroom classroom = _context.Classroom.Include(c => c.Students)
                    .Where(c => c.ClassName == attendance.Classroom).FirstOrDefault();
                if (classroom == null)
                {
                    return NotFound();
                }


                string students = studentList != null ? String.Join(",", studentList) : "";
                Attendance _attendance = new Attendance()
                {
                    AttendanceDate = attendance.AttendanceDate,
                    Classroom = classroom,
                    PresetStudentMatricNumber = students,
                };

                _context.Add(_attendance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
