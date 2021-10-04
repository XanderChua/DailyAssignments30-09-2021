using System;
using System.Collections.Generic;
using System.Threading;
//Suppose you are working in an MNC.  after your joining there will be a probation period of 6 months, in this period you are drawing only 80% of your monthly salary.
//after that you will get the full salary. Every month from your salary you have 
//1. 12 % tax
//2. 8 % to provident fund after paying the tax    
//3. 5% to health insurance after paying PF              
//4. 7% to Mutual Funds after paying Health insurance. 
//* Now calculate the total amount of money you will get after all these investments in a year. use exception handling to show the error msg. and create  generic class to store the data

namespace GenericExceptionTax
{
    public class Salary
    {
        public double SalaryAmount { get; set; }
        public Salary(double SalaryAmount)
        {
            this.SalaryAmount = SalaryAmount;
        }
    }
    public class SalaryCollection<Tsalary>
    {
        private IList<Tsalary> _salary;
        public IList<Tsalary> SalaryObj
        {
            get
            {
                if(_salary == null)
                {
                    _salary = new List<Tsalary>();
                }
                return _salary;
            }
            set
            {
                _salary = value;
            }
        }
        public void addSalary(Tsalary salary)
        {
            SalaryObj.Add(salary);
        }
    }
    class ThreadClass
    {
        public void CallThread()
        {
            Thread t = new Thread(Display);
            t.Start();
        }
        public void Display()
        {
            SalaryCollection<Salary> listSalary = new SalaryCollection<Salary>();
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("--Generic Exception Tax--");
                Console.WriteLine("1. Input Salary");
                Console.WriteLine("2. List All Salary");
                Console.WriteLine("3. Exit");
                int input = Int32.Parse(Console.ReadLine());
                try
                {
                    if (input == 1)
                    {
                        Console.WriteLine("Enter salary drawn:");
                        double salaryDrawn = Double.Parse(Console.ReadLine());
                        double probationSixMonths = ProbationSalaryMonthly(salaryDrawn) * 6;
                        double sixMonths = SalaryMonthly(salaryDrawn) * 6;
                        listSalary.addSalary(new Salary(probationSixMonths + sixMonths));
                        Console.WriteLine("Salary added to list.\n");
                    }
                    else if (input == 2)
                    {
                        foreach (var salary in listSalary.SalaryObj)
                        {
                            Console.WriteLine("Your yearly take home salary is: " + salary.SalaryAmount);
                        }
                    }
                    else if (input == 3)
                    {
                        loop = false;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input!!!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("General Exception: " + ex.Message);
                }
            }
        }
        static double ProbationSalaryMonthly(double psal)
        {
            double probationSalary = psal * 0.8;
            double afterTax = probationSalary * 0.88;
            double afterProvidentFund = afterTax * 0.92;
            double afterHealthInsurance = afterProvidentFund * 0.95;
            double afterMutualFunds = afterHealthInsurance * 0.93;
            return afterMutualFunds;
        }
        static double SalaryMonthly(double sal)
        {
            double afterTax = sal * 0.88;
            double afterProvidentFund = afterTax * 0.92;
            double afterHealthInsurance = afterProvidentFund * 0.95;
            double afterMutualFunds = afterHealthInsurance * 0.93;
            return afterMutualFunds;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ThreadClass t = new ThreadClass();
            t.CallThread();
        } 
    }
}
