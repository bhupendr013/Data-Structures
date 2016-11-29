using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    /*
     An adapter helps two incompatible interfaces to work together. This is the real world definition for an adapter. 
     Adapter design pattern is used when you want two different classes with incompatible interfaces to work together. 
     The name says it all. Interfaces may be incompatible but the inner functionality should suit the need.
                 In real world the easy and simple example that comes to mind for an adapter is the travel power adapter. 
                 American socket and plug are different from India. Those interfaces are not compatible with one another. 
                 India plugs are cylindrical and American plugs are rectangular. We can use an adapter in between to fit 
                 an American (rectangular) plug in India (cylindrical) socket assuming voltage requirements are met with.

    How to implement adapter design pattern?
    Adapter design pattern can be implemented in two ways. One using the inheritance method and second using the 
    composition method. Just the implementation methodology is different but the purpose and solution is same.

    UML Class Diagram?



    Adapter implementation using inheritance
    When a class with incompatible method needs to be used with another class, we can use inheritance to create an 
    adapter class. The adapter class which is inherited will have new compatible methods. Using those new methods from 
    the adapter, the core function of the base class will be accessed. This is called “is-a” relationship. The same real 
    world example is implemented in C#.Net as below.
     */

    public class CylindricalSocket
    {
        public string GetSupply(string cylindWire1, string cylindWire2)
        {
            return "Connected! Power supply is ON.";
        }
    }

    public class RectangularAdapter
    {
        private CylindricalSocket _socket;
        public RectangularAdapter()
        {
            _socket = new CylindricalSocket();
        }

        public string GetPowerSupply(string rectWire1, string rectWire2)
        {
            return _socket.GetSupply(rectWire1, rectWire2);
        }
    }

    public class RectangularPlug
    {
        private string _rectWire1;
        private string _rectWire2;

        public RectangularPlug(string rectWire1, string rectWire2)
        {
            _rectWire1 = rectWire1;
            _rectWire2 = rectWire2;
        }

        public string GetPowerSupply()
        {
            RectangularAdapter rectAdapter = new RectangularAdapter();
            return rectAdapter.GetPowerSupply(_rectWire1, _rectWire2);
        }
    }
    class AdapterPattern
    {
    }
}
