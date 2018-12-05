using WipKata.Core.Interfaces;

namespace WipKata.Core.SharedKernel
{
    public class TimerFactory : ITimerFactory
    {
        private readonly IOutputProvider _outputProvider;

        public TimerFactory(IOutputProvider outputProvider)
        {
            _outputProvider = outputProvider;
        }

        public ITimer CreateTimer(string name)
        {
            return CreateTimer(name, true);
        }

        public ITimer CreateTimer(string name, bool isReportTimerActions)
        {
            return new Timer(name, isReportTimerActions, _outputProvider);
        }
    }
}