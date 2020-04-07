using System.ComponentModel.Composition;
using Datos.Persistencia.Core;
using Datos.Persistencia.Implementacion;
using Dominio.Core;
using Utilitarios.InC;

namespace Datos.Persistencia.Inicializador
{
    [Export(typeof(IModulo))]
    public class InicializadorModulos : IModulo
    {
        public void Initialize(IRegistrarModulo registrar)
        {
            registrar.RegistrarTipo<IContextoUnidadDeTrabajo, ContextoPrincipal>();
            registrar.RegistrarTipo<IPersonaRepositorio, PersonaRepositorio>();
            registrar.RegistrarTipo<IUsuarioRepositorio, UsuarioRepositorio>();
            //CADA NUEVO REPOSITORIO VA ACA
        }
    }
}
