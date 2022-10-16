using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ADPortsGroup.Authorization.Roles;
using ADPortsGroup.Authorization.Users;
using ADPortsGroup.MultiTenancy;

namespace ADPortsGroup.EntityFrameworkCore
{
    public class ADPortsGroupDbContext : AbpZeroDbContext<Tenant, Role, User, ADPortsGroupDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public ADPortsGroupDbContext(DbContextOptions<ADPortsGroupDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Employee.Employee> Employees { get; set; }
    }
}
