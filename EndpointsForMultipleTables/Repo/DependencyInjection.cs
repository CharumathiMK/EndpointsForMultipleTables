using EndpointsForMultipleTables.Interface;
using EndpointsForMultipleTables.Models;
using Microsoft.EntityFrameworkCore;

namespace EndpointsForMultipleTables.Repo
{
    //purpose of this class and method is to register various repository classes
    //and database configurations in the dependency injection container.
    public static class DependencyInjection
    {//extension method named "AddRepository"
     //which can be called on objects of type "IServiceCollection".
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IDepartment, DepartmentRepository>();
            services.AddTransient<IEmployee, EmployeeRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<TaskDatabaseContext>(options => options
            .UseSqlServer("Server=CIPL1411DBA\\SQLEXPRESS2019;Database=TaskDatabase;User Id=sa;Password=Colan123;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;Integrated Security=FALSE;"));
            return services;
        }
    }
}
