using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {

        string data = @"duration,service_name=namechecking__proxy:s2,request.id=1,batch_nr=79894094545299,task=PreProcessing,status=start 7321
                        duration,service_name=namechecking__proxy:s2,request.id=1,batch_nr=79894094545299,task=DeltaProcessing,status=start 51876
                        duration,service_name=namechecking__proxy:s2,request.id=1,batch_nr=79894094545299,task=DeltaProcessing,status=finish 26493
                        duration,service_name=namechecking__proxy:s2,request.id=1,batch_nr=79894094545299,task=PreProcessing,status=finish 43789";

       await SendMetricsData(data);
    }

    static async Task SendMetricsData(string data)
    {
        using (HttpClient client = new HttpClient())
        {
            string url = "http://localhost:14499/metrics/ingest";
            client.DefaultRequestHeaders
                  .Accept
                  .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpContent content = new StringContent(data, Encoding.UTF8, "text/plain");
            try
            {
                HttpResponseMessage response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response: {responseBody}");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
        }
    }
}
