using Imi.Project.Mobile.Core.Interfaces;
using System;
using System.Collections.Generic;
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
