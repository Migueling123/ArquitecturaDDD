using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.InC
{
    public interface IRegistrarModulo
    {
        /// <summary>
        /// registra tipos utilizando el contenedor de Unity
        /// </summary>
        /// <typeparam name="TOrigen">Tipo de Origen</typeparam>
        /// <typeparam name="TDestino">Tipo de destino</typeparam>
        /// <parma name="conIntercepcion">Indicador si requiere Intercepcion</parma>
        /// 

        void RegistrarTipo<TOrigen, TDestino>(bool conIntercepcion = false) where TDestino : TOrigen;
        /// <summary>
        /// Registra tipos utilizando Unity y permite controlar el tiempo de vida de la ejecucion del contenedor
        /// </summary>
        /// <typeparam name="TOrigen"></typeparam>
        /// <typeparam name="TDestino"></typeparam>
        /// <param name="conIntercepcion"></param>

        void RegistrarTipoConVidaControlada<TOrigen, TDestino>(bool conIntercepcion = false) where TDestino : TOrigen;
    }
}
