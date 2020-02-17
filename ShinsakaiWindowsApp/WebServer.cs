using System.Collections.Generic;
using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace ShinsakaiWindowsApp
{
    class WebServer
    {
        static string responseStart = "<HTML><BODY>\n";
        static string responseEnd = "\n</BODY></HTML>";

        private string host;
        private bool shouldContinue = true;
        HttpListener listener;
        public WebServer()
        {
            host = "http://localhost:8080/test/";
        }

        public void Listen()
        {
            // Create a listener.
            listener = new HttpListener();
            // Add the prefixes.
            listener.Prefixes.Add(host);
            listener.Start();
            Console.WriteLine("Listening...");
            while (shouldContinue)
            {
                try
                {
                    // Note: The GetContext method blocks while waiting for a request. 
                    HttpListenerContext context = listener.GetContext();
                    HttpListenerRequest request = context.Request;
                    // Obtain a response object.
                    string path = request.Url.LocalPath;
                    string responseString = respondWithError();
                    if (path.EndsWith("groups"))
                        responseString = respondWithDisplayGroups();
                    if (path.EndsWith("group"))
                        responseString = respondWithGroupInfo(request.Url.Query.Trim('?'));
                    byte[] buffer = Encoding.UTF8.GetBytes(responseString.Replace("\n", "<br>"));
                    // Get a response stream and write the response to it.
                    HttpListenerResponse response = context.Response;
                    response.ContentLength64 = buffer.Length;
                    Stream output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    // You must close the output stream.
                    output.Close();

                }
                catch (Exception e)
                {
                    if (listener.IsListening)
                        Console.WriteLine("Request '" + listener.GetContext().Request.Url.AbsolutePath + "' caused an error");
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }
            }
        }

        public string respondWithDisplayGroups()
        {
            List<string> contents = DataManager.GroupManager.getPrintContentsForDivision(DataManager.CurrentDivision);
            string responseString = responseStart;
            foreach (string s in contents)
                responseString += (s + "\n");
            responseString += responseEnd;
            return responseString;
        }

        public string respondWithGroupInfo(string groupIDQuery)
        {
            string[] groupIDArr = groupIDQuery.Split('=');
            if (groupIDArr == null || groupIDArr.Length < 2)
                return respondWithError();
            Group g = DataManager.GroupManager.getGroup(groupIDArr[1]);
            if (g == null)
            {

                return respondWithError();
            }
            //return JsonConvert.SerializeObject(g, Formatting.None, new JsonSerializerSettings() {ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
            return JsonConvert.SerializeObject(g);
        }

        public string respondWithError()
        {
            return responseStart + "Oops!" + responseEnd; ;
        }

        public void end()
        {
            shouldContinue = false;
            listener.Stop();
        }
    }
}
