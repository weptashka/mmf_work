using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCDraftDoctorProfi.Models;

namespace MVCDraftDoctorProfi.Data
{
    public class MVCDraftDoctorProfiContext : DbContext
    {
        public MVCDraftDoctorProfiContext (DbContextOptions<MVCDraftDoctorProfiContext> options)
            : base(options)
        {
        }

        public DbSet<MVCDraftDoctorProfi.Models.Movie> Movie { get; set; } = default!;
    }
}
