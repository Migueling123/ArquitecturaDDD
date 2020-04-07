using System;
using System.Collections.Generic;
using System.Linq;
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
            try
            {
                if (ValidarExistenciaUsuario(pEntidad.NombreUsuario))
                {
                    pEntidad.RespuestaGenerica.Exito = false;
                    pEntidad.RespuestaGenerica.Mensaje = "El nombre del usuario ingresado ya existe en la base de datos";
                        
                }
                _usuarioRepositorio.Crear(pEntidad);
                _usuarioRepositorio.UnidadDeTrabajo.Confirmar();
                pEntidad.RespuestaGenerica.Exito = true;
                pEntidad.RespuestaGenerica.Mensaje = "Usuario creado correctamente";

            }
            catch (Exception ex)
            {
                pEntidad.RespuestaGenerica.Exito = false;
                pEntidad.RespuestaGenerica.Mensaje = "Ocurrio un error al crear el usuario, ::"+ex.Message;
            }
            return pEntidad;
        }

        public Usuario Eliminar(long pUsuarioId)
        {
            var entidadDB = _usuarioRepositorio.ObtenerPrimero(x => x.UsuarioId == pUsuarioId);
            var usuarioRespuesta = new Usuario();
            try
            {                
                if (entidadDB != null)
                {
                    entidadDB.Vigente = false;
                    _usuarioRepositorio.UnidadDeTrabajo.Confirmar();
                    usuarioRespuesta.RespuestaGenerica.Exito = true;
                    usuarioRespuesta.RespuestaGenerica.Mensaje = "Usuario eliminado correctamente";
                }
                else
                {
                    usuarioRespuesta.RespuestaGenerica.Exito = false;
                    usuarioRespuesta.RespuestaGenerica.Mensaje = "Usuario no encontrado";
                }
            }
            catch (Exception ex)
            {
                usuarioRespuesta.RespuestaGenerica.Exito = false;
                usuarioRespuesta.RespuestaGenerica.Mensaje = "Ocurrio un error al eliminar el usuario, ::" + ex.Message;
            }
            return usuarioRespuesta;
        }

        public IEnumerable<Usuario> ListarPorNombre(string pNombreUsuario)
        {
            try
            {
                return _usuarioRepositorio.ObtenerConFiltro(x => x.NombreUsuario.ToUpper().Equals(pNombreUsuario.ToUpper()));

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IEnumerable<Usuario> ListarTodos()
        {
            try
            {
                return _usuarioRepositorio.ObtenerTodos();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Usuario Modificar(Usuario pEntidad)
        {
            var entidadDB = _usuarioRepositorio.ObtenerPrimero(x => x.UsuarioId == pEntidad.UsuarioId);

            try
            {
                if (entidadDB != null)
                {
                    entidadDB.Vigente = pEntidad.Vigente;
                    entidadDB.NombreUsuario = pEntidad.NombreUsuario;
                    entidadDB.PersonaId = pEntidad.PersonaId;
                    
                    entidadDB.Clave = pEntidad.Clave;
                    _usuarioRepositorio.UnidadDeTrabajo.Confirmar();

                    entidadDB.RespuestaGenerica.Exito = true;
                    entidadDB.RespuestaGenerica.Mensaje = "Usuario Modificado correctamente";


                }
                else
                {
                    entidadDB.RespuestaGenerica.Exito = false;
                    entidadDB.RespuestaGenerica.Mensaje = "Usuario no existe en la base de datos";
                }

            }
            catch(Exception ex)
            {
                entidadDB.RespuestaGenerica.Exito = false;
                entidadDB.RespuestaGenerica.Mensaje = "Ocurrio un problema al realizar la operacion";

            }
            
            return entidadDB;
        }

        public Usuario ObtenerPorId(long pIdUsuario)
        {
            return _usuarioRepositorio.ObtenerId(pIdUsuario);
        }

        public Usuario ObtenerPorNombreUsuario(string pNombreUsuario)
        {
            return _usuarioRepositorio.ObtenerPrimero(x => x.NombreUsuario.ToUpper().Equals(pNombreUsuario.ToUpper()));

        }

        public Usuario ValidarUsuario(string pNombreUsuario, string pClaveUsuario)
        {
            return _usuarioRepositorio.ObtenerConFiltro(x => x.NombreUsuario.ToUpper().Equals(pNombreUsuario.ToUpper()) && x.Clave == pClaveUsuario).FirstOrDefault();
        }

        #region Metodos privados
        private bool ValidarExistenciaUsuario(string pNombreUsuario)
        {
            var contador = _usuarioRepositorio.ObtenerConFiltro(x => x.NombreUsuario.ToUpper().Equals(pNombreUsuario.ToUpper())).Count();
            return contador > 0;
        }
        #endregion
    }
}
