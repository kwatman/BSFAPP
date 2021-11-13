using Imi.Project.Mobile.Core.Exceptions;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Interfaces.IRepositories;
using Newtonsoft.Json;
using Polly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Infrastructure.Repositories
{
    public class BaseRepository: IBaseRepository
    {
        public async Task<T> GetAllAsync<T>(string uri, string authToken = "")
        {
            try
            {
                HttpClient httpClient = CreateHttpClient(uri);
                string result = string.Empty;

                HttpResponseMessage responseMessage = await Policy.Handle<WebException>(exception =>
                {
                    Debug.WriteLine($"{exception.GetType().Name + " : " + exception.Message}");
                    return true;
                })
                .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                .ExecuteAsync(async () => await httpClient.GetAsync(uri));

                if (responseMessage.IsSuccessStatusCode)
                {
                    result = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                    var jsonResult = JsonConvert.DeserializeObject<T>(result);
                    return jsonResult ;
                }
                else
                {

                    if (responseMessage.StatusCode == HttpStatusCode.Forbidden
                        || responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new ServiceAuthenticationException(result);
                    }
                    else
                    {
                        throw new CustomHttpRequestException(responseMessage.StatusCode, result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<T> AddAsync<T>(string uri, T data, string authToken = "")
        {
            try
            {
                HttpClient httpClient = CreateHttpClient(uri);

                var content = new StringContent(JsonConvert.SerializeObject(data));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                string result = string.Empty;

                var responseMessage = await Policy.Handle<WebException>(exception =>
                {
                    Debug.WriteLine($"{exception.GetType().Name + " : " + exception.Message}");
                    return true;
                })
                .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                .ExecuteAsync(async () => await httpClient.PostAsync(uri, content));

                if (responseMessage.IsSuccessStatusCode)
                {
                    result = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                    var jsonResult = JsonConvert.DeserializeObject<T>(result);
                    return jsonResult;
                }
                else
                {
                    if (responseMessage.StatusCode == HttpStatusCode.Forbidden
                        || responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new ServiceAuthenticationException(result);
                    }
                    else
                    {
                        throw new CustomHttpRequestException(responseMessage.StatusCode, result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<T> UpdateAsync<T>(string uri, T data, string authToken = "")
        {
            try
            {
                HttpClient httpClient = CreateHttpClient(uri);

                var content = new StringContent(JsonConvert.SerializeObject(data));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                string result = string.Empty;

                var response = await Policy.Handle<WebException>(exception =>
                {
                    Debug.WriteLine($"{exception.GetType().Name + " : " + exception.Message}");
                    return true;
                })
                .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                .ExecuteAsync(async () => await httpClient.PutAsync(uri, content));

                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var jsonResult = JsonConvert.DeserializeObject<T>(result);
                    return jsonResult;
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Forbidden
                        || response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new ServiceAuthenticationException(result);
                    }
                    else
                    {
                        throw new CustomHttpRequestException(response.StatusCode, result);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        private HttpClient CreateHttpClient(string authToken)
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.
                Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(authToken))
            {
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", authToken);
            }

            return httpClient;
        }
    }
}
