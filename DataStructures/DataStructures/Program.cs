using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {   // The variable has to be one type of the buffers not the buffers interface
            var circularBuffer = new CircularBuffer<double>();
            var buffer = new CircularBuffer<double>();

            ProcessInput(buffer);
            ProcessBuffer(buffer);
        }
        // The methods can take Input parameters as an interface type so it can receive any type of the buffers, as it would be more generic
        private static void ProcessBuffer(IBuffer<double> buffer)
        {
            var sum = 0.0;
            Console.WriteLine("Buffer: ");
            while (!buffer.IsEmpty)
            {
                sum += buffer.Read();
            }
            Console.WriteLine(sum);
        }

        private static void ProcessInput(IBuffer<double> buffer)
        {
            while (true)
            {
                var value = 0.0;
                var input = Console.ReadLine();

                if (double.TryParse(input, out value))
                {
                    buffer.Write(value);
                    continue;
                }
                break;
            }
        }
    }
}
