using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    public class PrimeNumberServiceImpl : PrimeNumberService.PrimeNumberServiceBase
    {

        public override async Task PrimeNumberDecomposition(PrimeNumberDecompositionRequest request,
            IServerStreamWriter<PrimeNumberDecompositionResponse> responseStream, 
            ServerCallContext context)
        {
            Console.WriteLine($"The Server Recived The Request {request.ToString()}");


            int number = request.Number;

            int divisor = 2;

            while (number>1)
            {
                if (number%divisor==0)
                {

                    number = number / divisor;
                    await responseStream.WriteAsync(new PrimeNumberDecompositionResponse { PrimeFactor = divisor });

                }
                divisor++;


            }





        }
    }
}
