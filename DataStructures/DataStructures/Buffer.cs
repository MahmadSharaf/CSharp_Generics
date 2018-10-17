using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Buffer<T> : IBuffer<T>
    {
        private Queue<T> _queue = new Queue<T>();

        public bool IsEmpty
        {
            get { return _queue.Count() == 0; }
        }

        public T Read()
        {
           return  _queue.Dequeue();
        }

        public void Write(T value)
        {
            _queue.Enqueue(value);
        }
    }
}
