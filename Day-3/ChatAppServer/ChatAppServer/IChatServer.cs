using System.ServiceModel;

namespace ChatAppServer
{
    [ServiceContract(CallbackContract = typeof(IChatMessageReceiver))]
    public interface IChatServer
    {
        [OperationContract]
        void Login(string name);

        [OperationContract]
        void SendMessage(string message);

        [OperationContract]
        void Logout();
    }

    [ServiceContract]
    public interface IChatMessageReceiver
    {
        [OperationContract]
        void ReceiveMessage(string message);
    }
}