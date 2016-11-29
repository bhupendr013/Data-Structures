using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public abstract class Handler
    {
        protected Handler successor;

        public void SetSuccessor(Handler successor)
        {
            this.successor = successor;
        }

        public abstract void HandleRequest(int request);
    }

    public class ConcreteHandler1 : Handler
    {
        public override void HandleRequest(int req)
        {
            if(req >= 0 && req < 10)
            {
                Console.WriteLine("Handler 1 is handling request");
            }
            else if(successor != null)
            {
                successor.HandleRequest(req);
            }
        }
    }

    public class ConcreteHandler2 : Handler
    {
        public override void HandleRequest(int req)
        {
            if(req >= 10 && req < 20)
            {
                Console.WriteLine("Handler 2 handling request");
            }
            else if(successor != null)
            {
                successor.HandleRequest(req);
            }
        }
    }

    public class ConcreteHandler3 : Handler
    {
        public override void HandleRequest(int req)
        {
            if (req >= 20 && req < 30)
            {
                Console.WriteLine("Handler 3 handling request");
            }
            else if(successor != null)
            {
                successor.HandleRequest(req);
            }
        }
    }

    public class ChainOfResponsiblity
    {
        public void HandleRequestControl(int[] req)
        {
            Handler hand1 = new ConcreteHandler1();
            Handler hand2 = new ConcreteHandler2();
            Handler hand3 = new ConcreteHandler2();
            hand1.SetSuccessor(hand2);
            hand2.SetSuccessor(hand3);
            foreach(var item in req)
            {
                hand1.HandleRequest(item);
            }
        }        
        
    }
}
