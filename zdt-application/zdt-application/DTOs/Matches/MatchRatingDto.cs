namespace zdt_application.DTOs.Matches
{
    public class MatchRatingDto
    {
        public Guid Id { get; set; }
        public int MatchId { get; set; }
        public string UserId { get; set; }
        public double Rate { get; set; }
    }
}