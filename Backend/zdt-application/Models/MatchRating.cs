namespace zdt_application.Models
{
    public class MatchRating
    {
        public Guid Id { get; set; }
        public int MatchId { get; set; }
        public string UserId { get; set; }
        public double Rate { get; set; }
    }
}
