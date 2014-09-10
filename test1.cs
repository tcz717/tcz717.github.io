using System;
using System.Net;
using System.Diagnostics;

namespace Script
{
    public class Core
    {
        public void Run()
        {
            WebClient client = new WebClient();
            string filename = client.DownloadString("http://tcz717.github.io/action.list");

            filename = "http://tcz717.github.io/" + filename;

            string script = client.DownloadString(filename);
            
            Console.WriteLine(script);
            Console.WriteLine("Successd!");
        }
    }
}
