using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {   // The variable has to be one type of the buffers not the buffers interface
            var circularBuffer = new CircularBuffer<double>();
            var buffer = new Buffer<double>();
            var asInts = buffer.AsEnumerableOf<double, int>();
            //var consoleOut = new Action<double>(ConsoleWrite);
            //Action<double> print = ConsoleWrite;//A delegate action
            //Action<double> print = delegate (double data) //Auto implemented
            //{
            //    Console.WriteLine(data);
            //};

            //Delegates with lambdas:
            //Action takes up to 16 generic inputs and returns void
            Action<bool> print = d => Console.WriteLine(d);//Using lambdas
            //Func takes up to 16 generic inputs and returns a generic output
            Func<double, double> square = d => d * d;
            Func<double, double, double> add = (x, y) => x + y;
            //Predicate takes 1 input and returns boolean
            Predicate<double> isLessThanTen = d => d < 10;

            print(isLessThanTen(square(add(3,5))));

            ProcessInput(buffer);
            buffer.Dump(d => Console.WriteLine(d));
            ProcessBuffer(buffer);
        }
        // Implemented in Action delegate
        //private static void ConsoleWrite(double data)
        //{
        //    Console.WriteLine(data);
        //}

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
