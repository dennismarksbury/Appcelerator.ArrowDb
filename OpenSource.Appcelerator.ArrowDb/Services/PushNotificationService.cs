namespace OpenSource.Appcelerator.ArrowDb.Services
{
    using System;
    using System.Diagnostics;

    using OpenSource.Appcelerator.ArrowDb.Models;

    using RestSharp;

    public class PushNotificationService
    {
        private readonly string appKey;

        public PushNotificationService(string appKey)
        {
            this.appKey = appKey;
        }

        public void SendPush(PushNotificationPayload payload)
        {
            try
            {
                var client = new RestClient("https://api.cloud.appcelerator.com")
                                 {
                                     CookieContainer = new System.Net.CookieContainer()
                                 };
                var request = new RestRequest("/v1/push_notification/notify_tokens.json?key=" + appKey, Method.POST)
                                  {
                                      RequestFormat = DataFormat.Json,
                                      Method = Method.POST
                                  };

                request.AddParameter("channel", payload.Channel);
                request.AddParameter("to_tokens", string.Join(",", payload.DeviceTokens));
                request.AddParameter("payload", "{ 'alert': '" + payload.Message + "', 'icon': '" + payload.Icon + "', 'badge': " + payload.Badge + ", 'title': '" + payload.Title + "', 'vibrate': " + payload.Vibrate.ToString().ToLower() + " }");
                var response = client.Execute(request);
                var error = response.ErrorMessage;
                var content = response.Content;
                Console.WriteLine(content);
                Console.WriteLine("");
                Console.WriteLine(error);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Message " + ex.Message + " \n Inner Exception " + ex.InnerException + " \n Stack Trace" + ex.StackTrace);
            }
        }
    }
}
