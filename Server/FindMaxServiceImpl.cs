using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    public class FindMaxServiceImpl : FindMaxService.FindMaxServiceBase
    {
        public override async Task FindMaximum(IAsyncStreamReader<FindMaxRequest> requestStream,
            IServerStreamWriter<FindMaxResponse> responseStream,
            ServerCallContext context)
        {

            // Client streaming 
            // Read from stream one by one 
            int? max = null;
            while (await requestStream.MoveNext())
            {

                var currentRequest = requestStream.Current;
                if (max == null || max < currentRequest.Number)
                {

                    // Write on stream 
                    max = currentRequest.Number;
                    await responseStream.WriteAsync(new FindMaxResponse() { Max = max.Value });


                };


            }






        }


    }
}
