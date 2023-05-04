using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace server
{
    internal class GreatingDeadLineServiceImpl : GreatDeadLineServive.GreatDeadLineServiveBase
    {
        public override async Task<GreatResponse> GreatDeadLine(GreatRequest request, ServerCallContext context)
        {
           // we will impelement the server to return response after 3000m

            await Task.Delay(300);
            return new GreatResponse() { Result = "Ok " + request.Number };

        }


    }
}
