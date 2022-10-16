using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPortsGroup.Employee.Manager
{
    public class EmployeeManager : DomainService
    {
        private readonly IRepository<Employee> _employeeRepository;
        public EmployeeManager(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _employeeRepository.GetAllListAsync(x => !x.IsDeleted);
        }

        public async Task<Employee> Create(Employee employee)
        {
            employee.CreatedDate = DateTime.Now;
            var result = _employeeRepository.InsertAsync(employee);
            await CurrentUnitOfWork.SaveChangesAsync();
            return await result;
        }

        public async Task<Employee> Get(int Id)
        {
            return await _employeeRepository.GetAsync(Id);
        }

        public async Task<Employee> Update(Employee employee)
        {
            employee.UpdatedDate = DateTime.Now;
            var result = _employeeRepository.UpdateAsync(employee);
            await CurrentUnitOfWork.SaveChangesAsync();
            return await result;
        }

        public async Task Delete(int empId)
        {
            var result = _employeeRepository.GetAsync(empId);
            result.Result.IsDeleted = true;
            await CurrentUnitOfWork.SaveChangesAsync();
        }
    }
}
