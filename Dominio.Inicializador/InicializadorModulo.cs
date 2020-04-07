using System.ComponentModel.Composition;
using Utilitarios.InC;
using Dominio.Core;
using Dominio.Implementacion;

namespace Dominio.Inicializador
{
    [Export(typeof(IModulo))]
    public class InicializadorModulo : IModulo
    {
        public void Initialize(IRegistrarModulo registrar)
        {
            registrar.RegistrarTipo<ILogicaUsuario, LogicaUsuario>();
            registrar.RegistrarTipo<ILogicaPersona, LogicaPersona>();
        }
    }
}
