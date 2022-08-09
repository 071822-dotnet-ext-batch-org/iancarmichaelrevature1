using System.Net;


namespace ChuckNorrisApp
{
    class Program
    {

        static void Main(string[] args)
        {
// First method changes Chuck Norris to Mark Moore.
            string url = "http://api.icndb.com/jokes/random";
            string json = GetJson(url);
            string newJson = json.Replace("Chuck Norris", "Mark Moore");
            Console.WriteLine(newJson);
// Second method enables the user to manually input which joke they want to see.
            string urlTwo = "http://api.icndb.com/jokes/";
            Console.WriteLine("Please enter a number between 1 and 619");
            string numberString = Console.ReadLine();
            string newUrl = $"{urlTwo}{numberString}";
            string jsonTwo = GetJson2(newUrl);
            Console.WriteLine(jsonTwo);

        }
        static string GetJson(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string json = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return json;
        }
        static string GetJson2(string newUrl)
        {
    // ask the user to input a number between 1 and 619
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(newUrl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string jsonTwo = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return jsonTwo;
        }
    }
}

