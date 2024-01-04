namespace zdt_application.Models
{
    public class UserResultPrediction
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public int MatchId { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
    }
}
