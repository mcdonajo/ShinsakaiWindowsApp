using System.Collections.Generic;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace ShinsakaiWindowsApp
{
    class WebServer
    {
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
            try
            {
                while (shouldContinue)
                {
                    // Note: The GetContext method blocks while waiting for a request. 
                    HttpListenerContext context = listener.GetContext();
                    HttpListenerRequest request = context.Request;
                    // Obtain a response object.
                    HttpListenerResponse response = context.Response;
                    // Construct a response.
                    string responseStart = "<HTML><BODY>\n";
                    string responseEnd = "\n</BODY></HTML>";
                    List<String> contents = DataManager.GroupManager.getPrintContentsForDivision(DataManager.CurrentDivision);
                    string responseString = responseStart;
                    foreach (string s in contents)
                        responseString += (s + "\n");
                    responseString += responseEnd;
                    byte[] buffer = Encoding.UTF8.GetBytes(responseString.Replace("\n", "<br>"));
                    // Get a response stream and write the response to it.
                    response.ContentLength64 = buffer.Length;
                    Stream output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    // You must close the output stream.
                    output.Close();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Server aborted");
            }
        }

        public void end()
        {
            shouldContinue = false;
            listener.Stop();
        }
    }
}
