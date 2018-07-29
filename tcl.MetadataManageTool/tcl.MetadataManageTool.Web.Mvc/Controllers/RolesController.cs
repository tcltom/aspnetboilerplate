using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using tcl.MetadataManageTool.Authorization;
using tcl.MetadataManageTool.Controllers;
using tcl.MetadataManageTool.Roles;
using tcl.MetadataManageTool.Web.Models.Roles;
using tcl.MetadataManageTool.Schools;

namespace tcl.MetadataManageTool.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Roles)]
    public class RolesController : MetadataManageToolControllerBase
    {
        private readonly IRoleAppService _roleAppService;

        private readonly ISchoolAppService _schoolAppService;

        public RolesController(IRoleAppService roleAppService, ISchoolAppService schoolAppService)
        {
            _roleAppService = roleAppService;
            _schoolAppService = schoolAppService;
        }

        public async Task<IActionResult> Index()
        {
           var gh= _schoolAppService.GetSchools(new Schools.Dto.GetSchoolsInput());

            var roles = (await _roleAppService.GetAll(new PagedAndSortedResultRequestDto())).Items;
            var permissions = (await _roleAppService.GetAllPermissions()).Items;
            var model = new RoleListViewModel
            {
                Roles = roles,
                Permissions = permissions
            };

            return View(model);
        }

        public async Task<ActionResult> EditRoleModal(int roleId)
        {
            var role = await _roleAppService.Get(new EntityDto(roleId));
            var permissions = (await _roleAppService.GetAllPermissions()).Items;
            var model = new EditRoleModalViewModel
            {
                Role = role,
                Permissions = permissions
            };
            return View("_EditRoleModal", model);
        }
    }
}
