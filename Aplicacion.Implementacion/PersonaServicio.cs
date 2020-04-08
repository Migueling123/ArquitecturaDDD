using System.Collections.Generic;
using Aplicacion.Core;
using AutoMapper;
using Dominio.Core;

namespace Aplicacion.Implementacion
{
    public class PersonaServicio:IPersonaServicio
    {
        private readonly ILogicaPersona _logicaPersona;
        private readonly IMapper _mapper;
        public PersonaServicio(ILogicaPersona logicaPersona, IMapper mapper)
        {
            _logicaPersona = logicaPersona;
            _mapper = mapper;
        }

        public PersonaDTO Crear(PersonaDTO pEntidad)
        {
            var objetoRespuesta = _logicaPersona.Crear(_mapper.Map<Persona>(pEntidad));
            return _mapper.Map<PersonaDTO>(objetoRespuesta);
        }
        public PersonaDTO Eliminar(long pPersonaId)
        {
            var objetoRespuesta = _logicaPersona.Eliminar(pPersonaId);
            return _mapper.Map<PersonaDTO>(objetoRespuesta);
        }

        public IEnumerable<PersonaDTO> ListarPorNombre(string pNombre)
        {
            return _mapper.Map<IEnumerable<PersonaDTO>>(_logicaPersona.ListarPorNombre(pNombre));
        }

        public IEnumerable<PersonaDTO> ListarTodos()
        {
            IEnumerable<PersonaDTO> ListadoPersonasDTO;
            try
            {
                var ListadoPersonas = _logicaPersona.ListarTodos();
                ListadoPersonasDTO = _mapper.Map<IEnumerable<PersonaDTO>>(ListadoPersonas);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return ListadoPersonasDTO;
        }

        public PersonaDTO Modificar(PersonaDTO pEntidad)
        {
            var objetoRespuesta = _logicaPersona.Modificar(_mapper.Map<Persona>(pEntidad));
            return _mapper.Map<PersonaDTO>(objetoRespuesta);
        }

        public PersonaDTO ObtenerPorId(long pIdPersona)
        {
            var objetoRespuesta = _logicaPersona.ObtenerPorId(pIdPersona);
            return _mapper.Map<PersonaDTO>(objetoRespuesta);
        }

        public PersonaDTO ObtenerPorRut(int pPersonaRut)
        {
            var objetoRespuesta = _logicaPersona.ObtenerPorId(pPersonaRut);
            return _mapper.Map<PersonaDTO>(objetoRespuesta);
        }









        #region Metodos Privados
        #endregion

        #region Dispose
        public void Dispose()
        {
            _logicaPersona.Dispose();
        }

        #endregion
    }
}
