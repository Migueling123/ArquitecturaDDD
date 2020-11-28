using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dominio.Core;

namespace Datos.Persistencia.Core
{
    public class RepositorioBase<Entidad> : IRepositoriosBase<Entidad> where Entidad : class 
    {
        readonly IContextoUnidadDeTrabajo _unidadDeTrabajo; 
        public IUnidadDeTrabajo UnidadDeTrabajo
        {
            get { return _unidadDeTrabajo; }
        }
        public RepositorioBase(IContextoUnidadDeTrabajo pUnidadDeTrabajo)
        {
            _unidadDeTrabajo = pUnidadDeTrabajo;
        }
        public Entidad Crear(Entidad pEntidadCrear)
        {
           return _unidadDeTrabajo.Set<Entidad>().Add(pEntidadCrear);
        }

        

        public void Eliminar(Entidad pEntidadEliminar)
        {
            _unidadDeTrabajo.SetDeleted(pEntidadEliminar);
            _unidadDeTrabajo.Set<Entidad>().Remove(pEntidadEliminar);
        }

        public IEnumerable<Entidad> ObtenerConFiltro(Expression<Func<Entidad, bool>> pfiltro)
        {
            IQueryable<Entidad> consulta = _unidadDeTrabajo.Set<Entidad>();
            if (pfiltro != null)
            {
                consulta = consulta.Where(pfiltro);
            }
            return consulta.ToList();
        }

        public IEnumerable<Entidad> ObtenerConFiltro(Expression<Func<Entidad, bool>> pfiltro, string pPropiedadesIncluidas)
        {
            IQueryable<Entidad> consulta = _unidadDeTrabajo.Set<Entidad>();
            if (!string.IsNullOrEmpty(pPropiedadesIncluidas))
            {
                consulta = pPropiedadesIncluidas.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).
                    Aggregate(consulta, (current, propiedadIncluida) => current.Include(propiedadIncluida));
            }
            if (pfiltro != null)
            {
                consulta = consulta.Where(pfiltro);
            }
            return consulta.ToList();
        }

        public Entidad ObtenerId(object pId)
        {
            return _unidadDeTrabajo.Set<Entidad>().Find(pId);
        }

        public Entidad ObtenerPrimero(Expression<Func<Entidad, bool>> pfiltro)
        {
            return _unidadDeTrabajo.Set<Entidad>().FirstOrDefault(pfiltro);
        }

        public IEnumerable<Entidad> ObtenerTodos()
        {
            return _unidadDeTrabajo.Set<Entidad>().ToList();
        }
        public void Dispose()
        {
            _unidadDeTrabajo.Dispose();
        }
    }
}
