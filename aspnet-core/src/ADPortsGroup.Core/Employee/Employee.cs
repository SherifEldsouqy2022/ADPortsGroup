using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPortsGroup.Employee
{
    public class Employee : Entity
    {
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

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
