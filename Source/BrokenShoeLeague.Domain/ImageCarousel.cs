using System.ComponentModel.DataAnnotations;

namespace BrokenShoeLeague.Domain
{
    public class ImageCarousel
    {
        public int Id { get; set; }
        public bool Show { get; set; }
        public bool ShowOnGallery { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public UserProfile UserOwner { get; set; }
        public void Update(string name, string description, bool showOnIndex, bool showOnGallery)
        {
            Name = name;
            Description = description;
            Show = showOnIndex;
            ShowOnGallery = showOnGallery;
        }
    }
}
