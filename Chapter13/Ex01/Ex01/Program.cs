using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Ex01
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Timer t = new Timer(100);
            t.Elapsed += T_Elapsed;
            t.Start();
            System.Threading.Thread.Sleep(400);
            t.Stop();
            Program p = new Program();
            p.CallMessage();
            Console.ReadKey();
        }
        #region My practice.
        public static event EventHandler<MessageArriveEventArgs> MessageArrived;
        private static void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine(e.GetType().ToString());
            Console.WriteLine(sender.ToString());
            Console.WriteLine(e.SignalTime);
        }
        public void CallMessage()
        {
            MessageArrived += MessageArriveFunc;
            for (int i = 0; i < 3; ++i)
                MessageArrived(this, new MessageArriveEventArgs("this message~"));
        }
        private void MessageArriveFunc(object sender, MessageArriveEventArgs e)
        {
            Console.WriteLine(e.GetType().ToString());
            Console.WriteLine(sender.ToString());
            Console.WriteLine(e.Message);
        }
        #endregion
        #region The Answer
        //public void ProcessEvend(object source, EventArgs e)
        //{
        //    if(e is MessageArriveEventArgs)
        //    {
        //        Console.WriteLine("Connection.MessageArrived event received.");
        //        Console.WriteLine($"Message: {(e as MessageArriveEventArgs).Message}");
        //    }
        //    if(e is ElapsedEventArgs )
        //    {
        //        Console.WriteLine("Timer.Elapsed event received.");
        //        Console.WriteLine($"SignalTime: {(e as ElapsedEventArgs).SignalTime}");
        //    }
        //}
        #endregion
    }
}
