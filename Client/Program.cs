using Greet;
using Grpc.Core;
using System.ComponentModel.DataAnnotations;

namespace Client
{
    internal class Program
    {
        const string target = "127.0.0.1:50051";// socket

        static void Main(string[] args)
        {

            // Configuration To Connect on Server 
            Channel channel = new Channel(target, ChannelCredentials.Insecure);
            channel.ConnectAsync().ContinueWith((task) =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                {
                    Console.WriteLine("The Client Connected Successfully");
                }
            });


            // Client 
            //var Client = new dummyService.dummyServiceClient(channel);
            var client = new GreetingService.GreetingServiceClient(channel);

            var Request = new GreetingRequest()
            {
                Greeting = new Greeting()
                {
                    FirstName = "khaled",
                    LastName = "ibrahim"
                }
            };


         GreetingResponse response= client.Greet(Request);

            Console.WriteLine(response.Result);





            channel.ShutdownAsync().Wait();
            Console.ReadKey();




        }
    }
}