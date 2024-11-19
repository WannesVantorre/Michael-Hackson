namespace Wsi.AqualonPrime.Cons
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //var client = new HackTheFutureClient();
            //await client.Login(Constants.Name, Constants.Token);
            LocationSolverService service = new LocationSolverService();
            service.Calculate();
        }
    }
}
