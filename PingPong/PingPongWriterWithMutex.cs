﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PingPong
{
    public class PingPongWriterWithMutex
    {
        private readonly int _count;
        private int _pings = 0;
        private int _pongs = 0;
        private Mutex _mutex;
        private AutoResetEvent _pingDoneEvent;
        private AutoResetEvent _pongDoneEvent;

        public PingPongWriterWithMutex(int count)
        {
            _count = count;
        }

        public void WritePingPongs()
        {
            _mutex = new Mutex(true);
            _pingDoneEvent = new AutoResetEvent(false);
            _pongDoneEvent = new AutoResetEvent(false);

            var pingThread = new Thread(new ThreadStart(WritePings));
            pingThread.Start();

            var pongThread = new Thread(new ThreadStart(WritePongs));
            pongThread.Start();

            Console.WriteLine("Ready...Set...Go!");
            _mutex.ReleaseMutex();
            WaitHandle.WaitAll(new WaitHandle[] {_pingDoneEvent, _pongDoneEvent});
            Console.WriteLine("Done!");
        }
        
        public void WritePings()
        {
            while (_pings < _count)
            {
                _mutex.WaitOne();
                if (_pings == _pongs)
                {
                    Console.WriteLine("Ping!");
                    _pings++;
                }
                _mutex.ReleaseMutex();
            }

            _pingDoneEvent.Set();
        }

        public void WritePongs()
        {
            while (_pongs < _count)
            {
                _mutex.WaitOne();
                if (_pongs < _pings)
                {
                    Console.WriteLine("Pong!");
                    _pongs++;
                }
                _mutex.ReleaseMutex();
            }

            _pongDoneEvent.Set();
        }
    }
}
