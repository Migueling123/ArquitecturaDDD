using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Core;

namespace Dominio.Implementacion
{
    public class LogicaPersona:ILogicaPersona
    {
        private readonly IPersonaRepositorio _personaRepositorio;
        public LogicaPersona(IPersonaRepositorio personaRepositorio)
        {
            _personaRepositorio = personaRepositorio;
        }

        public Persona Crear(Persona pEntidad)
        {
            try
            {
                if (ValidarExistenciaPersona(pEntidad.Rut))
                {
                    pEntidad.RespuestaGenerica.Exito = false;
                    pEntidad.RespuestaGenerica.Mensaje = "El rut del usuario ingresado ya existe en la base de datos";


                }
                _personaRepositorio.Crear(pEntidad);
                _personaRepositorio.UnidadDeTrabajo.Confirmar();
                pEntidad.RespuestaGenerica.Exito = true;
                pEntidad.RespuestaGenerica.Mensaje = "Usuario creado correctamente";

            }
            catch (Exception ex)
            {
                pEntidad.RespuestaGenerica.Exito = false;
                pEntidad.RespuestaGenerica.Mensaje = "Ocurrio un error al crear el usuario, ::" + ex.Message;
            }
            return pEntidad;
        }


        public Persona Eliminar(long pPersonaId)
        {
            var entidadDB = _personaRepositorio.ObtenerPrimero(x => x.PersonaId == pPersonaId);
            var personaRespuesta = new Persona();
            try
            {
                if (entidadDB != null)
                {
                    entidadDB.Vigente = false;
                    _personaRepositorio.UnidadDeTrabajo.Confirmar();
                    personaRespuesta.RespuestaGenerica.Exito = true;
                    personaRespuesta.RespuestaGenerica.Mensaje = "Usuario eliminado correctamente";
                }
                else
                {
                    personaRespuesta.RespuestaGenerica.Exito = false;
                    personaRespuesta.RespuestaGenerica.Mensaje = "Usuario no encontrado";
                }
            }
            catch (Exception ex)
            {
                personaRespuesta.RespuestaGenerica.Exito = false;
                personaRespuesta.RespuestaGenerica.Mensaje = "Ocurrio un error al eliminar el usuario, ::" + ex.Message;
            }
            return personaRespuesta;
        }

        public IEnumerable<Persona> ListarPorNombre( string pNombre)
        {
            try
            {
                return _personaRepositorio.ObtenerConFiltro(x => x.PrimerNombre.ToUpper().Equals(pNombre.ToUpper()));

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IEnumerable<Persona> ListarTodos()
        {
            try
            {
                return _personaRepositorio.ObtenerTodos();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Persona Modificar(Persona pEntidad)
        {
            var entidadDB = _personaRepositorio.ObtenerPrimero(x => x.PersonaId == pEntidad.PersonaId);

            try
            {
                if (entidadDB != null)
                {
                    entidadDB.Vigente = pEntidad.Vigente;
                    entidadDB.PrimerNombre = pEntidad.PrimerNombre;
                    entidadDB.Rut = pEntidad.Rut;
                    entidadDB.SegundoNombre = pEntidad.SegundoNombre;
                    entidadDB.Apellido = pEntidad.Apellido;
                    entidadDB.DV = pEntidad.DV;
                    entidadDB.Email = pEntidad.Email;                    
                    _personaRepositorio.UnidadDeTrabajo.Confirmar();

                    entidadDB.RespuestaGenerica.Exito = true;
                    entidadDB.RespuestaGenerica.Mensaje = "persona Modificado correctamente";
                }
                else
                {
                    entidadDB.RespuestaGenerica.Exito = false;
                    entidadDB.RespuestaGenerica.Mensaje = "persona no existe en la base de datos";
                }

            }
            catch (Exception ex)
            {
                entidadDB.RespuestaGenerica.Exito = false;
                entidadDB.RespuestaGenerica.Mensaje = "Ocurrio un problema al realizar la operacion";

            }

            return entidadDB;
        }

        public Persona ObtenerPorId(long pIdPersona)
        {
            return _personaRepositorio.ObtenerId(pIdPersona);
        }

        public Persona ObtenerPorRut(long pPersonaRut)
        {
            return _personaRepositorio.ObtenerPrimero(x => x.Rut==pPersonaRut);
        }







        #region Metodos privados
        private bool ValidarExistenciaPersona(int rutPersona)
        {
            var contador = _personaRepositorio.ObtenerConFiltro(x => x.Rut==rutPersona).Count();
            return contador > 0;
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            _personaRepositorio.Dispose();
        }
        #endregion
    }
}
