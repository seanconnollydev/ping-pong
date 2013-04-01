using System;
using System.Threading;

namespace PingPong
{
    public class Program
    {
        static void Main(string[] args)
        {
            var writer = new PingPongWriter(count:3);

            var pingThread = new Thread(new ThreadStart(writer.WritePing));
            var pongThread = new Thread(new ThreadStart(writer.WritePong));

            Console.WriteLine("Ready...Set...Go!");

            pingThread.Start();
            pongThread.Start();

            pingThread.Join();
            pongThread.Join();

            Console.WriteLine("Done!");
        }
    }

    public class PingPongWriter
    {
        private readonly int _count;
        private bool _ping = true;

        public PingPongWriter(int count)
        {
            _count = count;
        }
        
        public void WritePing()
        {
            for (int i = 0; i < _count; i++)
            {
                lock (this)
                {
                    if (!_ping)
                    {
                        Monitor.Wait(this);
                    }

                    Console.WriteLine("Ping!");
                    _ping = false;
                    Monitor.Pulse(this);       
                }
            }
        }

        public void WritePong()
        {
            for (int i = 0; i < _count; i++)
            {
                lock (this)
                {
                    if (_ping)
                    {
                        Monitor.Wait(this);
                    }
                    Console.WriteLine("Pong!");
                    _ping = true;
                    Monitor.Pulse(this);
                }
            }
        }
    }
}
