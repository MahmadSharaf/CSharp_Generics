using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Buffer<T> : IBuffer<T>
    {
        protected Queue<T> _queue = new Queue<T>();

        public virtual bool IsEmpty
        {
            get { return _queue.Count() == 0; }
        }

        public virtual T Read()
        {
           return  _queue.Dequeue();
        }

        public virtual void Write(T value)
        {
            _queue.Enqueue(value);
        }


        // IEnumerable to implemented two methods has to be created
        // This one is created for the
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _queue)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<TOutput> AsEnumerableOf<TOutput>()
        {// This iterates through items but outputs a different type than the buffer's type
            var converter = TypeDescriptor.GetConverter(typeof(T)); // This creates a converter of type T
            foreach (var item in _queue)
            {
                var result = converter.ConvertTo(item, typeof(TOutput));
                //yield builds an IEnumerable return 
                yield return (TOutput)result;//casting to (TOutput) to make sure that the converting was correct
            }
        }
    }
}
