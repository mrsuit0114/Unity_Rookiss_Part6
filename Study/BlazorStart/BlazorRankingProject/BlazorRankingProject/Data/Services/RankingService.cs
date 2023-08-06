using Newtonsoft.Json;
using SharedData.Models;
using System.Text;

namespace BlazorRankingProject.Data.Services
{
	public class RankingService
	{
		HttpClient _httpClient;

		public RankingService(HttpClient client)
		{
			// dependency injection
			_httpClient = client;
		}

		//RankingController.cs 에서는 자동으로 Json으로 파싱해주는데 여기서는 해줘야한다함
		//Create
		public async Task<GameResult> AddGameResult(GameResult gameResult)
		{
			string jsonStr = JsonConvert.SerializeObject(gameResult);
			var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
			var result = await _httpClient.PostAsync("https://localhost:7098/api/ranking", content);

			if (result.IsSuccessStatusCode == false)
				throw new Exception("AddFailed");

			var resultContent = await result.Content.ReadAsStringAsync();
			GameResult resGameResult = JsonConvert.DeserializeObject<GameResult>(resultContent);
			return resGameResult;

		}
		// Read
		public async Task<List<GameResult>> GetGameResultAsync()
		{
			var result = await _httpClient.GetAsync("https://localhost:7098/api/ranking");

			var resultContent = await result.Content.ReadAsStringAsync();
			List<GameResult> resGameResults = JsonConvert.DeserializeObject<List<GameResult>>(resultContent);
			return resGameResults;
        }
		//Update
		public async Task<bool> UpdateGameResult(GameResult gameResult)
		{
            string jsonStr = JsonConvert.SerializeObject(gameResult);
            var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
            var result = await _httpClient.PutAsync("https://localhost:7098/api/ranking", content);

            if (result.IsSuccessStatusCode == false)
                throw new Exception("UpdateFailed");

            return true;
        }
		//Delete
		public async Task<bool> DeleteGameResult(GameResult gameResult)
		{
			var result = await _httpClient.DeleteAsync($"https://localhost:7098/api/ranking/{gameResult.Id}");
			if (result.IsSuccessStatusCode == false)
                throw new Exception("DeleteFailed");

			return true;
        }
	}
}
