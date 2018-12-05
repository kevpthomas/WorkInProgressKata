using System;
using TinyIoC;
using WipKata.Core.Interfaces;

namespace WipKata.Runner
{
    class Program
    {
        static void Main(string[] args)
        {            
            RunnerIoCConfig.Instance.Register();
 
            Console.Clear();

            var cardProcessor = TinyIoCContainer.Current.Resolve<ICardProcessor>();
            cardProcessor.RunAllSequences();

            Console.Read();
        }
    }
}
