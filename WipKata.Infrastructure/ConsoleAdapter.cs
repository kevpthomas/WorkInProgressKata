using System;
using WipKata.Core.Interfaces;

namespace WipKata.Infrastructure
{
    public class ConsoleAdapter : IOutputProvider
    {
        public void OutputLine(string value)
        {
            Console.WriteLine(value);
        }

        public void OutputLine(string format, object arg0)
        {
            Console.WriteLine(format, arg0);
        }
    }
}