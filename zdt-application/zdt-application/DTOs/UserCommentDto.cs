using zdt_application.Auth;

namespace zdt_application.DTOs
{
    public class UserCommentDto
    {
        public ApplicationUser User { get; set; }
        public string Comment { get; set; } 
    }
}
