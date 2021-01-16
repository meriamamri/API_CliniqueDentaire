using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class UserManagementContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public UserManagementContext() : base("name=UserManagementContext")
        {
        }

        public System.Data.Entity.DbSet<API.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<API.Models.Patient> Patients { get; set; }


        public System.Data.Entity.DbSet<API.Models.Rdv> Rdvs { get; set; }

        public System.Data.Entity.DbSet<API.Models.Medecin> Medecins { get; set; }

        public System.Data.Entity.DbSet<API.Models.Services> Services { get; set; }
    }
}
