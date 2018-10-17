namespace DataStructures
{   //Interfaces are used as the base for any derived classes, as it has the signature methods only which each derived class can has its own implementation for each method
    public interface IBuffer<T>
    {
        bool IsEmpty { get; }

        T Read();
        void Write(T value);
    }
}