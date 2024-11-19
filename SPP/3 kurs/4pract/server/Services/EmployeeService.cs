using Grpc.Core;
using server;
using static server.Employees;

namespace server.Services
{
    public class EmployeeService : EmployeesBase
    {
        public override Task<Employee> GetEmployee(EmployeeRequest request, ServerCallContext context)
        {
            return Task.FromResult(new Employee
            {
                Id = request.EmployeeId,
                Name = "Егорчик",
                Position = "Разработчик (крутой)"
            });
        }
    }
}