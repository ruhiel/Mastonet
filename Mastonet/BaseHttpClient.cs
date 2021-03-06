﻿using Mastonet.Entities;
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

        #region Http helpers

        private void AddHttpHeader(HttpClient client)
        {
            if (AuthToken != null)
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + AuthToken.AccessToken);
            }
        }

        protected async Task<string> Delete(string route)
        {
            string url = "https://" + this.Instance + route;

            var client = new HttpClient();
            AddHttpHeader(client);
            var response = await client.DeleteAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

        protected async Task<string> Get(string route)
        {
            string url = "https://" + this.Instance + route;

            var client = new HttpClient();
            AddHttpHeader(client);
            var response = await client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

        protected async Task<T> Get<T>(string route)
            where T : class
        {
            var content = await Get(route);
            return TryDeserialize<T>(content);
        }

        protected async Task<string> Post(string route, IEnumerable<KeyValuePair<string, string>> data = null)
        {
            string url = "https://" + this.Instance + route;

            var client = new HttpClient();
            AddHttpHeader(client);

            var content = new FormUrlEncodedContent(data ?? Enumerable.Empty<KeyValuePair<string, string>>());
            var response = await client.PostAsync(url, content);
            return await response.Content.ReadAsStringAsync();
        }

        protected async Task<T> Post<T>(string route, IEnumerable<KeyValuePair<string, string>> data = null)
            where T : class
        {
            var content = await Post(route, data);
            return TryDeserialize<T>(content);
        }

        protected async Task<string> Patch(string route, IEnumerable<KeyValuePair<string, string>> data = null)
        {
            string url = "https://" + this.Instance + route;

            var client = new HttpClient();
            var method = new HttpMethod("PATCH");
            AddHttpHeader(client);

            var content = new FormUrlEncodedContent(data ?? Enumerable.Empty<KeyValuePair<string, string>>());
            var message = new HttpRequestMessage(method, url);
            message.Content = content;
            var response = await client.SendAsync(message);
            return await response.Content.ReadAsStringAsync();
        }

        protected async Task<T> Patch<T>(string route, IEnumerable<KeyValuePair<string, string>> data = null)
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
