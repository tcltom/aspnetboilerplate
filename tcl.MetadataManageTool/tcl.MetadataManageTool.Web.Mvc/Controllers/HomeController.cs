using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using tcl.MetadataManageTool.Controllers;

namespace tcl.MetadataManageTool.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : MetadataManageToolControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
