using Microsoft.AspNetCore.Mvc;

namespace lab3_lab4.Controllers
{
    public class SnookerController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<SnookerController> _logger;

        public SnookerController(HttpClient httpClient, ILogger<SnookerController> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer(string name, int ranking)
        {
            var player = new Player { Name = name, Ranking = ranking };
            try
            {
                var response = await _httpClient.PostAsJsonAsync("http://localhost:5000/player/create", player);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("Failed to create player: {StatusCode}", response.StatusCode);
                    ViewBag.ErrorMessage = "Failed to create player.";
                    return View("Error");
                }

                var createdPlayer = await response.Content.ReadFromJsonAsync<Player>();
                return View("PlayerDetails", createdPlayer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while creating player");
                ViewBag.ErrorMessage = "An error occurred while creating the player.";
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateMatch(int player1Id, int player2Id, string location, string tournament)
        {
            var matchDto = new MatchCreationDto { Player1Id = player1Id, Player2Id = player2Id, Location = location, Tournament = tournament };
            try
            {
                _logger.LogInformation("Sending request to create match with Player1Id: {Player1Id}, Player2Id: {Player2Id}", player1Id, player2Id);
                var response = await _httpClient.PostAsJsonAsync("http://localhost:5001/match/create", matchDto);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("Failed to create match: {StatusCode}", response.StatusCode);
                    var responseBody = await response.Content.ReadAsStringAsync();
                    _logger.LogError("Response body: {ResponseBody}", responseBody);
                    ViewBag.ErrorMessage = "Failed to create match.";
                    return View("Error");
                }

                var createdMatch = await response.Content.ReadFromJsonAsync<Match>();
                return View("MatchDetails", createdMatch);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while creating match");
                ViewBag.ErrorMessage = "An error occurred while creating the match.";
                return View("Error");
            }
        }

        public async Task<IActionResult> GetAllPlayers()
        {
            try
            {
                var players = await _httpClient.GetFromJsonAsync<IEnumerable<Player>>("http://localhost:5000/player/all");
                return View("PlayerList", players);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while fetching players");
                ViewBag.ErrorMessage = "An error occurred while fetching players.";
                return View("Error");
            }
        }

        public async Task<IActionResult> GetAllMatches()
        {
            try
            {
                var matches = await _httpClient.GetFromJsonAsync<IEnumerable<Match>>("http://localhost:5001/match/all");
                return View("MatchList", matches);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while fetching matches");
                ViewBag.ErrorMessage = "An error occurred while fetching matches.";
                return View("Error");
            }
        }

        public class Player
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Ranking { get; set; }
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

        public class MatchCreationDto
        {
            public int Player1Id { get; set; }
            public int Player2Id { get; set; }
            public string Location { get; set; }
            public string Tournament { get; set; }
        }
    }
}
