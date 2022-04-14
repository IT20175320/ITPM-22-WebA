using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ITPM_22_WebA.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>):base(options)

            {
            }
    }
}

namespace ITPM_22_WebA
{
    class DbContextOptions<T>
    {
    }
}