using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch.Domain.Entities
{
    public class Person
    {
        private readonly string? name;
        private DateTime? dateTime;

        public Person(string name, DateTime dateTime)
        {
            this.name = name;
            this.dateTime = dateTime;
        }
    }
}
