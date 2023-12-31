﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedData.Models;
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
        [HttpPost]
        public GameResult AddGameResult([FromBody] GameResult gameResult)
        {
            _context.GameResults.Add(gameResult);
            _context.SaveChanges();

            return gameResult;
        }
        // Read
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
        // Update
        [HttpPut]
        public bool UpdateGameResult([FromBody] GameResult gameResult)
        {
            var findResult = _context.GameResults
                .Where(x=> x.Id== gameResult.Id)
                .FirstOrDefault();

            if(findResult ==null)
                return false;

            findResult.UserName = gameResult.UserName;
            findResult.Score = gameResult.Score;
            _context.SaveChanges();

            return true;
        }
        // Delete
        [HttpDelete("{id}")]
        public bool DeleteGameResult(int id)
        {
            var findResult = _context.GameResults
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (findResult == null)
                return false;

            _context.GameResults.Remove(findResult);
            _context.SaveChanges();

            return true;
        }
    }
}
