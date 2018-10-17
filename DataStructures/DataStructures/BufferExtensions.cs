using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{   //Extension class
    public static class BufferExtensions
    {   // Because Extension class can not accept generic types, so it will be send in the method itself
        public static IEnumerable<TOutput> AsEnumerableOf<T, TOutput>
            (this IBuffer<T> buffer) // This extends to IBuffer interface
        {
            // This iterates through items but outputs a different type than the buffer's type
            var converter = TypeDescriptor.GetConverter(typeof(T)); // This creates a converter of type T

            foreach (var item in buffer) //buffer is used instead of _queue
            {
                TOutput result = (TOutput)converter.ConvertTo(item, typeof(TOutput));
                //yield builds an IEnumerable return 
                yield return result;//casting to (TOutput) to make sure that the converting was correct
            }
        }

        public static void Dump<T>(this IBuffer<T> buffer)
        {
            foreach (var item in buffer)
            {
                Console.WriteLine(item);
            }
        }
    }
}
