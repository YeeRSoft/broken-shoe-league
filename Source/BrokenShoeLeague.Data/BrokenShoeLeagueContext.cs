using System;
using System.Data.Entity;
using System.Linq;
using BrokenShoeLeague.Domain;
using BrokenShoeLeague.Domain.Repositories;

namespace BrokenShoeLeague.Data
{
    public class BrokenShoeLeagueContext : DbContext, IBrokenShoeLeagueRepository
    {
        public BrokenShoeLeagueContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Matchday> Matchdays { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerAchievement> Achievments { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<PlayerRecord> PlayerRecords { get; set; }
        public DbSet<ImageCarousel> ImageCarousels { get; set; }
        public DbSet<Comment> Comments { get; set; }

        #region Seasons

        public void CreateSeason(Season season)
        {
            Seasons.Add(season);
            SaveChanges();
        }

        public Season GetSeasonById(int id)
        {
            return Seasons
                .Include(s => s.Matchdays.Select(x => x.PlayerStats))
                .FirstOrDefault(x=>x.Id == id);
        }

        public void RemoveSeason(Season season)
        {
            Seasons.Remove(season);
        }

        public IQueryable<Season> GetAllSeasons()
        {
            return Seasons.Include(x=>x.Matchdays).AsQueryable();
        }

        public bool SeasonExist(int seasonId)
        {
            return Seasons.Any(x => x.Id == seasonId);
        }

        #endregion

        #region Players

        public void CreatePlayer(Player newPlayer)
        {
            newPlayer.ImageProfileUrl = "~/Content/Images/_defaultPlayer.png";
            Players.Add(newPlayer);
            SaveChanges();
        }

        public Player GetPlayerById(int id)
        {
            return Players.Find(id);
        }

        public Player GetPlayerByName(string name)
        {
            return Players.FirstOrDefault(x => x.Name == name);
        }

        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
            SaveChanges();
        }

        public IQueryable<Player> GetAllPlayers()
        {
            return Players;
        }

        public void UpdatePlayer(Player player)
        {
            var playerDb = Players.Find(player.Id);
            playerDb.Name = player.Name;
            playerDb.Enabled = player.Enabled;
            SaveChanges();
        }

        public bool PlayerExist(int playerId)
        {
            return Players.Any(x => x.Id == playerId);
        }

        #endregion

        #region ImageCarousel

        public void CreateImageCarousel(ImageCarousel imageCarousel)
        {
            ImageCarousels.Add(imageCarousel);
            SaveChanges();
        }

        public ImageCarousel GetImageCarouselById(int id)
        {
            return ImageCarousels.Find(id);
        }

        public void RemoveImageCarousel(ImageCarousel imageCarousel)
        {
            ImageCarousels.Remove(imageCarousel);
        }

        public IQueryable<ImageCarousel> GetAllImageCarousel()
        {
            return ImageCarousels;
        }

        public void UpdateImageCarousel(int id, ImageCarousel data)
        {
            var img = ImageCarousels.Find(id);
            img.Name = data.Name;
            img.Description = data.Description;
            img.Show = data.Show;
        }

        #endregion

        #region Matchday

        public void CreateMatchday(Matchday matchday)
        {
            Matchdays.Add(matchday);
            SaveChanges();
        }

        public Matchday GetMatchdayById(int id)
        {
            return Matchdays.Find(id);
        }

        public void RemoveMatchday(Matchday matchday)
        {
            Matchdays.Remove(matchday);
        }

        public IQueryable<Matchday> GetAllMatchdays()
        {
            return Matchdays;
        }

        public void AddPlayerToMatchday(Matchday matchday, int playerId)
        {
            matchday.PlayerStats.Add(new PlayerRecord()
            {
                Player = Players.Find(playerId)
            });
        }

        public bool MatchdayExist(int matchdayId)
        {
            return Matchdays.Any(x => x.Id == matchdayId);
        }

        #endregion

        #region PlayerRecord

        public void CreatePlayerRecord(PlayerRecord playerRecord)
        {
            PlayerRecords.Add(playerRecord);
            SaveChanges();
        }

        public PlayerRecord GetPlayerRecordById(int id)
        {
            return PlayerRecords.Find(id);
        }

        public void RemovePlayerRecord(PlayerRecord playerRecord)
        {
            PlayerRecords.Remove(playerRecord);
            SaveChanges();
        }

        public IQueryable<PlayerRecord> GetAllPlayerRecords()
        {
            return PlayerRecords;
        }

        public void UpdatePlayerRecord(int playerRecordId, PlayerRecord data)
        {
            var playerRecord = PlayerRecords.Find(playerRecordId);
            playerRecord.PlayedGames = data.PlayedGames;
            playerRecord.Won = data.Won;
            playerRecord.Tied = data.Tied;
            playerRecord.Lost = data.Lost;
            playerRecord.Assists = data.Assists;
            playerRecord.AllowedGoals = data.AllowedGoals;
            playerRecord.Goals = data.Goals;
            SaveChanges();
        }

        void IBrokenShoeLeagueRepository.SaveChanges()
        {
            SaveChanges();
        }

        #endregion

        #region User Profiles

        public IQueryable<UserProfile> GetAllUsers()
        {
            return UserProfiles;
        }

        public UserProfile FindUser(Func<UserProfile, bool> pred)
        {
            return UserProfiles.FirstOrDefault(p => pred(p));
        }

        #endregion

        #region Comments

        public IQueryable<Comment> GetAllComments()
        {
            return Comments.AsQueryable();
        }

        public void AddComment(Comment c)
        {
            Comments.Add(c);
            SaveChanges();
        }

        public void RemoveComment(Comment c)
        {
            Comments.Remove(c);
            SaveChanges();
        }

        public void RemoveComment(int id)
        {
            Comments.Remove(Comments.Find(id));
            SaveChanges();
        }

        public Comment GetCommentById(int id)
        {
            return Comments.FirstOrDefault(x=>x.Id == id);
        }

        #endregion
    }
}
