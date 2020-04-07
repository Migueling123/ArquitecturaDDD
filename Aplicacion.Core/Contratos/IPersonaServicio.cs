using System;
using System.Collections.Generic;

namespace Aplicacion.Core
{
    public interface IPersonaServicio:IDisposable
    {
        IEnumerable<PersonaDTO> ListarTodos();

        IEnumerable<PersonaDTO> ListarPorNombre(string pNombre);

        PersonaDTO ObtenerPorId(long pIdPersona);

        PersonaDTO ObtenerPorRut(int pPersonaRut);

        PersonaDTO Crear(PersonaDTO pEntidad);

        PersonaDTO Modificar(PersonaDTO pEntidad);

        PersonaDTO Eliminar(long pPersonaId);
    }
}
