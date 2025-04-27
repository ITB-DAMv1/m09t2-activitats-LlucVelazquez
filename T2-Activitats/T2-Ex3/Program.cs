using System.Diagnostics;

namespace T2_Ex3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
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
            Console.WriteLine("Introdueix el PID del programa que vols veure'n els threads i modules: ");
            int pid = int.Parse(Console.ReadLine());

            Process chromeP = null;
            try
            {
                chromeP = Process.GetProcessById(pid);
                ProcessThreadCollection pTC = chromeP.Threads;
                Console.WriteLine("Threads del programa {0}, ThreadCount: {1}", chromeP.ProcessName, pTC.Count);
                foreach (ProcessThread pt in pTC)
                {
                    Console.WriteLine($"{pt.Id} \t Container: {pt.Container} ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            ProcessModuleCollection pMC = chromeP.Modules;
            Console.WriteLine("Modules del programa {0}, ModuleCount: {1}", chromeP.ProcessName, pMC.Count);
            foreach (ProcessModule pm in pMC)
            {
                Console.WriteLine($"{pm.ModuleName} \t {pm.Container}");
            }
        }
    }
}
