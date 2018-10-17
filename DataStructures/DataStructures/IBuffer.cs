using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{   //Interfaces are used as the base for any derived classes, as it has the signature methods only which each derived class can has its own implementation for each method
    public interface IBuffer<T> : IEnumerable<T> // To add iterating feature to the buffers, IEnumerable has to implemented
    {
        bool IsEmpty { get; }
        IEnumerable<TOutput> AsEnumerableOf<TOutput>();
        T Read();
        void Write(T value);
    }
}