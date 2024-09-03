using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Define backend server URLs
        List<string> backendServers = new List<string>
        {
            "http://localhost:3001",
            "http://localhost:3002",
            "http://localhost:3003"
        };

        // Create an HttpClient instance
        HttpClient httpClient = new HttpClient();

        // Counter to keep track of requests
        int requestCount = 0;

        // Continuously send requests to backend servers
        while (true)
        {
            // Increment request counter
            requestCount++;

            // Get the index of the backend server to send the request to
            int serverIndex = requestCount % backendServers.Count;

            // Send a GET request to the selected backend server
            string backendUrl = backendServers[serverIndex];
            HttpResponseMessage response = await httpClient.GetAsync(backendUrl);

            // Display the response status code
            Console.WriteLine($"Request sent to {backendUrl}. Response status code: {response.StatusCode}");

            // Pause for a moment before sending the next request
            await Task.Delay(1000);
        }
    }
}