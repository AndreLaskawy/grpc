using Android.App;
using Android.Widget;
using Android.OS;
using Sample;
using Grpc.Core;

namespace App2
{
    [Activity(Label = "App2", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Channel channel;
        Greeter.GreeterClient client;
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            TextView text = FindViewById<TextView>(Resource.Id.textView1);

            button.Click += delegate
            {
                var request = new HelloRequest();
                request.Name = "Android";
                HelloReply reply = client.SayHello(request);
                text.Text = reply.Message;
            };
        }

        protected override void OnStart()
        {
            base.OnStart();
            channel = new Channel("127.0.0.1:54972", ChannelCredentials.Insecure);

            client = new Greeter.GreeterClient(channel);
        }

        protected override void OnStop()
        {
            base.OnStop();
            channel.ShutdownAsync().Wait();
        }
    }
}

