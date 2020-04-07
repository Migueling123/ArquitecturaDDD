using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using System.Text;
using Aplicacion.Profiles;
using AutoMapper;
using Unity;

namespace Utilitarios.InC
{
    /// <summary>
    /// Carga los modulos decorados con el export y que implementan el IModulo
    /// </summary>
    public static class CargadorModulo
    {
        ///<summary>
        ///Realiza la carga del contenedor de Unity enviado desde el bootstapper
        /// </summary>
        /// <param name="contenedor">Contenedor de Unity</param>
        /// <param name="ruta">Ruta desde la cual se obtendran las dll</param>
        /// <param name="patron"> Patron para buscar las componentes a cargar</param>
        public static void CargarContenedor(IUnityContainer contenedor,string ruta, string patron)
        {

            var dirCat = new DirectoryCatalog(ruta, patron);
            var importDef = BuildImportDefinition();
            try
            {
                using (var aggregateCatalog = new AggregateCatalog())
                {
                    aggregateCatalog.Catalogs.Add(dirCat);
                    using (var componsitionContainer = new CompositionContainer(aggregateCatalog))
                    {
                        IEnumerable<Export> exports = componsitionContainer.GetExports(importDef);
                        IEnumerable<IModulo> modulos = exports.Select(export => export.Value as IModulo).Where(m => m != null);

                        var registrar = new RegistrarModulo(contenedor);

                        foreach(IModulo modulo in modulos)
                        {
                            modulo.Initialize(registrar);
                        }
                    }
                }
            }
            catch(ReflectionTypeLoadException typeLoadException)
            {
                var builder = new StringBuilder();
                foreach(Exception loaderException in typeLoadException.LoaderExceptions)
                {
                    builder.AppendFormat("{0}\n", loaderException.Message);
                }
                throw new TypeLoadException(builder.ToString(), typeLoadException);
            }
        }
        /// <summary>
        /// Construye la definicion del tipo importado
        /// </summary>
        /// <returns>Definicion Generada</returns>
        private static ImportDefinition BuildImportDefinition()
        {
            return new ImportDefinition(def => true, typeof(IModulo).FullName, ImportCardinality.ZeroOrMore, false, false);
        }
        /// <summary>
        /// Configura el mapeo para entidades de Datos contra entidades de servicio
        /// </summary>
        /// <param name="container"></param>
        public static void ConfigurarMapeos(IUnityContainer container)
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PerfilMapeo>();
            });
            var mapper = mapperConfiguration.CreateMapper();
            container.RegisterInstance<IMapper>(mapper);
        }
    }
}
