using System;

namespace WipKata.Runner
{
    class Program
    {
        static void Main(string[] args)
        {            
            RunnerIoCConfig.Instance.Register();
 
            Console.Clear();

            Console.WriteLine("Hello World!");
        }
    }
}
