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

            #region Impelement LongGreetService => Client Streaming 
            // Impelement LongGreetService => Client Streaming 



            // var client = new GreetingService.GreetingServiceClient(channel);


            // List<LongGreetRequest> RequestsStream = new List<LongGreetRequest>()
            // {
            //     new LongGreetRequest()
            //     {
            //         Greeting= new Greeting()
            //         {
            //             FirstName="khaled",
            //             LastName="Ibra"
            //         }
            //     },
            //     new LongGreetRequest()
            //     {
            //         Greeting= new Greeting()
            //         {
            //             FirstName="Mariam",
            //             LastName="omar"
            //         }
            //     },
            //     new LongGreetRequest()
            //     {
            //         Greeting= new Greeting()
            //         {
            //             FirstName="omar",
            //             LastName="Ibra"
            //         }
            //     },
            //     new LongGreetRequest()
            //     {
            //         Greeting= new Greeting()
            //         {
            //             FirstName="ahmed",
            //             LastName="mohamed"
            //         }
            //     },
            //     new LongGreetRequest()
            //     {
            //         Greeting= new Greeting()
            //         {
            //             FirstName="leo",
            //             LastName="messi"
            //         }
            //     },
            // };

            // // Write On stream that mean does not take any parameter 
            //var stream= client.LongGreet();

            // foreach (var RequestStream in RequestsStream)
            // {
            //     // Write one by one 
            //    await stream.RequestStream.WriteAsync(RequestStream);
            // }

            // // When client no more write on stream 
            // await stream.RequestStream.CompleteAsync();


            // var Response =await stream.ResponseAsync;

            // Console.WriteLine(Response.Result); 
            #endregion

            #region Impelement ComputeAverage Service => Client Streaming 

            // var client = new AverageService.AverageServiceClient(channel);

            // // Then Open stream 
            //var stream  = client.ComputeAverage();

            // // request Stream to Write On it One By one 
            // // Once Stream of Requests end Completed 
            // //  client Recive Response From Server 

            // AverageRequest[] NumbersOFAverageRequests = new AverageRequest[]
            // {
            //     new AverageRequest{Number=1},
            //     new AverageRequest{Number=2},
            //      new AverageRequest{Number=3},
            //     new AverageRequest{Number=4}
            // };

            // foreach (var NumberOFAverageRequest in NumbersOFAverageRequests)
            // {
            //     // Write On Stream 
            //     await stream.RequestStream.WriteAsync(NumberOFAverageRequest);
            // }

            // await stream.RequestStream.CompleteAsync();

            // var Response = stream.ResponseAsync;

            // Console.WriteLine(Response.Result); 
            #endregion

            #region Impelement GreetEveryOneService => Bi Directional Streaming

            //var client = new GreetingService.GreetingServiceClient(channel);


            ////  Open stream
            //var stream = client.GreetEveryOne();


            ////Server streaming 
            //// Get Response Later When Client send all requests to Server 
            //// Read From Stream response by response 
            //var responseReader = Task.Run(async () =>
            //{
            //    while (await stream.ResponseStream.MoveNext())
            //    {
            //        var currentResponse = stream.ResponseStream.Current;
            //        Console.WriteLine("Recived Response : " + currentResponse.Result);
            //    }

            //});


            //// client streaming 
            //List<GreetEveryOneRequest> greetEveryOneRequests = new List<GreetEveryOneRequest>()
            //{
            //    new GreetEveryOneRequest()
            //    {
            //        Greeting= new Greeting()
            //        {
            //            FirstName="khaled",
            //            LastName="ibra"
            //        }
            //    },
            //    new GreetEveryOneRequest()
            //    {
            //        Greeting= new Greeting()
            //        {
            //            FirstName="khaled",
            //            LastName="ibra"
            //        }
            //    },
            //     new GreetEveryOneRequest()
            //    {
            //         Greeting= new Greeting()
            //         {
            //             FirstName="khaled",
            //             LastName="ibra"
            //          }
            //     },
            //         new GreetEveryOneRequest()
            //                        {
            //        Greeting= new Greeting()
            //        {
            //            FirstName="khaled",
            //            LastName="ibra"
            //        }
            //    },

            //};



            //// request stream => write on it one by one 
            //foreach (var greetEveryOneRequest in greetEveryOneRequests)
            //{
            //    Console.WriteLine("Sending Request : "+ greetEveryOneRequest.ToString());
            //  await  stream.RequestStream.WriteAsync(greetEveryOneRequest);


            //}

            //// End Stream of request 
            //await stream.RequestStream.CompleteAsync();

            //// Call Thread to Get stream Response 
            //await responseReader; 
            #endregion

            #region Impelement FindMaxServic => Bi Directional Streaming
            //  var client = new FindMaxService.FindMaxServiceClient(channel);

            //  // Open stream 
            //var stream =  client.FindMaximum();

            //  // Server Streaming 
            //  var ResponseReader = Task.Run(async () =>
            //  {
            //      // Read one by one from stream 
            //      while (await stream.ResponseStream.MoveNext())
            //      {
            //          var currentResponse = stream.ResponseStream.Current;
            //          Console.WriteLine($"Recived Response {currentResponse.Max}");
            //      }

            //  });

            //  // Client Streaming 


            //  FindMaxRequest[] findMaxRequests = new FindMaxRequest[]
            //  {
            //      new FindMaxRequest{Number=1},
            //      new FindMaxRequest{Number=5},
            //      new FindMaxRequest{Number=3},
            //      new FindMaxRequest{Number=6},
            //      new FindMaxRequest{Number=2},
            //      new FindMaxRequest{Number=20},
            //  };
            //  // Write Requests one by one on stream 
            //  foreach (var findMaxRequest in findMaxRequests)
            //  {
            //    await  stream.RequestStream.WriteAsync(findMaxRequest);
            //  }
            //  //Once Reuests Stream End 
            // await stream.RequestStream.CompleteAsync();

            //  // Call thread Responses stream 
            //  await ResponseReader; 
            #endregion





            // Error Handling 
            #region SqrtService => UnaryAPI
            ////SqrtService => UnaryAPI
            //int number = -1;
            //DoSqrtServicUnaryApi(channel,number); 
            #endregion





















            channel.ShutdownAsync().Wait();
            Console.ReadKey();




        }
        /// Error handling 
        /// 
        public static void DoSqrtServicUnaryApi( Channel channel,int number)
        {
            var client = new SqrtService.SqrtServiceClient(channel);
            try
            {
                var response = client.Sqrt(new SqrtRequest() { Number = number });
                Console.WriteLine("The sqr :" + response.SquareRoot);

            }
            catch (RpcException e)
            {

                Console.WriteLine("Error " + e.Status.Detail);
            }
          
        }








    }
}