using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.InC
{
    /// <summary>
    /// Inicializa el tipado de la inversion de control
    /// </summary>
    /// <param name="registar"> </param>
    public interface IModulo
    {
        void Initialize(IRegistrarModulo registrar);
    }
}
