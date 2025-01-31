using System.Net.Http.Headers;
using System.Text.Json;
using ltImageGallery.Models;
using Microsoft.Extensions.Options;

namespace ltImageGallery.Services
{
    public class AlbumService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _apiSettings;

        public AlbumService(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _apiSettings = apiSettings.Value;
        }

        public async Task<List<Album>?> GetAlbums()
        {
            string url = $"{_apiSettings.BaseUrl}/albums";
            _httpClient.DefaultRequestHeaders.Add("lt_api_key", _apiSettings.ApiKey);

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Album>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
                else
                {
                    return null; // Handle errors accordingly (log/email/etc)
                }
            }
            catch (Exception ex)
            {
                return null; // Handle errors accordingly (log/email/etc)
            }
        }

        public async Task<List<Photo>?> GetPhotosByAlbum(int albumId)
        {
            string url = $"{_apiSettings.BaseUrl}/albums" + (albumId > 0 ? "/" + albumId : "");
            _httpClient.DefaultRequestHeaders.Add("lt_api_key", _apiSettings.ApiKey);

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<Photo>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                } else
                {
                    return null; // Handle errors accordingly (log/email/etc)
                }
            }
            catch (Exception ex)
            {
                return null; // Handle errors accordingly (log/email/etc)
            }
        }

        //stub in the individual photo endpoint, but isn't used due to how the markup was created
        public async Task<Photo?> GetPhotoById(int photoId)
        {
            if (photoId > 0)
            {
                string url = $"{_apiSettings.BaseUrl}/photos/" + photoId;
                _httpClient.DefaultRequestHeaders.Add("lt_api_key", _apiSettings.ApiKey);

                try
                {
                    HttpResponseMessage response = await _httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        return JsonSerializer.Deserialize<Photo>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    }
                    else
                    {
                        return null; // Handle errors accordingly (log/email/etc)
                    }
                }
                catch (Exception ex)
                {
                    return null; // Handle errors accordingly (log/email/etc)
                }
            }
            else
            {
                return null; // Handle errors accordingly (log/email/etc)
            }
        }
    }
}
