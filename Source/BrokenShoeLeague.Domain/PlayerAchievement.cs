using System.ComponentModel.DataAnnotations;

namespace BrokenShoeLeague.Domain
{
    public class PlayerAchievement
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string IconName { get; set; }
    }
}
