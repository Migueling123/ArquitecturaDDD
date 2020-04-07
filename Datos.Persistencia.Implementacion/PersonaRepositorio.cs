using Datos.Persistencia.Core;
using Dominio.Core;

namespace Datos.Persistencia.Implementacion
{
    public class PersonaRepositorio:RepositorioBase<Persona>,IPersonaRepositorio
    {
        public PersonaRepositorio(IContextoUnidadDeTrabajo pUnidadDeTrabajo):base(pUnidadDeTrabajo)
        {

        }
    }
}
