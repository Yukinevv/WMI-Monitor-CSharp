using System.ServiceModel;

namespace WcfServiceLibrary1
{
    [ServiceContract]
    public interface IMessageService
    {
        [OperationContract]
        string GetMessage();
    }
}
