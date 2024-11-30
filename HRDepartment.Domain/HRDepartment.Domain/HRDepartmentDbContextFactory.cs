using HRDepartment.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HRDepartment.EfCore
{
    public class HRDepartmentDbContextFactory : IDesignTimeDbContextFactory<HRDepartmentContext>
    {
        public HRDepartmentContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HRDepartmentContext>();
            optionsBuilder.UseMySql("server=localhost;port=3306;uid=root;pwd=P0Lin@23-01-2003;database=hrdepartment", new MySqlServerVersion(new Version(8, 0, 39)));
            return new HRDepartmentContext(optionsBuilder.Options);
        }
    }
}