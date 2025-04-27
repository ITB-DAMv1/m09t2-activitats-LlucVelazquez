namespace T2_Ex5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Abans de començar el fil");
            Thread t1 = new Thread(() => Console.WriteLine("Soc el fil numero 1"));
            Thread t2 = new Thread(() => Console.WriteLine("Soc el fil numero 2"));
            Thread t3 = new Thread(() => Console.WriteLine("Soc el fil numero 3"));
            Thread t4 = new Thread(() => Console.WriteLine("Soc el fil numero 4"));
            Thread t5 = new Thread(() => Console.WriteLine("Soc el fil numero 5"));
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();

            Thread.Sleep(1500); 

            Console.WriteLine("\nExecució ordenada amb Sleep():");
            LlançarFilsOrdenats();

            static void LlançarFilsOrdenats()
            {
                for (int i = 5; i >= 1; i--)
                {
                    int num = i;
                    new Thread(() => {
                        Thread.Sleep(100 * (5 - num));
                        Console.WriteLine($"Hola! Soc el fil número {num}");
                    }).Start();
                }
            }
        }
    }
}
