using System;
using System.ComponentModel.DataAnnotations;

namespace Hackathon_Jue.DB
{
    public class Event
    {
        [Key]
        public Guid Id { get; set; }
        public long TimeStamp { get; set; }
        public string Name { get; set; }
        public EventType EventType { get; set; }
    }

    public enum EventType 
    {
        Football,
        Hockey,
        Basteball
    }
}
