using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            ChainOfResponsiblity cor = new ChainOfResponsiblity();
            int[] req = { 1, 5, 23, 19, 21, 18 };
            cor.HandleRequestControl(req);

            DecoratorPattern dc = new DecoratorPattern();
            dc.PizzaMaker();

            FlyweightPattern fw = new FlyweightPattern();
            fw.ControlFlyweight();

            //ZFileSystem temp = new ZFileSystem();
            Console.ReadLine();
        }
    }
}
