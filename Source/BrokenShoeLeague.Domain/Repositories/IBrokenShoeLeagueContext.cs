using System;
using System.Linq;

namespace BrokenShoeLeague.Domain.Repositories
{
    public interface IBrokenShoeLeagueContext
    {
        //Seasons
        void CreateSeason(Season season);
        Season GetSeasonById(int id);
        void RemoveSeason(Season season);
        IQueryable<Season> GetAllSeasons();

        //Player
        void InsertPlayer(Player newPlayer);
        Player GetPlayerById(int id);
        void RemovePlayer(Player player);
        IQueryable<Player> GetAllPlayers();

        //ImageCarousel
        void InsertImageCarousel(ImageCarousel imageCarousel);
        ImageCarousel GetImageById(int id);
        void RemoveCarouselImage(ImageCarousel imageCarousel);
        IQueryable<ImageCarousel> GetAllCarouselImages();

        //MatchDays
        void InsertMatchDay(MatchDay matchDay);
        MatchDay GetMatchDayById(int id);
        void RemoveMatchDay(MatchDay matchDay);
        IQueryable<MatchDay> GetAllMatchDay();
        void AddPlayerToMatchDay(MatchDay matchDay, int playerId);

        //PlayerRecords
        void InsertPlayerRecord(PlayerRecord playerRecord);
        PlayerRecord GetPlayerRecordById(int id);
        void RemovePlayerRecord(PlayerRecord playerRecord);
        IQueryable<PlayerRecord> GetAllPlayerRecord();
        void UpdatePlayer(Player player);
        void UpdatePlayerRecord(int playerRecordId, PlayerRecord data);

        //transaction manager
        void SaveChanges();

        void UpdateImageCarousel(int id, ImageCarousel data);

        //Users
        IQueryable<UserProfile> GetAllUsers();
        UserProfile FindUser(Func<UserProfile, bool> pred);

        //comments
        IQueryable<Comment> GetAllComments();
        void AddComment(Comment c);
        void RemoveComment(Comment c);
        void RemoveComment(int id);
        Comment GetCommentById(int id);

    }
}
