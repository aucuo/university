using Grpc.Core;
using client;
using static client.Employees;

namespace client.Services
{
    public class EmployeeService : EmployeesBase
    {
        public override Task<Employee> GetEmployee(EmployeeRequest request, ServerCallContext context)
        {
            return Task.FromResult(new Employee
            {
                Id = request.EmployeeId,
                Name = "Иван Иванов",
                Position = "Разработчик"
            });
        }
    }
}