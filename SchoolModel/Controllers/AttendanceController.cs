using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolModel.Core;
using SchoolModel.Data;

namespace SchoolModel.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly SchoolContextData _context;

        public AttendanceController(SchoolContextData context)
        {
            _context = context;
        }

        // GET: Attendance
        public async Task<IActionResult> Index()
        {
            return View(await _context.Attendance.ToListAsync());
        }

        //// GET: Attendance/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var attendance = await _context.Attendance
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (attendance == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(attendance);
        //}

        //// GET: Attendance/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Attendance/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,AttendanceDate,PresetStudentMatricNumber")] Attendance attendance)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(attendance);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(attendance);
        //}

        //// GET: Attendance/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var attendance = await _context.Attendance.FindAsync(id);
        //    if (attendance == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(attendance);
        //}

        //// POST: Attendance/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,AttendanceDate,PresetStudentMatricNumber")] Attendance attendance)
        //{
        //    if (id != attendance.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(attendance);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AttendanceExists(attendance.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(attendance);
        //}

        //// GET: Attendance/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var attendance = await _context.Attendance
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (attendance == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(attendance);
        //}

        //// POST: Attendance/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var attendance = await _context.Attendance.FindAsync(id);
        //    _context.Attendance.Remove(attendance);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool AttendanceExists(int id)
        //{
        //    return _context.Attendance.Any(e => e.Id == id);
        //}
    }
}
