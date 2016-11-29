using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public interface IPizza
    {
        string GetDescription();

        double GetPrice();
    }

    public class PlainPizza : IPizza
    {
        public PlainPizza()
        {
            Console.WriteLine("Adding Plain pizza");
        }
        public String GetDescription()
        {
            return "Thin Dough";
        }

        public double GetPrice()
        {
            Console.WriteLine("Cost of Dough:" + 4.00);
            return 4.00;
        }
    }

    public class ThreeCheezePizza : IPizza
    {
        private String description = "Mozzarella, Fontina, Parmesan Cheese Pizza";
        private double cost = 10.50;
        public string GetDescription()
        {
            return description;
        }

        public void SetPrice(int newPrice)
        {
            cost = newPrice;
        }
        public double GetPrice()
        {
            return cost;
        }

    }

    public abstract class ToppingDecorator : IPizza
    {
        protected IPizza tempPizza;

        public ToppingDecorator(IPizza newPizza)
        {
            tempPizza = newPizza;
        }

        public string GetDescription()
        {
            return tempPizza.GetDescription();
        }

        public double GetPrice()
        {
            return tempPizza.GetPrice();
        }
    }

    public class Mozzarella : ToppingDecorator
    {
        public Mozzarella(IPizza newPizza) : base(newPizza)
        {
            Console.WriteLine("Adding Dough");
            Console.WriteLine("Adding Moz");


        }

        public string GetDescription()
        {
            return tempPizza.GetDescription() + ", mozzarella";
        }

        public double GetPrice()
        {
            Console.WriteLine("Cost of Moz:" + 0.50);
            return tempPizza.GetPrice() + 0.50;
        }
    }

    public class TomatoSauce : ToppingDecorator
    {
        public TomatoSauce(IPizza newPizza) : base(newPizza)
        {
            Console.WriteLine("Adding Sauce:");
        }

        public string GetDescription()
        {
            return tempPizza.GetDescription() + ", tomato sauce";
            
        }

        public double GetPrice()
        {
            Console.WriteLine("Cost of Sauce: " + .35);
            return tempPizza.GetPrice() + 0.35;
        }
    }
    class DecoratorPattern
    {
        public void PizzaMaker()
        {
            IPizza basicPizza = new TomatoSauce(new Mozzarella(new PlainPizza()));
            Console.WriteLine("Ingredients:" + basicPizza.GetDescription());
            Console.WriteLine("Price:" + basicPizza.GetPrice());

        }
    }
}
