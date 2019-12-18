using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace proefExamen.Models
{
    public class QualityManager
    {
        public static async Task<List<Area>> GetAreasAsync()
        {
            List<Area> list = new List<Area>();
            string url = "https://qualityoflife.azurewebsites.net/api/areas";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string json = await client.GetStringAsync(url);
                    list = JsonConvert.DeserializeObject<List<Area>>(json);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return list;
        }

        public static async Task<AreaData> GetAreaDataAsync(string areaId)
        {
            AreaData c = new AreaData();
            string url = $"https://qualityoflife.azurewebsites.net/api/areas/{areaId}";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string json = await client.GetStringAsync(url);
                    c = JsonConvert.DeserializeObject<AreaData>(json);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return c;
        }

        public static async Task<List<QualityScore>> GetQualityScoresAsync(string areaId)
        {
            List<QualityScore> list = new List<QualityScore>();
            string url = $"https://qualityoflife.azurewebsites.net/api/areas/{areaId}/QualityScores";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string json = await client.GetStringAsync(url);
                    list = JsonConvert.DeserializeObject<List<QualityScore>>(json);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return list;
        }

        public static async Task UpdateQualityScoreAsync(QualityScore score)
        {
            string url = $"https://qualityoflife.azurewebsites.net/api/QualityScore/{score.Id}";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string json = JsonConvert.SerializeObject(score);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PutAsync(url, content);
                    if (!response.IsSuccessStatusCode)
                    {
                        string errorMsg = $"Unsuccesfull PUT to url: {url}, object {json}";
                        throw new Exception(errorMsg);
                    }
                }
                catch (Exception ex)
                {
                    string errorMsg = $"Something went wrong with url: {url} ({ex.Message})";
                    throw new Exception(errorMsg);
                }
            }
        }
    }
}
