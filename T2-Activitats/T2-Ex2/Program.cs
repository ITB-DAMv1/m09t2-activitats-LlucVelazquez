using System.Diagnostics;

namespace T2_Ex2
{
    internal class Program
    {
		public static bool isPing = true;
		public static int Rounds = 10;
		public static object Locker = new object();
		static void Main(string[] args)
        {
			Process[] processes = Process.GetProcesses();
			List<string> processList = new List<string>();

            foreach (Process os in processes)
			{
                string info = $"PID: {os.Id} \t Name: {os.ProcessName} ";
                Console.WriteLine(info);
                processList.Add(info);
            }
			string fileName = "processes.txt";
            File.WriteAllLines(fileName, processList);

            /*
            Thread th1 = new Thread(Ping);
            Thread th2 = new Thread(Pong);
            th1.Start();
            th2.Start();

            th1.Join();
            th2.Join();*/
        }
		static void ReverseCount()
		{
			for (int i = 10; i > 0; i--)
			{
				Console.WriteLine("RCount: "+ i);
				Thread.Sleep(3000);
			}
		}
		static void Count()
		{
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine("Count "+ i);
				Thread.Sleep(1000);
			}
		}
		
		static void Ping()
		{
			
			for (int i = 0; i < Rounds; i++)
			{
				lock (Locker)
				{
					while (!isPing)
					{
						Monitor.Wait(Locker);
					}
					Console.WriteLine("Ping");
					isPing = false;
				}
				
			}
		}
		static void Pong()
		{
			for (int i = 0; i < Rounds; i++)
			{
				lock (Locker)
				{
					Console.WriteLine("\t Pong");
					isPing = true;
				}
				
			}
		}
	}
}
