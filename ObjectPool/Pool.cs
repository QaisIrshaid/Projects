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
            Pool<Cars> pool = new Pool<Cars>(3, 5, Cars.create);
            Cars car1 = pool.getObj(Cars.create);
            Cars car2 = pool.getObj(Cars.create);
            Cars car3 = pool.getObj(Cars.create);
            Cars car4 = pool.getObj(Cars.create);
            Cars car5 = pool.getObj(Cars.create);
            pool.putObj(car4);

            Cars car6 = pool.getObj(Cars.create);

        }


    }


    class Cars
    {
        public String name { get; set; }
        public int year { get; set; }
        public String color { get; set; }

        public static Cars create()
        {  return new Cars(); }
      

    }
    public class Pool<T>
    {
        private  int max;
        private int initial;
        private int counter;
        private Queue<T> q;

        public Pool(int initial, int max, Func<T> factory)
        {
            this.initial = initial;
            this.max = max;
            counter = 0;
            q = new Queue<T>(max);

            for(int i = 0; i < initial; i++)
                 q.Enqueue(factory());
        }

        public T getObj(Func<T> factory)
        {
            
            if (q.Count == 0 && this.counter == 0)
                throw new Exception("All out of objects");

            else if (q.Count == 0 && this.counter > 0)
            {
              counter++; 
              Console.WriteLine("Object created, " + (max - counter) + " more Objects left "); 
              return factory();
            }

            else
            {
                counter++; 
                Console.WriteLine("Object created, " + (max - counter) + " more Objects left ");
                return q.Dequeue();
            }


        }

        public void putObj(T Obj)
        {
            if (q.Count == max)
                throw new Exception("Maximum object pooling");

            else
            { 
              counter--; 
              Console.WriteLine("Object returned, " + (max - counter) + " more Objects left "); 
              q.Enqueue(Obj);
            }
        
        }

        

    }
}
