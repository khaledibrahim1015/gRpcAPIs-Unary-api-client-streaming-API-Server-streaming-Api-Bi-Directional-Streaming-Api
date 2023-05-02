using Greet;
using Grpc.Core;
using System;
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


    }
}
