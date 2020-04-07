using System;
using System.Data.Entity;
using Dominio.Core;

namespace Datos.Persistencia.Core
{
    public interface IContextoUnidadDeTrabajo:IUnidadDeTrabajo,IDisposable
    {
        #region Tablas de nuestro Proyecto
        IDbSet<Persona> Persona { get;  }

        IDbSet<Usuario> Usuario { get;  }
        //si hay mas tablas se agregan en este lugar
        #endregion

        IDbSet<Entidad> Set<Entidad>() where Entidad : class;

        void Attach<Entidad>(Entidad item) where Entidad : class;

        void SetModified<Entidad>(Entidad item) where Entidad : class;
        void SetDeleted<Entidad>(Entidad item) where Entidad : class;

    }
}
