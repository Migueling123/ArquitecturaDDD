using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Persistencia.Core;
using Dominio.Core;

namespace Datos.Persistencia.Implementacion
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>,IUsuarioRepositorio
    {
        public UsuarioRepositorio(IContextoUnidadDeTrabajo pUnidadDeTrabajo):base(pUnidadDeTrabajo)
        {

        }
    }
}
