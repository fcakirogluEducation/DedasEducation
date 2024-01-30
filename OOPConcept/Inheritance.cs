using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConcept.Inheritance
{
    public class CarRun
    {
        public CarRun()
        {
            //var base1 = new Base();


            var car = new Car();

            var topla = car.Calculate(2, 2);
            var person = new Person();

            person.Calculate(5, 2);
        }
    }

    // private/ public/ internal / protected
    public abstract class Base
    {
        private protected string barcode = "abc";
        protected int Id { get; set; }

        public virtual int Calculate(int a, int b)
        {
            return a + b;
        }
    }

    public class Car : Base
    {
        public Car()
        {
        }

        public string Model { get; set; }
    }

    public class Person : Base
    {
        public Person()
        {
        }

        public override int Calculate(int a, int b)
        {
            return a - b;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}