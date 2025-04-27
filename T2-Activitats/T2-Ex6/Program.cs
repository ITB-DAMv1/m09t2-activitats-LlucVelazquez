namespace T2_Ex6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Thread[] camells = {
            new Thread(() => CorrerCamell(1, 50, 200)),  // Camell 1: 50-200ms
            new Thread(() => CorrerCamell(2, 80, 150)),  // Camell 2: 80-150ms
            new Thread(() => CorrerCamell(3, 30, 300)),  // Camell 3: 30-300ms
            new Thread(() => CorrerCamell(4, 100, 250)), // Camell 4: 100-250ms
            new Thread(() => CorrerCamell(5, 60, 180))   // Camell 5: 60-180ms
            };

            Console.WriteLine("Carrera de camells!");
            Console.WriteLine("-------------------\n");

            // Iniciar tots els camells
            foreach (var camell in camells)
            {
                camell.Start();
            }

            // Esperar que acabin tots els camells
            foreach (var camell in camells)
            {
                camell.Join();
            }

            Console.WriteLine("\nLa carrera ha acabat!");
        }
        public static void CorrerCamell(int numero, int minSleep, int maxSleep)
        {
            Random rand = new Random();
            for (int i = 0; i <= 100; i++)
            {
                Console.WriteLine($"Camell {numero} -> Posició: {i}");
                Thread.Sleep(rand.Next(minSleep, maxSleep));
            }
            Console.WriteLine($"CAMELL {numero} HA ACABAT!");
        }
    }
}
