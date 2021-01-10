namespace AsyncAwait
{
    using System;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();

            Console.ReadKey();
        }

        static async Task MainAsync(string[] args)
        {
            int n = await GetNumber();

            Console.WriteLine(n);

            int o = await GetNumber();

            Console.WriteLine(o);
        }

        static async Task<int> GetNumber()
        {
            await Task.Delay(100);

            return 42;
        }
    }
}
