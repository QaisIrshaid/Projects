using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace ObjectPooling
{
    public delegate object factory();

    class program
    {
        public static void Main(String[] args)
        {

            ObjectPool<Car> pool = new ObjectPool<Car>(3, 5, Car.create);
            Car car1 = pool.get(Car.create);
            Car car2 = pool.get(Car.create);
            Car car3 = pool.get(Car.create);
            Car car4 = pool.get(Car.create);
            Car car5 = pool.get(Car.create);
            pool.put(car4);
            Car car6 = pool.get(Car.create);

        }

    }

}
