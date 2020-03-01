using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //var newPerson = new Person { FirstName = "Adrian" };

            //var tmp10 = 1;


            var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);


                //2xx - chcemy
                //4xx - nie odpowiada
                //5xx - zle
                if (response.IsSuccessStatusCode)
                {
                    var htmlContent = await response.Content.ReadAsStringAsync();
                    var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);

                    var matches = regex.Matches(htmlContent);

                    foreach (var match in matches)
                    {
                        Console.WriteLine(match.ToString());
                    }

                }
            }        

        }
    }
}
