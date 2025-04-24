using System.Diagnostics;

namespace T2_Ex2
{
    internal class Program
    {
		public static bool isPing = true;
		public static int Rounds = 10;
		public static object Locker = new object();
		static void Main(string[] args)
        {/*
			//Executa el programa dotnet amb l’argument –info. 
			var process = new Process
			{
				//Configurem el process amb la classe ProcessStartInfo
				StartInfo = new ProcessStartInfo
				{
					FileName = "dotnet",
					Arguments = "--info",
					RedirectStandardOutput = true,
					UseShellExecute = false,
					CreateNoWindow = true
				}
			};

			process.Start();

			//Capturem el que s’ha imprés per pantalla:
			string output = process.StandardOutput.ReadToEnd();
			process.WaitForExit();
			Console.WriteLine(output);
			var processos = Process.GetProcesses();
			foreach (Process os in processos)
			{
				Console.WriteLine($"PID: {os.Id} \t Name: {os.ProcessName} ");
			}
			int pid = int.Parse(Console.ReadLine());*/

			Thread th1 = new Thread(Ping);
			Thread th2 = new Thread(Pong);
			th1.Start();
			th2.Start();

			th1.Join();
			th2.Join();
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
