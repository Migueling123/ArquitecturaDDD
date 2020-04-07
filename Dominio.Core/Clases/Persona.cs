using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dominio.Core
{
    public class Persona
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PersonaId { get; set; }
        [Required]
        public int Rut { get; set; }
        [Required]
        [StringLength(1)]
        public string DV { get; set; }
        [Required, StringLength(50)]
        public string PrimerNombre { get; set; }
        [StringLength(50)]
        public string SegundoNombre { get; set; }
        [StringLength(50)]
        public string Apellido { get; set; }
        [Required, StringLength(50)]

        public string Email { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Vigente { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
