using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BrokenShoeLeague.Domain;

namespace BrokenShoeLeague.Web.API.Models
{
    public class PlayerViewModel
    {
        public PlayerViewModel()
        {
            
        }

        public PlayerViewModel(Player player)
        {
            Name = player.Name;
            Enabled = player.Enabled;
            ImageProfileUrl = player.ImageProfileUrl;
        }

        [Required]
        public string ImageProfileUrl { get; set; }

        public bool Enabled { get; set; }

        [Required]
        public string Name { get; set; }
    }
}