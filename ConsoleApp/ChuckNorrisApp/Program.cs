using System.Net;


namespace ChuckNorrisApp
{
    class Program
    {

        static void Main(string[] args)
        {
// --- First Function --- switches "Chuck Norris" with "Mark Moore"
//declare url string variable
            string url = "http://api.icndb.com/jokes/random";
// declare string json to call GetJson method which calls the url and returns the json string
            string json = GetJson(url);
            string newJson = json.Replace("Chuck Norris", "Mark Moore");
// write the json string to the console
            Console.WriteLine(newJson);

// --- Second Function --- enables the user to manually input which joke they want to see.
            string urlTwo = "http://api.icndb.com/jokes/";
// ask the user to input a number between 1 and 619
            Console.WriteLine("Please enter a number between 1 and 619");
            string numberString = Console.ReadLine();
// use string interpolation to concat the urlTwo and numberString to get the url for the joke the user wants to see.
            string newUrl = $"{urlTwo}{numberString}";
// call the GetJson2 method and pass the newUrl to get the json string for the joke the user wants to see.
            string jsonTwo = GetJson2(newUrl);
// outputs jsonTwo to the console.
            Console.WriteLine(jsonTwo);

        }
        static string GetJson(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string json = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return json;
        }
//this violates the DRY principle, but I'm not sure how I should go about fixing it. . . 
//perhaps instead of url or newUrl, I could pass the web address into another variable (x) and pass x into a single getJson method as the parameter inside of WebRequest.Create()?
        static string GetJson2(string newUrl)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(newUrl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string jsonTwo = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return jsonTwo;
        }
    }
}

