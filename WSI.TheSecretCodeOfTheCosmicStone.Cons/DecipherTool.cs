using System.Net.Http.Json;
using System.Text;
using Wsi.AqualonPrime.Cons;

namespace WSI.TheSecretCodeOfTheCosmicStone.Cons
{
    public class Dto
    {
        public string AlienMessage { get; set; }
    }

    public class DecipherTool : HackTheFutureClient
    {

        public DecipherTool()
        {
            BaseAddress = new Uri("https://app-htf-2024.azurewebsites.net/");
        }

        public async Task GetData()
        {
            var message = await this.GetFromJsonAsync<Dictionary<string, string>>("/api/b/easy/alphabet");

            var alienMessage = await this.GetFromJsonAsync<Dto>("api/b/easy/sample");

            StringBuilder result = DecryptCode(alienMessage.AlienMessage, message);

            Console.WriteLine(result);
        }


        private StringBuilder DecryptCode(string message, Dictionary<string, string> alphabetLetters)
        {
            StringBuilder result = new("");

            foreach (char letter in message)
            {
                foreach (var alphabetLetter in alphabetLetters)
                {
                    if (alphabetLetter.Value == letter.ToString())
                    {
                        result.Append(alphabetLetter.Key);
                    }
                }
            }

            return result;
        }
    }
}
