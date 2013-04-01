using System;
using System.Threading;

namespace PingPong
{
    public class Program
    {
        static void Main(string[] args)
        {
            var writer = new PingPongWriterWithMutex(count: 3);
            writer.WritePingPongs();
        }
    }

    /*
    * MAIN method for use with Monitor object implementation
    * */
    //static void Main(string[] args)
    //{
    //    var writer = new PingPongWriter(count: 3);

    //    var pingThread = new Thread(new ThreadStart(writer.WritePing));
    //    var pongThread = new Thread(new ThreadStart(writer.WritePong));

    //    Console.WriteLine("Ready...Set...Go!");

    //    pingThread.Start();
    //    pongThread.Start();

    //    pingThread.Join();
    //    pongThread.Join();

    //    Console.WriteLine("Done!");
    //}
}
