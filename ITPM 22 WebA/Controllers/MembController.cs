using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ITPM_22_WebA.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ITPM_22_WebA.Controllers
{
    public class MembController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MembController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var displaydata = _db.MemberTable.ToList();

            return View(displaydata);
        }

        public IActionResult Create()

        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Create(NewMemberClass nec)
        {
            if(ModelState.IsValid)
            {
                _db.Add(nec);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return View(nec);
        }

        public async Task<IActionResult> Edit (int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");

            }

            var getMembdetails = await _db.MemberTable.FindAsync(id);
            return View(getMembdetails);
        }
           
        [HttpPost]
        public async Task<IActionResult> Edit (NewMemberClass nc)
        {
            if (ModelState.IsValid)
            {
                _db.Update(nc);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return View(nc);
        }
    }
}
