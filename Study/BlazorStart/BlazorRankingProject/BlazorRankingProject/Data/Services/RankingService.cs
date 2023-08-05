using BlazorRankingProject.Data.Models;

namespace BlazorRankingProject.Data.Services
{
	public class RankingService
	{
		ApplicationDbContext _context;

		public RankingService(ApplicationDbContext context)
		{
			// dependency injection
			_context = context;
		}

		//Create
		public Task<GameResult> AddGameResult(GameResult gameResult)
		{
			_context.GameResults.Add(gameResult);
			_context.SaveChanges();  //db 실제 저장

			return Task.FromResult(gameResult);  // 용도가 있나 리턴해도 안쓰던데 Read에서는
		}

		// Read
		public Task<List<GameResult>> GetGameResultAsync()
		{
			List<GameResult> result = _context.GameResults.OrderByDescending(item=> item.Score).ToList();
			return Task.FromResult(result);
		}

		//Update

		//Delete

	}
}
