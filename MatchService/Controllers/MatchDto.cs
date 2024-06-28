namespace MatchService.Controllers
{
    public class MatchDto
    {
        public int MatchId { get; set; }
        public int Player1Id { get; set; }
        public int Player2Id { get; set; }
        public string Player1Name { get; set; }
        public string Player2Name { get; set; }
        public string Location { get; set; }
        public string Tournament { get; set; }
    }
}
