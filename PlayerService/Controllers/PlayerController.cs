using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Data.Entities;
using Data;

namespace PlayerService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(AppDbContext context, ILogger<PlayerController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePlayer([FromBody] PlayerEntity player)
        {
            _logger.LogInformation("Creating player with Name: {Name}, Ranking: {Ranking}", player.Name, player.Ranking);
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Player created successfully with Id: {Id}", player.Id);
            return Ok(player);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllPlayers()
        {
            return Ok(await _context.Players.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerById(int id)
        {
            _logger.LogInformation("Fetching player with ID: {Id}", id);
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                _logger.LogError("Player not found with ID: {Id}", id);
                return NotFound();
            }
            _logger.LogInformation("Fetched player with ID: {Id}, Name: {Name}", player.Id, player.Name);
            return Ok(player);
        }
    }
}
