using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TrivaApp.Models;
using TrivaApp.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(ApiService))]
namespace TrivaApp.Services
{
	public class ApiService : IApiService
	{
        private static HttpClient HttpClient;
        public ApiService()
		{
            HttpClient = new HttpClient();
		}

        public async Task<string> GetAsync(string uri)
        {
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var res = await HttpClient.GetAsync(uri);
                if (res.IsSuccessStatusCode)
                {
                    return await res.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception e)
            {
                //pointless here but would log and catch in app
                throw e;
            }
        }
    }
}

