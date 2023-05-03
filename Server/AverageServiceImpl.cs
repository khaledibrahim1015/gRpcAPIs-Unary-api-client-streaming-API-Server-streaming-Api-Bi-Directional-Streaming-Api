using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    public class AverageServiceImpl : AverageService.AverageServiceBase
    {
        public override async Task<AverageResponse> ComputeAverage(IAsyncStreamReader<AverageRequest> requestStream, 
            ServerCallContext context)
        {
            int total = 0;
            double result = 0.0;

            // Read One by one 

            while (await requestStream.MoveNext())
            {
              var CurrentRequest=  requestStream.Current;

                result += CurrentRequest.Number;
                total++;
            }


            return new AverageResponse()
            {
                Result = result / total
            };




        }


    }
}
