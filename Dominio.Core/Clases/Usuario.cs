using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dominio.Core
{
    public class Usuario
    {
        public Usuario()
        {
            RespuestaOperacion = new RespuestaGenerica();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UsuarioId { get; set; }
        [Required]
        public long PersonaId { get; set; }
        [Required, StringLength(50)]
        public string NombreUsuario { get; set; }
        [Required, StringLength(100)]
        public string Clave { get; set; }
        public bool Vigente { get; set; }
        public DateTime FechaCreacion { get; set; }
        public virtual Persona Persona { get; set; }

        #region propiedades no incluidas en la base de datos 
        [NotMapped]
        public RespuestaGenerica RespuestaOperacion { get; set; }

        #endregion
    }
}