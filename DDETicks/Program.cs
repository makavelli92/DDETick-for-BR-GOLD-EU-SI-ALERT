using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDde;
using DDETicks.DAL.DDE.XlDde;
using DDETicks.DAL.DDE;
using System.Diagnostics;
namespace DDETicks
{
    class Program
    {
        static void Alert()
        {
            ProcessStartInfo infoStartProcess = new ProcessStartInfo();
            infoStartProcess.WorkingDirectory = @"C:\Users\User\Documents\Visual Studio 2017\Projects\ExperimentForWealthLab\ExperimentForWealthLab2\bin\Debug";
            infoStartProcess.FileName = "ExperimentForWealthLab2";
            System.Diagnostics.Process.Start(infoStartProcess);
        }
        static void EventSignal(object e, string str)
        {
            Console.WriteLine("{0} - {1}\n", str, DateTime.Now);
            Alert();
        }
        static void Main(string[] args)
        {
            using (XlDdeServer server = new XlDdeServer("Ticks2"))
            {
                Console.BufferWidth = 150;
                server.AddChannel(new DataReception("Si", 60, EventSignal, 35000, 3600, 8000, 6000, 1200));
                server.AddChannel(new DataReception("BR", 60, EventSignal, 25000, 4000, 9200, 5000, 1900));
                server.AddChannel(new DataReception("GOLD", 60, EventSignal, 1950, 1000, 1200, 1000, 200));
                server.Register();
                Console.WriteLine("DDE server ready. Press Enter to exit.DDE server ready.\n\n");
                Console.ReadLine();
            }
        }
    }
}
