using System.Net;

class Program
{
    static void Main(string[] args)
    {
        // Create an HttpListener to listen for requests on the specified port.
        HttpListener listener = new HttpListener();
        listener.Prefixes.Add("http://localhost:3001/");
        listener.Start();
        Console.WriteLine("Server running at http://localhost:3001/");

        // Handle requests asynchronously.
        ThreadPool.QueueUserWorkItem((state) =>
        {
            while (true)
            {
                // Wait for a request to be received.
                HttpListenerContext context = listener.GetContext();

                // Create a response.
                HttpListenerResponse response = context.Response;
                string responseString = "Hello from Backend Server 1!";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

                // Write the response.
                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer, 0, buffer.Length);
                response.OutputStream.Close();
            }
        });

        Console.WriteLine("Press any key to stop the server.");
        Console.ReadKey();

        // Stop listening for requests.
        listener.Stop();
    }
}