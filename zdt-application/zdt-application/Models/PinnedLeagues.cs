using zdt_application.Auth;

namespace zdt_application.Models
{
    public class PinnedLeagues
    {
        public Guid Id { get; set; }
        public int LeagueId { get; set; }
        public ICollection<UserLeague> UserPinnedLeagues { get; set; }
    }
}