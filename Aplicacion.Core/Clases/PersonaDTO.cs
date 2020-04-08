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
            RespuestaOperacion = new RespuestaGenericaDTO();
        }
        //[Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PersonaId { get; set; }


        [Required]
        [Display(Name ="Rut")]
        public int Rut { get; set; }


        [Required]
        [StringLength(1)]
        [Display(Name = "no se ")]
        public string DV { get; set; }


        [Required, StringLength(50)]
        [Display(Name = " Primer Nombre")]
        public string PrimerNombre { get; set; }


        [StringLength(50)]
        [Display(Name = "Segundo Nombre")]
        public string SegundoNombre { get; set; }


        [StringLength(50)]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }


        [Required, StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Display(Name = "Fecha de creacion")]
        public DateTime FechaCreacion { get; set; }


        public bool Vigente { get; set; }

        public virtual ICollection<UsuarioDTO> Usuario { get; set; }

       
        
        
        #region propiedades no incluidas en la base de datos 
        [NotMapped]
        public RespuestaGenericaDTO RespuestaOperacion { get; set; } 

        #endregion
    }
}
