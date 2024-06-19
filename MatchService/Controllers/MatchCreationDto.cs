namespace MatchService.Controllers
{
    public class MatchCreationDto
    {
        public int Player1Id { get; set; }
        public int Player2Id { get; set; }
        public string Location { get; set; }
        public string Tournament { get; set; }
    }
}
