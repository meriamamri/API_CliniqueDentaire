using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Adresse { get; set; }

        public string tel { get; set; }

        public string carteSoin { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true), Display(Name = "Date")]
        public DateTime? DateNaissance { get; set; }

        [Required]
        public int? UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual  User UserAccount { get; set; }

    }
}