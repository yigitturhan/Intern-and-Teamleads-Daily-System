using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject
{
    public class UserInfoContext:DbContext
    {
        public DbSet<Intern> Interns { get; set; }
        public DbSet<TeamLead> TeamLeads { get; set; }
    }
}
