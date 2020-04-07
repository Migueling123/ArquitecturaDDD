using System.Collections.Generic;

namespace Dominio.Core
{
    public interface ILogicaUsuario
    {
        IEnumerable<Usuario> ListarTodos();

        IEnumerable<Usuario> ListarPorNombre();

        Usuario ValidarUsuario(string pNombreUsuario, string pClaveUsuario);

        Usuario ObtenerPorId(long pIdUsuario);
        Usuario ObtenerPorRut(long pUsuarioRut);
        Usuario Crear(Usuario pEntidad);
        Usuario Modificar(Usuario pEntidad);
        bool Eliminar(long pUsuarioId);
    }
}
