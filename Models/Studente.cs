using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentiMVC_CRUD.Models
{
    [Table("Students")]
    public class Studente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Il Nome è obbligatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Il Cognome è obbligatorio")]
        public string Cognome { get; set; }

        public DateTime DataNascita { get; set; }

    }
}