using System.Web.Mvc;

namespace CampeonatoAjedrezAPI.Areas.Hospedaje
{
    public class HospedajeAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Hospedaje";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Hospedaje_default",
                "Hospedaje/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}