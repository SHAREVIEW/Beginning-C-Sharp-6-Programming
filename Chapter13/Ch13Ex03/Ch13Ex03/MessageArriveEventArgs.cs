using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch13Ex03
{
    public class MessageArriveEventArgs : EventArgs
    {
        private string message;
        public string Message
        {
            get { return message; }
        }
        public MessageArriveEventArgs()
        {
            message = "No message sent.";
        }
        public MessageArriveEventArgs(string newMessage)
        {
            message = newMessage;
        }
    }
}
