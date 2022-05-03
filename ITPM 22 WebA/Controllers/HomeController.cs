using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ITPM_22_WebA.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ITPM_22_WebA.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _oHostEnvironment;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult PrintMember(int param)

        {
            List<NewMemberClass> oMembers = new List<NewMemberClass>();

            for (int i=1; i <= 10; i++)
            {
                NewMemberClass oMember = new NewMemberClass();
                oMember.Mid = i;
                oMember.Mname = "Mname" + i;
                oMember.Email = "Email" + i;
                oMember.Address = "Address" + i;
                oMember.Pnumber = "Pnumber" + i;


                oMembers.Add(oMember);
            }

            MemberReport rpt = new MemberReport(_oHostEnvironment);
            return File(rpt.Report(oMembers),"application/pdf_-");
        }
     
    }
}



