using System;
using System.Collections.Generic;
using Aplicacion.Core;
using Dominio.Core;
using AutoMapper;

namespace Aplicacion.Implementacion
{
    public class UsuarioServicio:IUsuariosServicios
    {
        private readonly ILogicaUsuario _logicaUsuario;
        private readonly IMapper _mapper;
        public UsuarioServicio(ILogicaUsuario logicaUsuario,IMapper mapper)
        {
            _logicaUsuario = logicaUsuario;
            _mapper = mapper;
        }

        public UsuarioDTO Crear(UsuarioDTO pEntidad)
        {
            var objetoRespuesta = _logicaUsuario.Crear(_mapper.Map<Usuario>(pEntidad));
            return _mapper.Map<UsuarioDTO>(objetoRespuesta);
        }

        

        public UsuarioDTO Eliminar(long pUsuarioId)
        {
            var objetoRespuesta = _logicaUsuario.Eliminar(pUsuarioId);
            return _mapper.Map<UsuarioDTO>(objetoRespuesta);
        }

        public IEnumerable<UsuarioDTO> ListarPorNombre(string pNombreUsuario)
        {
            return _mapper.Map<IEnumerable<UsuarioDTO>>(_logicaUsuario.ListarPorNombre(pNombreUsuario));
        }

        public IEnumerable<UsuarioDTO> ListarTodos()
        {
            return _mapper.Map<IEnumerable<UsuarioDTO>>(_logicaUsuario.ListarTodos());
        }

        public UsuarioDTO Modificar(UsuarioDTO pEntidad)
        {
            var objetoRespuesta = _logicaUsuario.Modificar(_mapper.Map<Usuario>(pEntidad));
            return _mapper.Map<UsuarioDTO>(objetoRespuesta);
        }

        public UsuarioDTO ObtenerPorId(long pIdUsuario)
        {
            var objetoRespuesta = _logicaUsuario.ObtenerPorId(pIdUsuario);
            return _mapper.Map<UsuarioDTO>(objetoRespuesta);
        }

        public UsuarioDTO ObtenerPorNombreUsuario(string pNombreUsuario)
        {
            var objetoRespuesta = _logicaUsuario.ObtenerPorNombreUsuario(pNombreUsuario);
            return _mapper.Map<UsuarioDTO>(objetoRespuesta);
        }

        public UsuarioDTO ValidarUsuario(string pNombreUsuario, string pClaveUsuario)
        {
            var objetoRespuesta = _logicaUsuario.ValidarUsuario(pNombreUsuario, pClaveUsuario);
            return _mapper.Map<UsuarioDTO>(objetoRespuesta);
        }








        #region Metodos Privados
        #endregion

        #region Dispose
        public void Dispose()
        {
            _logicaUsuario.Dispose();
        }
        #endregion
    }
}
