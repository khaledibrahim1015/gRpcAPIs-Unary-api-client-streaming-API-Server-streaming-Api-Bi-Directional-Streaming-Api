using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    public class CalaculatorServiceImplementation: CalclatorServive.CalclatorServiveBase
    {
        public override Task<CalclatorResponse> Sum(CalclatorRequest request, ServerCallContext context)
        {
            // Compute the sum of the two numbers
            int sum = request.Calculator.Number1 + request.Calculator.Number2;

            // Create a formatted response string
            string responseString = string.Format("The sum of {0} + {1} = {2}", request.Calculator.Number1, request.Calculator.Number2, sum);

            // Create a new CalculatorResponse message with the response string
            CalclatorResponse response = new CalclatorResponse
            {
                Result = responseString
            };

            // Return the response message in a Task
            return Task.FromResult(response);
        }

    }
}
