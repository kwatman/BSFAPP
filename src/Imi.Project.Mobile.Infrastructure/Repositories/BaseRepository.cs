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

                HttpResponseMessage responseMessage = await Policy.Handle<WebException>(exception =>
                {
                    Debug.WriteLine($"{exception.GetType().Name + " : " + exception.Message}");
                    return true;
                })
                .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                .ExecuteAsync(async () => await httpClient.GetAsync(uri));

                if (responseMessage.IsSuccessStatusCode)
                {
                    string message = await responseMessage.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<T>(message);
                    return result;
                }
                else
                {
                    var content = await responseMessage.Content.ReadAsStringAsync();

                    if (responseMessage.StatusCode == HttpStatusCode.Forbidden
                        || responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new ServiceAuthenticationException(content);
                    }
                    else
                    {
                        throw new CustomHttpRequestException(responseMessage.StatusCode, content);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
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
