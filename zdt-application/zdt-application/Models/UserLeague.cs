using zdt_application.Auth;

namespace zdt_application.Models
{
    public class UserLeague
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public Guid PinnedLeaguesId { get; set; }
        public PinnedLeagues PinnedLeagues { get; set; }
    }
}
