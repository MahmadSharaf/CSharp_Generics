﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{   //Extension class

   // public delegate void Printer<T>(T data);//A delegate replaced by Action<T>

    public static class BufferExtensions
    {   
        /*
        // Because Extension class can not accept generic types, so it will be send in the method itself
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
        */

        public static IEnumerable<TOutput> Map<T, TOutput>(
            this IBuffer<T> buffer, Converter<T, TOutput> converter)
        {
            return buffer.Select(i => converter(i));
        }

        public static void Dump<T>(this IBuffer<T> buffer, Action<T> print)
        {
            foreach (var item in buffer)
            {
                print(item);
            }
        }
    }
}
