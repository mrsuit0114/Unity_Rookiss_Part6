using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedDate.Models;
using WebApi.Data;

namespace WebApi.Controllers
{
    // ApiController 특징
    // 그냥 C#객체를 반환해도 된다
    // null 반환하면 클라에 204 Response(No Content)
    // string -> text/plain 타입으로 반환
    // 나머지 (int, bool) -> application/json 타입으로 반환

    [Route("api/[controller]")]
    [ApiController]
    public class RankingController : ControllerBase
    {
        ApplicationDbContext _context;
        public RankingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create

        // Reat
        [HttpGet]
        public List<GameResult> GetGameResults()
        {
            List<GameResult> results = _context.GameResults
                .OrderByDescending(item => item.Score)
                .ToList();

            return results;
        }

        [HttpGet("{id}")]  //api/ranking/3 처럼 파라미터를 받아서 사용한다는 것을 명시
        public GameResult GetGameResults(int id)
        {
            GameResult result = _context.GameResults
                .Where(item => item.Id == id)
                .FirstOrDefault();

            return result;
        }

    }
}
