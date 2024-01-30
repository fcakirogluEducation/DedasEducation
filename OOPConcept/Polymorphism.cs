using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConcept.Polymorphism
{
    public class Phone
    {
        public int Id { get; set; }
        public string Model { get; set; }

        public string Write()
        {
            return $"{Id}- {Model}";
        }

        public override string ToString()
        {
            return $"{Id}- {Model}";
        }
    }
}