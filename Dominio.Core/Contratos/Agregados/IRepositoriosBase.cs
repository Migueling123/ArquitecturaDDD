using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dominio.Core
{
    public interface IRepositoriosBase<Entidad> : IDisposable
    {
        IUnidadDeTrabajo UnidadDeTrabajo { get; }

        Entidad ObtenerId(object pId);
        IEnumerable<Entidad> ObtenerConFiltro(Expression<Func<Entidad, bool>> pfiltro);
        IEnumerable<Entidad> ObtenerConFiltro(Expression<Func<Entidad, bool>> pfiltro, string pPropiedadesIncluidas);
        IEnumerable<Entidad> ObtenerTodos();
        Entidad ObtenerPrimero(Expression<Func<Entidad, bool>> pfiltro);
        Entidad Crear(Entidad pEntidadCrear);
        void Eliminar(Entidad pEntidadEliminar);


    }
}
