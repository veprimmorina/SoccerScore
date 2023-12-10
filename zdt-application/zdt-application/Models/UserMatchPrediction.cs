namespace zdt_application.Models
{
    public class UserMatchPrediction
    {
        public Guid id { get; set; }
        public string UserId { get; set; }
        public int MatchId { get; set; }
        public int Prediction { get; set; }
    }
}
