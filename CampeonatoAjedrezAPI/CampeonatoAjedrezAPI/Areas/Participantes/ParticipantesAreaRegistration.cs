using System.Web.Mvc;

namespace CampeonatoAjedrezAPI.Areas.Participantes
{
    public class ParticipantesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Participantes";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Participantes_default",
                "Participantes/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}