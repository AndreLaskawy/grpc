using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Sample;

namespace Server
{
    class SampleImpl : Greeter.GreeterBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            var reply = new HelloReply();
            reply.Message = DateTime.UtcNow.ToString("o");
            return Task.FromResult(reply);
        }
    }
}
