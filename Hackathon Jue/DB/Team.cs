using System.ComponentModel.DataAnnotations;

namespace Hackathon_Jue.DB
{
    public class Team
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<string> InvitedUsers { get; set; }
        public List<string> ApprovedUser { get; set; }
        public string СaptainUserId { get; set; }

    }
}
