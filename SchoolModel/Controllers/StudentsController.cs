using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using SchoolModel.Areas.Identity.Data;
using SchoolModel.Core;
using SchoolModel.Data;
using SchoolModel.Models;

namespace SchoolModel.Controllers
{
    //[Authorize(Roles ="User")]
    public class StudentsController : Controller
    {
        private readonly SchoolContextData _context;

        public StudentsController(SchoolContextData context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _context.Student.
                Include(s=>s.Parent)
                .Include(s=>s.Class).ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.
                Include(s=>s.Parent)
                .Include(s=>s.Class)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewBag.Parents = _context.Parent.Select(p => p.Fullname);
            ViewBag.Classes = _context.Classroom.Select(c => c.ClassName);
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,MatricNumber,Email,Age,Parent,Class")] AddStudentViewModel _student)
        {
            if (ModelState.IsValid)
            {
                Parent parent = _context.Parent.Where(p => string.Compare(p.Fullname, _student.Parent, true) == 0).FirstOrDefault();
                if (parent == null)
                {
                    return View(_student);
                }

                Classroom classroom = _context.Classroom.Where(c => string.Compare(c.ClassName, _student.Class, true) == 0)
                    .FirstOrDefault();
                if (classroom == null)
                {
                    return View(_student);
                }

                Student student = new Student()
                {
                    FirstName=_student.FirstName,
                    LastName=_student.LastName,
                    MatricNumber=_student.MatricNumber,
                    Email=_student.Email,
                    Age=_student.Age,
                    Parent=parent,
                    Class=classroom,
                };

               
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(_student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _context.Student.Include(s => s.Parent)
                .Include(s=>s.Class)
                .Where(s => s.Id == id).FirstOrDefault();
            if (student == null)
            {
                return NotFound();
            }

            ViewBag.SelectedParent = student.Parent.Fullname;
            List<string> parents = _context.Parent.Select(p => p.Fullname).ToList() ;
            parents.Remove(student.Parent.Fullname);
            ViewBag.Parents = parents;

            ViewBag.SelectedClass = student.Class.ClassName;
            List<string> classes = _context.Classroom.Select(c => c.ClassName).ToList();
            classes.Remove(student.Class.ClassName);
            ViewBag.Classes = classes;




            EditStudentViewModel _student = new EditStudentViewModel()
            {
                Id=student.Id,
                FirstName=student.FirstName,
                LastName=student.LastName,
                MatricNumber=student.MatricNumber,
                Email=student.Email,
                Age=student.Age,
            };

            return View(_student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id,
            [Bind("Id,FirstName,LastName,MatricNumber,Email,Age,Parent,Class")] EditStudentViewModel student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    Parent parent = _context.Parent.Where(p => string.Compare(p.Fullname, student.Parent, true) == 0).FirstOrDefault();
                    if (parent == null)
                    {
                        return View(student);
                    }

                    Classroom classroom = _context.Classroom.Where(c => string.Compare(c.ClassName, student.Class, true) == 0).FirstOrDefault();
                    if (classroom == null)
                    {
                        return View(student);
                    }

                    var _student = _context.Student.Find(student.Id);
                    if (_student == null)
                    {
                        return View(student);
                    }


                    _student.FirstName = student.FirstName;
                    _student.LastName = student.LastName;
                        _student.MatricNumber = student.MatricNumber;
                    _student.Email = student.Email;
                    _student.Age = student.Age;
                    _student.Parent = parent;
                    _student.Class = classroom;

                    _context.Update(_student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var student = await _context.Student.FindAsync(id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(long id)
        {
            return _context.Student.Any(e => e.Id == id);
        }
    }
}
