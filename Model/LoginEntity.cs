using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Model
{
    public class LoginEntity : DbContext
    {
        public DbSet<Student> Student { get; set; }

    }
}
