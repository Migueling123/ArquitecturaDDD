using AutoMapper;
using System.ComponentModel.Composition;
using Utilitarios.InC;
using Aplicacion.Core;
using Aplicacion.Implementacion;

namespace Aplicacion.Inicializador
{
    [Export(typeof(IModulo))]
    public class InicializadorModulo:IModulo
    {
        public void Initialize(IRegistrarModulo registrar)
        {
            registrar.RegistrarTipo<IMapper, Mapper>();
            registrar.RegistrarTipo<IPersonaServicio, PersonaServicio>();
            registrar.RegistrarTipo<IUsuariosServicios, UsuarioServicio>();
        }

    }
}
