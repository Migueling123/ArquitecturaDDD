using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace Utilitarios.InC
{
    public class RegistrarModulo : IRegistrarModulo
    {
        /// <summary>
        /// Miebro que adoptara el comportamiento del contenedor de Unity
        /// </summary>
        private readonly IUnityContainer _contenedor;
        /// <summary>
        /// Crea instancia de objeto que registra los modulos asiciados a IoC
        /// </summary>
        /// <param name="container"></param>
        public RegistrarModulo(IUnityContainer container)
        {
            this._contenedor = container;
        }
        /// <summary>
        /// Registra tipos Utilizando Unity
        /// </summary>
        /// <typeparam name="TOrigen">Tipo de Origen</typeparam>
        /// <typeparam name="TDestino">Tipo de Destino</typeparam>
        /// <param name="conIntercepcion">Indicador si requiere Intercepcion</param>
        public void RegistrarTipo<TOrigen, TDestino>(bool conIntercepcion = false) where TDestino : TOrigen
        {
            if (!conIntercepcion)
            {
                this._contenedor.RegisterType<TOrigen, TDestino>();
            }
        }

        public void RegistrarTipoConVidaControlada<TOrigen, TDestino>(bool conIntercepcion = false) where TDestino : TOrigen
        {
            this._contenedor.RegisterType<TOrigen, TDestino>(new ContainerControlledLifetimeManager());
            
        }
    }
}
