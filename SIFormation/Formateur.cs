using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SIFormation.Models
{
   public class Formateur
    {
        [Required]
        [StringLength(7,ErrorMessage ="7 caractères obligatoires")]
        public string Matricule { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        [EmailAddress]
        public string AdresseMail { get; set; }
    }
}
