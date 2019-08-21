using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class EFContext:DbContext
    {
        public EFContext():base("ConnectionString")
        {

        }

        public virtual DbSet<Post> Posts { get; set; }
    }
}
