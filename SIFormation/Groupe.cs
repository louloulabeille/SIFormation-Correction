using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SIFormation.Models
{
    public class Groupe
    {
        [Required]
        public int ID { get; set; }
        public string Designation { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateDebut { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateFin { get; set; }
        public bool Favori { get; set; } = true;
        public Formateur AnimePar { get; set; }


}
}
