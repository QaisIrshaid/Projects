using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPooling
{
    internal class ObjectPool<T>
    {
        private int max;
        private int initial;
        private int counter;
        private readonly Queue<T> objectQueue;

        public ObjectPool(int initial, int max, Func<T> factory)
        {

            this.initial = initial;
            this.max = max;
            counter = 0;
            objectQueue = new Queue<T>(max);

            for (int i = 0; i < initial; i++)
            {

                objectQueue.Enqueue(factory());

            }

        }

        public T get(Func<T> factory)
        {

            if (objectQueue.Count == 0 && counter == 0)
            {

                throw new Exception("All out of objects");

            }

            if (objectQueue.Count == 0 && counter > 0)
            {

                counter++;
                Console.WriteLine("Object created, " + (max - counter) + " more Objects left ");
                return factory();

            }

            counter++;
            Console.WriteLine("Object created, " + (max - counter) + " more Objects left ");
            return objectQueue.Dequeue();

        }

        public void put(T Obj)
        {

            if (objectQueue.Count == max)
            {

                throw new Exception("Maximum object pooling");

            }

            counter--;
            Console.WriteLine("Object returned, " + (max - counter) + " more Objects left ");
            objectQueue.Enqueue(Obj);

        }
    }
}
