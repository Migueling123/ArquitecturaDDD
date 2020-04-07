using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Dominio.Core;


namespace Datos.Persistencia.Core
{
    public class ContextoPrincipal:DbContext,IContextoUnidadDeTrabajo
    {
        public ContextoPrincipal() : base("DefaultConnection") { }


        IDbSet<Persona> _persona;

        IDbSet<Usuario> _usuario;

        public IDbSet<Persona> Persona
        {
            get{ return _persona ?? (_persona = base.Set<Persona>()); }//??si es distinto de null
        }
        public IDbSet<Usuario> Usuario
        {
            get { return _usuario ?? (_usuario = base.Set<Usuario>()); }
        }
        public new IDbSet<Entidad> Set<Entidad>() where Entidad : class
        {
            return base.Set<Entidad>();
        }

        public void Attach<Entidad>(Entidad item) where Entidad : class
        {
            if (Entry(item).State == EntityState.Detached)
            {
                base.Set<Entidad>().Attach(item);
            }
        }

        public void Confirmar()
        {
            base.SaveChanges(); 
        }

        public void SetDeleted<Entidad>(Entidad item) where Entidad : class
        {
            Entry(item).State = EntityState.Deleted;
        }

        public void SetModified<Entidad>(Entidad item) where Entidad : class
        {
            Entry(item).State = EntityState.Modified;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Configuration.LazyLoadingEnabled = false;
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

        }

    }
}
