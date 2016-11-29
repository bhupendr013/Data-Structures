using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    /*
     The proxy design pattern allows you to provide an interface to other objects by creating a wrapper 
     class as the proxy. The wrapper class, which is the proxy, can add additional functionality to the 
     object of interest without changing the object's code. 

    Below are some of the common examples in which the proxy pattern is used, 
    Adding security access to an existing object. The proxy will determine if the client can access the 
    object of interest. 
    Simplifying the API of complex objects. The proxy can provide a simple API so that the client 
    code does not have to deal with the complexity of the object of interest.
    Providing interface for remote resources, such as web service or REST resources. 
    Coordinating expensive operations on remote resources by asking the remote resources to start the 
    operation as soon as possible before accessing the resources. 
    Adding a thread-safe feature to an existing class without changing the existing class's code.
    In short, the proxy is the object that is being called by the client to access the real object behind 
    the scene. Proxy design pattern gets second rank in popularity in interviews.

    Guess who gets the first rank? None other than singleton design pattern. 

    Possible Usage Scenarios
    Remote Proxy – Represents an object locally which belongs to a different address space. 
    Think of an ATM implementation, it will hold proxy objects for bank information that exists in the remote server.
    Virtual Proxy – In place of a complex or heavy object, use a skeleton representation. When an underlying 
    image is huge in size, just represent it using a virtual proxy object and on demand load the real object. 
    You feel that the real object is expensive in terms of instantiation and so without the real need we are 
    not going to use the real object. Until the need arises we will use the virtual proxy. 
    Protection Proxy – Are you working on a MNC? If so, we might be well aware of the proxy server that 
    provides us internet by restricting access to some sort of websites like public e-mail, social networking, 
    data storage etc. The management feels that, it is better to block some content and provide only work related web 
    pages. Proxy server does that job. This is a type of proxy design pattern. 
     */
     //Subject
    interface ICar
    {
        void DriveCar();
    }

    // Real object

    public class Car : ICar
    {
        public void DriveCar()
        {
            Console.WriteLine("Car has been driven!");
        }

    } 

    // Proxy Object

    public class ProxyCar : ICar
    {
        private Driver _driver;
        private ICar _realCar;

        public ProxyCar(Driver driver)
        {
            this._driver = driver;
        }

        public void DriveCar()
        {
            if (_driver.Age <= 16)
                Console.WriteLine("Sorry, the driver is too young to drive.");
            else
                _realCar.DriveCar();
        }

    }
    public class Driver
    {
        private int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public Driver(int age)
        {
            _age = age;
        }
    }
    class ProxyPatterns
    {

        public void ControlProxy()
        {

        }
    }
}
