using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public abstract class EmployeePrototype
    {
        public abstract EmployeePrototype Clone(bool isDeepClone);
    }

    public class Employee : EmployeePrototype
    {
        private string _firstName;
        private string _lastName;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public Employee(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public override EmployeePrototype Clone(bool isDeepClone)
        {
            if (isDeepClone)
                return new Employee(_firstName, _lastName);
            return MemberwiseClone() as Employee;
        }
    }

    class PrototypePattern
    {
    }
}
