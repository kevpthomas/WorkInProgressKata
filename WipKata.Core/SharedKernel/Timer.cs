using System;
using WipKata.Core.Interfaces;

namespace WipKata.Core.SharedKernel
{
    public class Timer : ITimer
    {
        private DateTime _start = DateTime.MinValue;
        private DateTime _stop = DateTime.MinValue;
        private readonly bool _isReportTimerActions;
        private readonly IOutputProvider _outputProvider;

        public Timer(string name, 
            bool isReportTimerActions, 
            IOutputProvider outputProvider)
        {
            Name = name;
            _isReportTimerActions = isReportTimerActions;
            _outputProvider = outputProvider;
        }

        public string Name { get; }

        public void Start()
        {
            _start = DateTime.UtcNow;

            if (_isReportTimerActions) _outputProvider.OutputLine($"{Name} started at {_start.ToShortTimeString()}");
        }

        public void Stop()
        {
            _stop = DateTime.UtcNow;

            if (_isReportTimerActions) _outputProvider.OutputLine($"{Name} stopped after {ElapsedSeconds} seconds");
        }

        public double ElapsedSeconds => (_stop - _start).TotalSeconds;
    }
}