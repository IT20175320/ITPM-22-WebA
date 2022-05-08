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
using System.IO;
using Microsoft.AspNetCore.Hosting;
using ITPM_22_WebA.Reports;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;


namespace ITPM_22_WebA.Controllers
{
    public class MembController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _oHostEnvironment;

        public MembController(ApplicationDbContext db)
        {
            _db = db;

        }

        public IActionResult Index()
        {
            var displaydata = _db.MemberTable.ToList();

            return View(displaydata);
        }

        //search
        [HttpGet]

        public async Task<IActionResult> Index (string Membsearch)
        {
            ViewData["Getmemberdetails"] = Membsearch;

            var memquery = from x in _db.MemberTable select x;
            if(!string.IsNullOrEmpty(Membsearch))
            {
                memquery = memquery.Where(x =>x.Mname.Contains(Membsearch));
            }

            return View(await memquery.AsNoTracking().ToListAsync());

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
                TempData["save"] = "This Member has been added";
                return RedirectToAction("Index");

            }
            return View(nec);
        }

        //Edit btn
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
                TempData["Edit"] = "Member details has been Updated";
                return RedirectToAction("Index");

            }
            return View(nc);
        }
        
        //Details btn
        public async Task<IActionResult> Details (int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");

            }

            var getMembdetails = await _db.MemberTable.FindAsync(id);
            return View(getMembdetails);
        }

        //Delete btn
        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");

            }

            var getMembdetails = await _db.MemberTable.FindAsync(id);
            return View(getMembdetails);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(int id)
        {
          
            var getMembdetails = await _db.MemberTable.FindAsync(id);
            _db.MemberTable.Remove(getMembdetails);
            await _db.SaveChangesAsync();
            TempData["Delete"] = "Member details has been Deleted";
            return RedirectToAction("Index");
        }

        public IActionResult PrintReport(int param)
        {
            List<NewMemberClass> getmemberdetails = new List<NewMemberClass>();



            getmemberdetails = _db.MemberTable.ToList();



            MemberReport rpt = new MemberReport(_oHostEnvironment);
            return File(rpt.Report(getmemberdetails), "application/pdf");
        }


    }
}
