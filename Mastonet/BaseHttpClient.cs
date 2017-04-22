using Mastonet.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mastonet
{
    public abstract class BaseHttpClient
    {
        public string Instance { get; protected set; }
        public AppRegistration AppRegistration { get; set; }
        public Auth AuthToken { get; set; }

        private string URL(string route) => $"https://{this.Instance}{route}";

        #region Http helpers

        private void AddHttpHeader(HttpClient client)
        {
            if (AuthToken != null)
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {AuthToken.AccessToken}");
            }
        }

        protected async Task<string> Delete(string route)
        {
            var client = new HttpClient();
            AddHttpHeader(client);
            var response = await client.DeleteAsync(URL(route));
            return await response.Content.ReadAsStringAsync();
        }

        protected async Task<string> Get(string route)
        {
            var client = new HttpClient();
            AddHttpHeader(client);
            var response = await client.GetAsync(URL(route));
            return await response.Content.ReadAsStringAsync();
        }

        protected async Task<T> Get<T>(string route)
            where T : class
        {
            var content = await Get(route);
            return TryDeserialize<T>(content);
        }

        protected async Task<string> Post(string route, IEnumerable<(string, string)> data = null)
        {
            var client = new HttpClient();
            AddHttpHeader(client);

            var content = new FormUrlEncodedContent(data?.Select(x => new KeyValuePair<string, string>(x.Item1, x.Item2)) ?? Enumerable.Empty<KeyValuePair<string, string>>());
            var response = await client.PostAsync(URL(route), content);
            return await response.Content.ReadAsStringAsync();
        }

        protected async Task<T> Post<T>(string route, IEnumerable<(string, string)> data = null)
            where T : class
        {
            var content = await Post(route, data);
            return TryDeserialize<T>(content);
        }

        protected async Task<string> Patch(string route, IEnumerable<(string, string)> data = null)
        {
            var client = new HttpClient();
            var method = new HttpMethod("PATCH");
            AddHttpHeader(client);

            var content = new FormUrlEncodedContent(data?.Select(x => new KeyValuePair<string, string>(x.Item1, x.Item2)) ?? Enumerable.Empty<KeyValuePair<string, string>>());
            var message = new HttpRequestMessage(method, URL(route));
            message.Content = content;
            var response = await client.SendAsync(message);
            return await response.Content.ReadAsStringAsync();
        }

        protected async Task<T> Patch<T>(string route, IEnumerable<(string, string)> data = null)
            where T : class
        {
            var content = await Patch(route, data);
            return TryDeserialize<T>(content);
        }

        private T TryDeserialize<T>(string json)
        {
            //TODO handle error gracefully
            //var error = JsonConvert.DeserializeObject<Error>(json);
            //if (!string.IsNullOrEmpty(error.Description))
            //{
            //    throw new ServerErrorException(error);
            //}

            return JsonConvert.DeserializeObject<T>(json);
        }

        #endregion
    }
}
