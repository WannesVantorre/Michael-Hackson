using Wsi.AqualonPrime.Cons;

namespace WSI.TheSecretCodeOfTheCosmicStone.Cons
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var decipherTool = new DecipherTool();

            await decipherTool.Login(Constants.Name, Constants.Token);

            await decipherTool.GetData();
        }
    }
}
