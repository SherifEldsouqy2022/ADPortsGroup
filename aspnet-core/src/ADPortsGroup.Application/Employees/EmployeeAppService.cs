using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.ObjectMapping;
using ADPortsGroup.Authorization;
using ADPortsGroup.Employee.Manager;
using ADPortsGroup.Employees.Dto;
using ADPortsGroup.Roles.Dto;
using ADPortsGroup.Users.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADPortsGroup.Employees
{
    [AbpAuthorize]
    public class EmployeeAppService : ApplicationService, IEmployeeAppService
    {
        private readonly EmployeeManager _employeeManager;
        private readonly IObjectMapper _objectMapper;

        public EmployeeAppService(EmployeeManager employeeManager, IObjectMapper objectMapper)
        {
            _employeeManager = employeeManager;
            _objectMapper = objectMapper;
        }

        public async Task<EmployeeDto> CreateAsync(EmployeeDto input)
        {
            var result = await _employeeManager.Create(_objectMapper.Map<Employee.Employee>(input));
            return ObjectMapper.Map<EmployeeDto>(result);
        }

        public async Task DeleteAsync(int Id)
        {
            await _employeeManager.Delete(Id);
        }

        public async Task<EmployeeDto> Get(int Id)
        {
            var result = await _employeeManager.Get(Id);
            return ObjectMapper.Map<EmployeeDto>(result);
        }

        public async Task<ListResultDto<EmployeeDto>> GetAll()
        {
            var result = await _employeeManager.GetAll();
            return new ListResultDto<EmployeeDto>(ObjectMapper.Map<List<EmployeeDto>>(result));
        }

        public async Task<EmployeeDto> UpdateAsync(EmployeeDto input)
        {
            var result = await _employeeManager.Update(_objectMapper.Map<Employee.Employee>(input));
            return ObjectMapper.Map<EmployeeDto>(result);
        }
    }
}
