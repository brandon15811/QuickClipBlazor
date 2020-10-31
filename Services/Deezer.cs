using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace QuickClipBlazor.Services
{
    class DeezerBase<T>
    {
        public List<T> Data { get; set; }
    }
    
    public class DeezerTrack
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        [JsonProperty("Preview")]
        public string PreviewUrl { get; set; }
        
        public DeezerArtist Artist { get; set; }
    }

    public class DeezerArtist
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public static class DeezerService
    {
        private static RestClient client = new RestClient("https://api.deezer.com/");

        static DeezerService()
        {
            client.UseNewtonsoftJson();
        }
        
        public static async Task<List<DeezerTrack>> GetTopTracksForArtist(int artistId, int limit = 50)
        {
            var request = new RestRequest("artist/{id}/top")
                .AddUrlSegment("id", artistId)
                .AddQueryParameter("limit", limit.ToString());

            return (await client.GetAsync<DeezerBase<DeezerTrack>>(request)).Data;
        }
        
        public static async Task<List<DeezerArtist>> SearchArtists(string artistQuery)
        {
            var request = new RestRequest("search/artist")
                .AddQueryParameter("q", artistQuery);

            return (await client.GetAsync<DeezerBase<DeezerArtist>>(request)).Data;
        }
    }
}