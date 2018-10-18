using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {   // The variable has to be one type of the buffers not the buffers interface
            var circularBuffer = new CircularBuffer<double>(capacity: 3);
            var buffer = new Buffer<double>();
            
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
            //Converter takes 1 input and return 1 output and used to convert types

            Converter<double, DateTime> converter = d => new DateTime(2010, 1, 1).AddDays(d);
            var asDates = buffer.Map(converter);
            //above two lines combined
            
            var asDates2 = buffer.Map(d => new DateTime(2010, 1, 1).AddDays(d));
            ProcessInput(circularBuffer);

            foreach (var date in asDates2)
            {
                Console.WriteLine(date);
            }
            print(isLessThanTen(square(add(3,5))));

           
            buffer.Dump(d => Console.WriteLine(d));
            ProcessBuffer(circularBuffer);
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
