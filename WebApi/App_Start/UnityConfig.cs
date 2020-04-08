using System.Web.Http;
using Unity;
using Utilitarios.InC;
namespace WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {

            var container = new UnityContainer();
            CargadorModulo.CargarContenedor(container, ".\\bin", "*.Inicializador.dll");
            CargadorModulo.ConfigurarMapeos(container);
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}