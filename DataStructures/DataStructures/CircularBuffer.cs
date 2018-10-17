using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class CircularBuffer<T> : Buffer<T>
    {
        int _capacity;
        //private Queue<T> _queue = new Queue<T>();
        public CircularBuffer(int capacity = 10)
        {
            _capacity = capacity;
        }

        public override void Write(T value)
        {
            base.Write(value);
            if(_queue.Count > _capacity)
                _queue.Dequeue(); // throw away the oldest item 
        }

        public bool IsFull { get { return _queue.Count == _capacity; } }
    }
}
