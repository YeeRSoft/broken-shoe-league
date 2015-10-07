using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrokenShoeLeague.Domain
{
    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required(ErrorMessage = "You must especify an email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "This is not a valid email")]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; }

        public bool NotificationsByEmail { get; set; }

        public bool ConfirmationLink { get; set; }

        public virtual ICollection<ImageCarousel> ImageCarousels { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual Player UserPlayer { get; set; }
        public string ImageProfileUrl { get; set; }
    }
}
