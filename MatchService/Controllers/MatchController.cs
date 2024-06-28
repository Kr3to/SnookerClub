using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Net.Http.Json;
using Data.Entities;
using Data;
using System.Linq;

namespace MatchService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly HttpClient _httpClient;
        private readonly ILogger<MatchController> _logger;

        public MatchController(AppDbContext context, IHttpClientFactory httpClientFactory, ILogger<MatchController> logger)
        {
            _context = context;
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
                _logger.LogError("One or both players not found. Player1Id: {Player1Id}, Player2Id: {Player2Id}", matchDto.Player1Id, matchDto.Player2Id);
                return BadRequest(new { Message = "One or both players not found." });
            }

            var match = new MatchEntity
            {
                Player1Id = matchDto.Player1Id,
                Player2Id = matchDto.Player2Id,
                Location = matchDto.Location,
                Tournament = matchDto.Tournament
            };

            _context.Matches.Add(match);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Match created successfully with MatchId: {MatchId}", match.MatchId);
            return Ok(match);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllMatches()
        {
            var matches = await _context.Matches
                .Include(m => m.Player1)
                .Include(m => m.Player2)
                .ToListAsync();

            var matchDtos = matches.Select(m => new MatchDto
            {
                MatchId = m.MatchId,
                Player1Id = m.Player1Id,
                Player2Id = m.Player2Id,
                Player1Name = m.Player1.Name,
                Player2Name = m.Player2.Name,
                Location = m.Location,
                Tournament = m.Tournament
            }).ToList();

            return Ok(matchDtos);
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

        private async Task<PlayerEntity> GetPlayerById(int playerId)
        {
            try
            {
                _logger.LogInformation("Fetching player with ID: {PlayerId}", playerId);
                var response = await _httpClient.GetAsync($"http://localhost:5000/player/{playerId}");
                if (response.IsSuccessStatusCode)
                {
                    var player = await response.Content.ReadFromJsonAsync<PlayerEntity>();
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
    }
}
