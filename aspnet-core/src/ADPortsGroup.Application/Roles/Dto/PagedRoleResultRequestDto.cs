using Abp.Application.Services.Dto;

namespace ADPortsGroup.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

