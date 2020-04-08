using System.Web.Http;
using System.Web.Mvc;

namespace WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            UnityConfig.RegisterComponents();
            AreaRegistration.RegisterAllAreas();

        }
    }
}
