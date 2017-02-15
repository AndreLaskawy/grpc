using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Grpc.Core.Server server = new Grpc.Core.Server
            {
                Services = { Sample.Greeter.BindService(new SampleImpl()) },
                Ports = { new Grpc.Core.ServerPort("127.0.0.1", 54972, Grpc.Core.ServerCredentials.Insecure) }
            };
            server.Start();
            Console.ReadLine();
            server.ShutdownAsync().Wait();
        }
    }
}
