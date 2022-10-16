using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ADPortsGroup.EntityFrameworkCore
{
    public static class ADPortsGroupDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ADPortsGroupDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ADPortsGroupDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
