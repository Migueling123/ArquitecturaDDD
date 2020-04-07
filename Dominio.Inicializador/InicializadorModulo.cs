using System.ComponentModel.Composition;
using Utilitarios.InC;

namespace Dominio.Inicializador
{
    [Export(typeof(IModulo))]
    public class InicializadorModulo : IModulo
    {
        public void Initialize(IRegistrarModulo registrar)
        {
            
        }
    }
}
