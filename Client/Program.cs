using Greet;
using Grpc.Core;
using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace Client
{
    internal class Program
    {
        const string target = "127.0.0.1:50051";// socket

        static async Task Main(string[] args)
        {

            // Configuration To Connect on Server 
            Channel channel = new Channel(target, ChannelCredentials.Insecure);
           await channel.ConnectAsync().ContinueWith((task) =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                {
                    Console.WriteLine("The Client Connected Successfully");
                }
            });


            // Client 
            //var Client = new dummyService.dummyServiceClient(channel);

            #region GreetingService

            //var client = new GreetingService.GreetingServiceClient(channel);

            //var Request = new GreetingRequest()
            //{
            //    Greeting = new Greeting()
            //    {
            //        FirstName = "khaled",
            //        LastName = "ibrahim"
            //    }
            //};


            // GreetingResponse response= client.Greet(Request);

            //Console.WriteLine(response.Result); 
            #endregion

            #region Impelemet CalclatorServive => Unary API


            //var client = new CalclatorServive.CalclatorServiveClient(channel);

            //CalclatorRequest calclatorRequest = new CalclatorRequest()
            //{
            //    Calculator = new Calculator()
            //    {
            //        Number1 = 3,
            //        Number2 = 10
            //    }
            //};

            //CalclatorResponse calclatorResponse =client.Sum(calclatorRequest);
            //Console.WriteLine(calclatorResponse.Result);

            #endregion

            #region Impelement GreetingManyTimes => Server Streaming

            //  Impelement GreetingManyTimes => Server Streaming


            //  var client = new GreetingService.GreetingServiceClient(channel);
            //  var request = new GreetingManytimesRequest()
            //  {
            //      Greeting = new Greeting()
            //      {
            //          FirstName = "khaled",
            //          LastName = "ibrahim"
            //      }
            //  };


            //  // Note Response of type stream 

            //var response=  client.GreetManyTimes(request);

            //  while (await response.ResponseStream.MoveNext())
            //  {
            //      var CurrentResponse= response.ResponseStream.Current;
            //      Console.WriteLine(CurrentResponse.Result);
            //     await Task.Delay(1000);
            //  }


            #endregion

            #region Impelement PrimeNumberService => Server Streaming
            // List<PrimeNumberDecompositionResponse> responsesLst=new List<PrimeNumberDecompositionResponse>();

            // var client = new PrimeNumberService.PrimeNumberServiceClient(channel);

            // var request = new PrimeNumberDecompositionRequest() {Number=210 };

            //var response= client.PrimeNumberDecomposition(request);


            // while ( await response.ResponseStream.MoveNext())
            // {

            //     //var currentResponse = response.ResponseStream.Current;
            //     //Console.WriteLine(currentResponse.PrimeFactor);
            //     responsesLst.Add(response.ResponseStream.Current);
            // }
            // foreach (var item in responsesLst)
            // {
            //     Console.WriteLine(item.PrimeFactor);
            // } 
            #endregion

            // Impelement LongGreetService => Client Streaming 

            var client = new GreetingService.GreetingServiceClient(channel);


            List<LongGreetRequest> RequestsStream = new List<LongGreetRequest>()
            {
                new LongGreetRequest()
                {
                    Greeting= new Greeting()
                    {
                        FirstName="khaled",
                        LastName="Ibra"
                    }
                },
                new LongGreetRequest()
                {
                    Greeting= new Greeting()
                    {
                        FirstName="Mariam",
                        LastName="omar"
                    }
                },
                new LongGreetRequest()
                {
                    Greeting= new Greeting()
                    {
                        FirstName="omar",
                        LastName="Ibra"
                    }
                },
                new LongGreetRequest()
                {
                    Greeting= new Greeting()
                    {
                        FirstName="ahmed",
                        LastName="mohamed"
                    }
                },
                new LongGreetRequest()
                {
                    Greeting= new Greeting()
                    {
                        FirstName="leo",
                        LastName="messi"
                    }
                },
            };

            // Write On stream that mean does not take any parameter 
           var stream= client.LongGreet();

            foreach (var RequestStream in RequestsStream)
            {
                // Write one by one 
               await stream.RequestStream.WriteAsync(RequestStream);
            }

            // When client no more write on stream 
            await stream.RequestStream.CompleteAsync();


            var Response =await stream.ResponseAsync;

            Console.WriteLine(Response.Result);



            channel.ShutdownAsync().Wait();
            Console.ReadKey();




        }
    }
}