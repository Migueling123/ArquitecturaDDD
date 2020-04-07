namespace Datos.Persistencia.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using Dominio.Core;

    internal sealed class Configuration : DbMigrationsConfiguration<Datos.Persistencia.Core.ContextoPrincipal>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Datos.Persistencia.Core.ContextoPrincipal context)
        {
            context.Persona.Add(new Persona()
            {
                Rut = 16516,
                DV = "2",
                Apellido = "burg",
                PrimerNombre = "lans",
                SegundoNombre = "reic",
                Email = "laland@gmail",
                FechaCreacion = DateTime.Now,
                Vigente=true
            });

            try
            {
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges

                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
