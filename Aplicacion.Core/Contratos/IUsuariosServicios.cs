using System;
using System.Collections.Generic;

namespace Aplicacion.Core
{
    public interface IUsuariosServicios:IDisposable
    {
        IEnumerable<UsuarioDTO> ListarTodos();

        IEnumerable<UsuarioDTO> ListarPorNombre(string pNombreUsuario);

        UsuarioDTO ValidarUsuario(string pNombreUsuario, string pClaveUsuario);

        UsuarioDTO ObtenerPorId(long pIdUsuario);

        UsuarioDTO ObtenerPorNombreUsuario(string pNombreUsuario);

        UsuarioDTO Crear(UsuarioDTO pEntidad);

        UsuarioDTO Modificar(UsuarioDTO pEntidad);

        UsuarioDTO Eliminar(long pUsuarioId);
    }
}
