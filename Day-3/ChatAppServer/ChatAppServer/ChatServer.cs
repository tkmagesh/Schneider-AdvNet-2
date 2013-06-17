using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace ChatAppServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ChatServer : IChatServer
    {
        private IDictionary<IChatMessageReceiver, string> clientReferences 
            = new Dictionary<IChatMessageReceiver, string>();
        
        public void Login(string name)
        {
            var callbackReference = OperationContext.Current.GetCallbackChannel<IChatMessageReceiver>();
            clientReferences.Add(callbackReference,name);
            Console.WriteLine("{0} just logged in", name);
        }

        [OperationBehavior]
        public void SendMessage(string message)
        {
            var currentCallback = OperationContext.Current.GetCallbackChannel<IChatMessageReceiver>();
            foreach (var clientReference in clientReferences)
            {
                if (clientReference.Key != currentCallback)
                    clientReference.Key.ReceiveMessage(string.Format("{0} : {1}", 
                        clientReferences[currentCallback], message));
            }
        }

        [OperationBehavior]
        public void Logout()
        {
            clientReferences.Remove(OperationContext.Current.GetCallbackChannel<IChatMessageReceiver>());
        }
    }
}