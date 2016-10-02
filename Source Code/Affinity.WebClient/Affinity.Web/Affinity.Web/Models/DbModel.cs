using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Affinity.Web.Models
{
    public class DbModel:DbContext
    {
        public DbModel():base("DefaultConnection")
        {

        }

       public virtual DbSet<AffiReports> AffiReports { get; set; }
    }
    public class AffiReports
    {
        [Key]
        public int Id { get; set; }
        public string ClientCode { get; set; }
        public string ReportName { get; set; }
        public string ReportURL { get; set; }
    }
}