using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp26
{
    public class Timer 
    {
        public event EventHandler Tick;
        private bool _isRunning;

        public void Start()
        {
            _isRunning = true;
            while (_isRunning)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Тик!");
                Tick?.Invoke(this, EventArgs.Empty);
                
            }
        }

        public void Stop()
        {
            _isRunning = false;
        }

    }
    public class Clock
    {
        public void ShowTimeTick(Timer timer)
        {

            timer.Tick += ShowTime;
        }
        public void ShowTime(object sender, EventArgs e)
        {
            string nowData = DateTime.Now.ToString("HH:mm:ss");
            Console.WriteLine("Время: "+nowData);
        }

    }
    public class Counter
    {
        private int counter = 0;
        public void CountTick(Timer timer)
        {
            timer.Tick += Count;
        }
        public void Count(object sender, EventArgs e)
        {
            counter++;
            Console.WriteLine("Значение счетчика: "+counter); 
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();
            Clock clock = new Clock();
            Counter counter = new Counter();

            clock.ShowTimeTick(timer);
            counter.CountTick(timer);

            timer.Start();
        }
    }
}
