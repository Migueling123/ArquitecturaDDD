using System.Collections.Generic;

namespace Dominio.Core
{
    public interface ILogicaUsuario
    {
        IEnumerable<Usuario> ListarTodos();

        IEnumerable<Usuario> ListarPorNombre(string pNombreUsuario);

        Usuario ValidarUsuario(string pNombreUsuario, string pClaveUsuario);

        Usuario ObtenerPorId(long pIdUsuario);
        Usuario ObtenerPorNombreUsuario(string pNombreUsuario);
        Usuario Crear(Usuario pEntidad);
        Usuario Modificar(Usuario pEntidad);
        Usuario Eliminar(long pUsuarioId);
    }
}
