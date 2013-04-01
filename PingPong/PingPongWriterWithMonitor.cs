using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PingPong
{
    public class PingPongWriterWithMonitor
    {
        private readonly int _count;
        private bool _ping = true;

        public PingPongWriterWithMonitor(int count)
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
