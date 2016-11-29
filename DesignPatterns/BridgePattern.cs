using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public interface ITV
    {
        void PowerOff();

        void PowerOn();

        void ChangeChannel(int channel);
    }

    public class Google : ITV
    {
        public void PowerOff()
        {
            /// Power off specific code
        }

        public void PowerOn()
        {
            // Power on specific code
        }

        public void ChangeChannel(int channel)
        {
            // Change channel specific code
        }
    }

    public class Apple : ITV
    {
        public void PowerOff()
        {
            /// Power off specific code
        }

        public void PowerOn()
        {
            // Power on specific code
        }

        public void ChangeChannel(int channel)
        {
            // Change channel specific code
        }
    }

    public abstract class TVRemoteControl
    {
        private ITV implementor;

        public void PowerOn()
        {
            implementor.PowerOn();
        }

        public void PowerOff()
        {
            implementor.PowerOff();
        }

        public void SetChannel(int channel)
        {
            implementor.ChangeChannel(channel);
        }
    }

    public class ConcreteTVRemoteControl : TVRemoteControl
    {
        private int currentChannel;
        public void NextChannel()
        {
            currentChannel++;
            SetChannel(currentChannel);
        }

        public void PrevChannel()
        {
            currentChannel--;
            SetChannel(currentChannel);
        }
    }
    class BridgePattern
    {
    }
}
