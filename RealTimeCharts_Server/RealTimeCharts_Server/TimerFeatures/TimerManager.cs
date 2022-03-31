using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RealTimeCharts_Server.TimerFeatures
{
    public class TimerManager
    {
        private Timer timer;
        private AutoResetEvent autoResetEvent;
        private Action action;
        public DateTime TimerStarted { get; }
        public TimerManager(Action action)
        {
            this.action = action;
            autoResetEvent = new AutoResetEvent(false);
            timer = new Timer(Execute, autoResetEvent, 1000, 2000);
            TimerStarted = DateTime.Now;
        }
        public void Execute(object stateInfo)
        {
            action();
            if ((DateTime.Now - TimerStarted).Seconds > 60)
            {
                timer.Dispose();
            }
        }
    }
}
