using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public interface IHousePlan
    {
        void BuildBasement(string basement);
        void BuildWalls(string walls);
        void BuildRoof(string roof);
        void BuildInterior(string interior);
    }

    public class House : IHousePlan
    {
        public void BuildBasement(string basement)
        {
            Console.WriteLine("Basement constructed with " + basement);
        }

        public void BuildWalls(string walls)
        {
            Console.WriteLine("Walls constructed with " + walls);
        }

        public void BuildRoof(string roof)
        {
            Console.WriteLine("Roof constructed with " + roof);
        }

        public void BuildInterior(string interior)
        {
            Console.WriteLine("Interior constructed with " + interior);
        }
    }

    public interface IHouseBuilder
    {
        void BuildBasement();
        void BuildWalls();
        void BulidRoof();
        void BuildInterior();
        House GetHouse();

    }

    public class WoodenHouseBuilder : IHouseBuilder
    {
        private House _house;

        public WoodenHouseBuilder()
        {
            _house = new House();
        }

        public void BuildBasement()
        {
            _house.BuildBasement("Wooden Poles.");
        }

        public void BuildWalls()
        {
            _house.BuildWalls("Wood and Poles");
        }

        public void BulidRoof()
        {
            _house.BuildRoof("Wood and Seal skins");
        }

        public void BuildInterior()
        {
            _house.BuildInterior("Fire wood and Teak");
        }

        public House GetHouse()
        {
            return _house;
        }
    }

    public class VillaHouseBuilder : IHouseBuilder
    {
        private House _house;
        public VillaHouseBuilder()
        {
            _house = new House();
        }

        public void BuildBasement()
        {
            _house.BuildBasement("Concrete, Iron.");
        }

        public void BuildWalls()
        {
            _house.BuildWalls("Bricks");
        }

        public void BulidRoof()
        {
            _house.BuildRoof("Concrete, Iron");
        }

        public void BuildInterior()
        {
            _house.BuildInterior("Teak, Plywood etc.");
        }

        public House GetHouse()
        {
            return _house;
        }
    }

    public class CivilEngineer
    {
        private IHouseBuilder _housebuilder;

        public CivilEngineer(IHouseBuilder houseBuilder)
        {
            _housebuilder = houseBuilder;
        }

        public House GetHouse()
        {
            ConstructHouse();
            return _housebuilder.GetHouse();
        }

        private void ConstructHouse()
        {
            _housebuilder.BuildBasement();
            _housebuilder.BuildWalls();
            _housebuilder.BulidRoof();
            _housebuilder.BuildInterior();
        }
    }

    class BuilderPattern
    {
        public void ControlBuilder()
        {
            IHouseBuilder woodenHouseBuilder = new WoodenHouseBuilder();
            CivilEngineer engineer = new CivilEngineer(woodenHouseBuilder);
            House house = engineer.GetHouse();
        }
    }
}
