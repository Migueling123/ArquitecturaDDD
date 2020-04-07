
using AutoMapper;
using Aplicacion.Core;
using Dominio.Core;

namespace Aplicacion.Profiles
{
    public class PerfilMapeo:Profile
    {
        protected void Configure()
        {
            CreateMap<PersonaDTO, Persona>().ReverseMap();
            CreateMap<UsuarioDTO, Usuario>().ReverseMap();

        }
    }
}
