﻿using System;
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
    }
}
