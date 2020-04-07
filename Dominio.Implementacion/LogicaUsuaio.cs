using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Core;
 
namespace Dominio.Implementacion
{
    public class LogicaUsuario : ILogicaUsuario
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public LogicaUsuario(IUsuarioRepositorio pUsuarioRepositorio)
        {
            _usuarioRepositorio = pUsuarioRepositorio;
        }
        public Usuario Crear(Usuario pEntidad)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(long pUsuarioId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> ListarPorNombre()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public Usuario Modificar(Usuario pEntidad)
        {
            throw new NotImplementedException();
        }

        public Usuario ObtenerPorId(long pIdUsuario)
        {
            throw new NotImplementedException();
        }

        public Usuario ObtenerPorRut(long pUsuarioRut)
        {
            throw new NotImplementedException();
        }

        public Usuario ValidarUsuario(string pNombreUsuario, string pClaveUsuario)
        {
            throw new NotImplementedException();
        }
        private bool ValidarExistenciaUsuario(string nombreUsuario)
        {

        }
    }
}
