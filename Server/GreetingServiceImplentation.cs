using Greet;
using Grpc.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{

    public  class GreetingServiceImplentation: GreetingService.GreetingServiceBase
    {
        
        public override Task<GreetingResponse> Greet(GreetingRequest request, ServerCallContext context)
        {


            return Task.FromResult(new GreetingResponse()
            {
                Result = string.Format($"Hello {request.Greeting.FirstName} {request.Greeting.LastName} ")
            });

        }

        // Implement server streaming 

        /// <param name="request">The request received from the client.</param>
        /// <param name="responseStream">Used for sending responses back to the client.</param>
        /// responses act as list<GreetingManyTimesResponse> 
        /// response one GreetingManyTimesResponse One by one 
        public override async Task GreetManyTimes(GreetingManytimesRequest request,
            IServerStreamWriter<GreetingManyTimesResponse> responseStream,
            ServerCallContext context)
        {
            // 1 -way 

            List<GreetingManyTimesResponse> greetingManyTimesResponses = new List<GreetingManyTimesResponse>()
            {
                new GreetingManyTimesResponse()
                {
                    Result=string.Format($"{request.Greeting.FirstName} {request.Greeting.LastName}")
                },
                 new GreetingManyTimesResponse()
                {
                    Result=string.Format($"{request.Greeting.FirstName} {request.Greeting.LastName}")
                }

            };

            // Sending responses but one by one 

            foreach (var response in greetingManyTimesResponses)
            {
                await responseStream.WriteAsync(response);
            }

            //// another way 
            //Console.WriteLine($"The server recived one Request {request.Greeting.FirstName} , {request.Greeting.LastName}");


            //foreach (var i in Enumerable.Range(0,10))
            //{
            //    await responseStream.WriteAsync(new GreetingManyTimesResponse() { Result = string.Format($"{i} hello  {request.Greeting.FirstName} {request.Greeting.LastName}") });
            //}




        }

        // act as server recived list of <LongGreetRequest>
        // Read one by one the same happened in the client side 


        public override async Task<LongGreetResponse> LongGreet(IAsyncStreamReader<LongGreetRequest> requestStream, 
            ServerCallContext context)
        {
            // The server will only response to the client once the client is done sending requests 
            // but in theory the server can response whenever it wants
            string result = "";
            while (await requestStream.MoveNext())
            {
               var currentRequest=  requestStream.Current;
                result += string.Format($"Hello {currentRequest.Greeting.FirstName} {currentRequest.Greeting.LastName}", Environment.NewLine);

            }


            return new LongGreetResponse()
            {
                Result = result
            };


        }


    }
}
