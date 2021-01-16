using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace API.Models
{
    public class User
    {   
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
      
        public string Password {get;set;}

        public string Type { get; set; }
       
    }

}