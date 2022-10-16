using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ADPortsGroup.Employees.Dto;
using ADPortsGroup.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPortsGroup.Employees
{
    public interface IEmployeeAppService: IApplicationService
    {
        Task<EmployeeDto> CreateAsync(EmployeeDto input);
        Task<EmployeeDto> UpdateAsync(EmployeeDto input);
        Task DeleteAsync(int Id);
        Task<ListResultDto<EmployeeDto>> GetAll();
    }
}
