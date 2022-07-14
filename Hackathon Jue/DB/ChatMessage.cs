using System.ComponentModel.DataAnnotations;

namespace Hackathon_Jue.DB
{
    public class ChatMessage
    {
        [Key]
        public Guid Id { get; set; }
        public long TimeStamp { get; set; }
        public string Text { get; set; }
        public string From { get; set; }
    }
}
