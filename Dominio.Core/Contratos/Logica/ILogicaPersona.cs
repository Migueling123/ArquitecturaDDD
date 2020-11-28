using System;
using System.Collections.Generic;

namespace Dominio.Core
{
    public interface ILogicaPersona :IDisposable
    {
        IEnumerable<Persona> ListarTodos();

        IEnumerable<Persona> ListarPorNombre(string pNombre);

        Persona ObtenerPorId(long pIdPersona);

        Persona ObtenerPorRut(long pPersonaRut);

        Persona Crear(Persona pEntidad);

        Persona Modificar(Persona pEntidad);

        Persona Eliminar(long pPersonaId);
    }
}
