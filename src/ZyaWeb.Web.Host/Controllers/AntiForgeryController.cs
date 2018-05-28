using Microsoft.AspNetCore.Antiforgery;
using ZyaWeb.Controllers;

namespace ZyaWeb.Web.Host.Controllers
{
    public class AntiForgeryController : ZyaWebControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
