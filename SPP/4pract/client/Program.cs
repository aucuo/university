using client;
using client.Services;
using Grpc.Net.Client;

class Program
{
    static async Task Main(string[] args)
    {
        // Подключение к серверу gRPC
        using var channel = GrpcChannel.ForAddress("http://localhost:5224");
        var client = new Employees.EmployeesClient(channel);

        try
        {
            var reply = await client.GetEmployeeAsync(new EmployeeRequest { EmployeeId = 1 });
            Console.WriteLine($"Employee: {reply.Name}, Position: {reply.Position}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error calling gRPC service: {ex.Message}");
        }
    }
}