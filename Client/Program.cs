﻿using Greet;
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


            //  Impelement GreetingManyTimes => Server Streaming


            var client = new GreetingService.GreetingServiceClient(channel);
            var request = new GreetingManytimesRequest()
            {
                Greeting = new Greeting()
                {
                    FirstName = "khaled",
                    LastName = "ibrahim"
                }
            };


            // Note Response of type stream 
            
          var response=  client.GreetManyTimes(request);

            while (await response.ResponseStream.MoveNext())
            {
                var CurrentResponse= response.ResponseStream.Current;
                Console.WriteLine(CurrentResponse.Result);
               await Task.Delay(1000);
            }
          




            channel.ShutdownAsync().Wait();
            Console.ReadKey();




        }
    }
}