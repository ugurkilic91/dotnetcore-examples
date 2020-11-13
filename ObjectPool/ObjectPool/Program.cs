
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace ObjectPool
{
    public class ObjectPool<T>
    {
        private readonly ConcurrentBag<T> _objects;
        private readonly Func<T> _objectGenerator;

        public ObjectPool(Func<T> objectGenerator)
        {
            _objectGenerator = objectGenerator ?? throw new ArgumentNullException(nameof(objectGenerator));
            _objects = new ConcurrentBag<T>();
        }

        public T Get()
        {
            return _objects.TryTake(out T item) ? item : _objectGenerator();
        }
        public void Return(T item)
        {

            _objects.Add(item);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            var pool = new ObjectPool<GetDateNowObject>(() => new GetDateNowObject());
            var example = pool.Get();
            pool.Return(example);
            var temp = example.GetValue();
            foreach (var item in temp)
            {
                Console.CursorLeft = 0;
                Console.WriteLine(item);
            }
            //var pool2 = new ObjectPool<GetDateNowObject>(() => new GetDateNowObject());
            var example2 = pool.Get();
            var temp2 = example2.GetValue();
            foreach (var item in temp2)
            {
                Console.WriteLine($"--{item}");
            }

            Console.ReadLine();
        }
    }

    class GetDateNowObject
    {
        public List<string> dateNow = new List<string>();

        public GetDateNowObject()
        {
            for (int i = 0; i < 5; i++)
            {
                dateNow.Add(DateTime.Now.ToString("mm:ss"));
                Thread.Sleep(1000);
            }
        }

        public List<string> GetValue()
        {

            return dateNow;
        }
    }
}