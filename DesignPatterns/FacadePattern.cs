using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Bank
    {
        public bool HasSufficientSavings(Customer c, int amount)
        {
            Console.WriteLine("Check bank for " + c.Name);
            return true;
        }
    }

    class Credit
    {
        public bool HasGoodCredit(Customer c)
        {
            Console.WriteLine("Check credit for " + c.Name);
            return true;
        }
    }

    class Loan
    {
        public bool HasNoBadLoans(Customer c)
        {
            Console.WriteLine("Check loans for " + c.Name);
            return true;
        }
    }

    public class Customer
    {
        private string _name;

        public Customer(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }
    }

    public class Mortgage
    {
        private Bank _bank;
        private Credit _credit;
        private Loan _loan;

        public Mortgage()
        {
            _bank = new Bank();
            _credit = new Credit();
            _loan = new Loan();
        }

        public bool IsEligible(Customer cust, int amount)
        {
            Console.WriteLine("{0} applies for {1:C} loan\n",
                cust.Name, amount);
            bool elegible = true;

            if(!_bank.HasSufficientSavings(cust, amount))
            {
                elegible = false;
            }else if (_loan.HasNoBadLoans(cust))
            {
                elegible = false;
            }else if (!_credit.HasGoodCredit(cust))
            {
                elegible = false;
            }
            return elegible;
        }
    }
    class FacadePattern
    {
        public void FacadeControl()
        {
            Mortgage mortgage = new Mortgage();

            // Evaluate mortgage eligibility for customer
            Customer customer = new Customer("Ann McKinsey");
            bool eligible = mortgage.IsEligible(customer, 125000);

            Console.WriteLine("\n" + customer.Name +
                " has been " + (eligible ? "Approved" : "Rejected"));
        }
    }
}
