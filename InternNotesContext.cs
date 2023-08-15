using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject
{
    public class InternNotesContext:DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<Return> Returns { get; set; }

    }
}
