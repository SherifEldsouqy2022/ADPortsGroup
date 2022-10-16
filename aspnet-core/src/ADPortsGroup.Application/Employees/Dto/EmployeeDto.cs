using System.ComponentModel.DataAnnotations;
using Abp.Auditing;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using ADPortsGroup.Employee;

namespace ADPortsGroup.Employees.Dto
{
    [AutoMapTo(typeof(Employee.Employee))]
    [AutoMapFrom(typeof(Employee.Employee))]
    public class EmployeeDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string EmployeeName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(250)]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

    }
}
