using System.Diagnostics;

namespace T2_Ex2
{
    internal class Program
    {
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

			Thread th = new Thread(Compte);
			th.Start();
		}
		static void Compte()
		{
			for (int i = 10; i > 0; i--)
			{
				Console.WriteLine(i);
			}
		}
	}
}
