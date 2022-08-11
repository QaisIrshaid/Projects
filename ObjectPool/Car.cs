using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPooling
{
    public class Car
    {
        public string name { get; set; }
        public int year { get; set; }
        public string color { get; set; }

        public static Car create()
        {
            return new Car();
        }
    }
}
