using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace PlayerService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private static List<Player> players = new List<Player>();
        private static int nextId = 1;
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(ILogger<PlayerController> logger)
        {
            _logger = logger;
        }

        [HttpPost("create")]
        public IActionResult CreatePlayer([FromBody] Player player)
        {
            _logger.LogInformation("Creating player with Name: {Name}, Ranking: {Ranking}", player.Name, player.Ranking);
            player.Id = nextId++;
            players.Add(player);
            _logger.LogInformation("Player created successfully with Id: {Id}", player.Id);
            return Ok(player);
        }

        [HttpGet("all")]
        public IActionResult GetAllPlayers()
        {
            return Ok(players);
        }

        [HttpGet("{id}")]
        public IActionResult GetPlayerById(int id)
        {
            _logger.LogInformation("Fetching player with ID: {Id}", id);
            var player = players.FirstOrDefault(p => p.Id == id);
            if (player == null)
            {
                _logger.LogError("Player not found with ID: {Id}", id);
                return NotFound();
            }
            _logger.LogInformation("Fetched player with ID: {Id}, Name: {Name}", player.Id, player.Name);
            return Ok(player);
        }
    }

    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Ranking { get; set; }
    }
}
