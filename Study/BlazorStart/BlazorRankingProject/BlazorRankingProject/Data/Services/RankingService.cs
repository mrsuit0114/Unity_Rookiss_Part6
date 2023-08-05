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

		public Task<List<GameResult>> GetGameResultAsync()
		{
			List<GameResult> result = _context.GameResults.OrderByDescending(item=> item.Score).ToList();
			return Task.FromResult(result);
		}

	}
}
