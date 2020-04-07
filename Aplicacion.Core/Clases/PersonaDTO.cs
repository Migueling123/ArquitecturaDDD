using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Aplicacion.Core
{
    public class PersonaDTO
    {
        public PersonaDTO()
        {
            RespuestaGenericaDTO = new RespuestaGenericaDTO();
        }
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

        public virtual ICollection<UsuarioDTO> Usuario { get; set; }

        #region propiedades no incluidas en la base de datos 
        [NotMapped]
        public RespuestaGenericaDTO RespuestaGenericaDTO { get; set; } 

        #endregion
    }
}
