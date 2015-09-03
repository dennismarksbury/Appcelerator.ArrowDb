namespace OpenSource.Appcelerator.ArrowDb.Models
{
    public class PushNotificationPayload
    {
        public string Channel { get; set; }

        public string[] DeviceTokens { get; set; }

        public string Title { get; set; }
        
        public string Message { get; set; }
        
        public string Icon { get; set; }
        
        public int Badge { get; set; }

        public bool Vibrate { get; set; }
    }
}
