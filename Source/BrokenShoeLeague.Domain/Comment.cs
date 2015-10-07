using System;

namespace BrokenShoeLeague.Domain
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual UserProfile User { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
