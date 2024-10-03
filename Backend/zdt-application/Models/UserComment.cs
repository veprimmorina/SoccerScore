namespace zdt_application.Models
{
    public class UserComment
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public int MatchId { get; set; }
        public string Comment { get; set; }
    }
}
