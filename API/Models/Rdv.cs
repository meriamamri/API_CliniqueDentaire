using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Rdv
    {
        [Key]
        public int RdvID { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true), Display(Name = "Date")]
        public DateTime? Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true), Display(Name = "Hdebut")]
        public DateTime? Hdebut { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true), Display(Name = "Hfin")]
        public DateTime? Hfin { get; set; }

        [Required]
        public int? PatientID { get; set; }

        [ForeignKey("PatientID")]
        public virtual Patient Patient { get; set; }

        [Required]
        public int? MedecinID { get; set; }

        [ForeignKey("MedecinID")]
        public virtual Medecin Medecin { get; set; }


    }
}