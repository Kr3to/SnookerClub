using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MatchService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchController : ControllerBase
    {
        private static List<Match> matches = new List<Match>();
        private static int nextMatchId = 1;
        private readonly HttpClient _httpClient;
        private readonly ILogger<MatchController> _logger;

        public MatchController(IHttpClientFactory httpClientFactory, ILogger<MatchController> logger)
        {
            _httpClient = httpClientFactory.CreateClient();
            _logger = logger;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateMatch([FromBody] MatchCreationDto matchDto)
        {
            _logger.LogInformation("Creating match with Player1Id: {Player1Id}, Player2Id: {Player2Id}, Location: {Location}, Tournament: {Tournament}", matchDto.Player1Id, matchDto.Player2Id, matchDto.Location, matchDto.Tournament);

            var player1 = await GetPlayerById(matchDto.Player1Id);
            var player2 = await GetPlayerById(matchDto.Player2Id);

            if (player1 == null || player2 == null)
            {
                _logger.LogError("One or both players not found. Player1Id: {Player1Id}, Player2Id: {Player2Id}");
                return BadRequest(new { Message = "One or both players not found." });
            }

            var match = new Match
            {
                MatchId = nextMatchId++,
                Player1Id = matchDto.Player1Id,
                Player2Id = matchDto.Player2Id,
                Location = matchDto.Location,
                Tournament = matchDto.Tournament,
                Player1Name = player1.Name,
                Player2Name = player2.Name
            };

            matches.Add(match);
            _logger.LogInformation("Match created successfully with MatchId: {MatchId}", match.MatchId);
            return Ok(match);
        }

        [HttpGet("all")]
        public IActionResult GetAllMatches()
        {
            return Ok(matches);
        }

        [HttpGet("test-player-connection/{playerId}")]
        public async Task<IActionResult> TestPlayerConnection(int playerId)
        {
            var player = await GetPlayerById(playerId);
            if (player == null)
            {
                return NotFound("Player not found");
            }
            return Ok(player);
        }

        private async Task<Player> GetPlayerById(int playerId)
        {
            try
            {
                _logger.LogInformation("Fetching player with ID: {PlayerId}", playerId);
                var response = await _httpClient.GetAsync($"http://localhost:5000/player/{playerId}");
                if (response.IsSuccessStatusCode)
                {
                    var player = await response.Content.ReadFromJsonAsync<Player>();
                    _logger.LogInformation("Fetched player: {PlayerName}", player.Name);
                    return player;
                }
                _logger.LogError("Failed to fetch player with ID {PlayerId}: {StatusCode}", playerId, response.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while fetching player with ID: {PlayerId}", playerId);
            }
            return null;
        }

        public class Match
        {
            public int MatchId { get; set; }
            public int Player1Id { get; set; }
            public int Player2Id { get; set; }
            public string Location { get; set; }
            public string Tournament { get; set; }
            public string Player1Name { get; set; }
            public string Player2Name { get; set; }
        }

        public class Player
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Ranking { get; set; }
        }
    }
}
