using AutoMapper;
using Aplicacion.Core;
using Dominio.Core;

namespace Aplicacion.Profiles
{
    public class PerfilMapeo:Profile
    {
        public PerfilMapeo()
        {
            CreateMap<PersonaDTO, Persona>().ReverseMap();
            CreateMap<UsuarioDTO, Usuario>().ReverseMap();
            CreateMap<RespuestaGenericaDTO, RespuestaGenerica>().ReverseMap();

        }
    }
}
