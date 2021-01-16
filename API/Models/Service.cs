using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Services
    {
        [Key]
        public int ServiceID { get; set; }

        public string ServiceNom { get; set; }

        public ICollection<Medecin> Medecin { get; set; }



    }
}