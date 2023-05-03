using Greet;
using Grpc.Core;
using System.IO;
namespace server
{
    internal class Program
    {
        const int port = 50051;
        static void Main(string[] args)
        {
            // Server Class exist in Grpc.core
            Server server = null;
            try
            {

                server = new Server()
                {
                    // Register services 
                    // when client call GreetingServive => call impelementation 
                    Services = {GreetingService.BindService(new GreetingServiceImplentation()),
                                CalclatorServive.BindService(new CalaculatorServiceImplementation()),
                                PrimeNumberService.BindService(new PrimeNumberServiceImpl()),
                                AverageService.BindService(new AverageServiceImpl())
                    },
                    Ports = { new ServerPort("localhost", port, ServerCredentials.Insecure) }
                };
                server.Start();
                Console.WriteLine("The Server is listening on the port "+port);




                Console.ReadKey();
            }
            catch (IOException e)
            {
                Console.WriteLine("The Server is Failed to start : "+e.Message);
                throw;
            }
            finally
            {
                if (server != null)
                    server.ShutdownAsync().Wait();
            }
        }
    }
}