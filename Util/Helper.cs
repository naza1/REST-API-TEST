using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HypermediaApiTests.Util
{
	public static class Helper
	{
		public static HttpClient httpClient = new HttpClient { BaseAddress = new Uri(ConfigUtil.GetString("hypermedia_Api_Url")) };

		public static T WaitAndGetValue<T>(this Task<T> task)
		{
			try
			{
				task.Wait();
				return task.Result;
			}
			catch (Exception e)
			{
				throw e.InnerException ?? e;
			}
		}

		public static string GetContentAsString(this HttpResponseMessage response)
		{
			return response.Content.ReadAsStringAsync().WaitAndGetValue();
		}

		public static JObject GetContentAsJObject(this HttpResponseMessage response)
		{
			return JObject.Parse(response.GetContentAsString());
		}

		public static T GetContentAs<T>(this HttpResponseMessage response)
		{
			return JsonConvert.DeserializeObject<T>(response.GetContentAsString());
		}

		//Create new Request and return HttpReponseMessage
		public static HttpResponseMessage CreateRequest(string uri, HttpMethod method, string json = null, string apiKey = null)
		{
			apiKey = apiKey ?? ConfigUtil.GetString("api_Key");
			using (var request = new HttpRequestMessage(method, uri))
			{
				request.Headers.Add("Authorization", "token " + apiKey);
				if (json != null)
					request.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

				var response = httpClient.SendAsync(request).WaitAndGetValue();
				Thread.Sleep(50);
				return response;
			}
		}
	}
}
