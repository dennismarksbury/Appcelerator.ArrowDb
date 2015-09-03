namespace OpenSource.Appcelerator.ArrowDb.TestConsole
{
    using System;

    using OpenSource.Appcelerator.ArrowDb.Models;
    using OpenSource.Appcelerator.ArrowDb.Services;

    class Program
    {
        static void Main(string[] args)
        {
            
            var payload = new PushNotificationPayload()
                              {
                                  Badge = 0, 
                                  Channel = "alerts", 
                                  DeviceTokens = new [] { "{Device_Token}" },
                                  Icon = "appicon",
                                  Title = "Test",
                                  Message = "Hello World.",
                                  Vibrate = true
                              };

            var notifyService = new PushNotificationService("{API_KEY");
            notifyService.SendPush(payload);
            
            Console.ReadKey();
        }
    }
}
