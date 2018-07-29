using Microsoft.AspNetCore.Antiforgery;
using tcl.MetadataManageTool.Controllers;

namespace tcl.MetadataManageTool.Web.Host.Controllers
{
    public class AntiForgeryController : MetadataManageToolControllerBase
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
