using System.ServiceModel;
using Biblioteka;
using Newtonsoft.Json;

namespace WcfServiceLibrary1
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            string dataSerialized = JsonConvert.SerializeObject(Hardware.HardwareData, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            return dataSerialized;
        }
    }

    public static class Hardware
    {
        public static HardwareInfo HardwareData { get; set; } = new HardwareInfo();
    }
}