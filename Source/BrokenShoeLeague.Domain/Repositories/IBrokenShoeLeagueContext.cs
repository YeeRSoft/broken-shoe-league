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
        void UpdateSeason(Season season);


        //Player
        void CreatePlayer(Player newPlayer);
        Player GetPlayerById(int id);
        void RemovePlayer(Player player);
        IQueryable<Player> GetAllPlayers();
        void UpdatePlayer(Player player);


        //ImageCarousel
        void CreateImageCarousel(ImageCarousel imageCarousel);
        ImageCarousel GetImageCarouselById(int id);
        void RemoveImageCarousel(ImageCarousel imageCarousel);
        IQueryable<ImageCarousel> GetAllImageCarousel();

        //MatchDays
        void CreateMatchDay(MatchDay matchDay);
        MatchDay GetMatchDayById(int id);
        void RemoveMatchDay(MatchDay matchDay);
        IQueryable<MatchDay> GetAllMatchDays();
        void AddPlayerToMatchDay(MatchDay matchDay, int playerId);

        //PlayerRecords
        void CreatePlayerRecord(PlayerRecord playerRecord);
        PlayerRecord GetPlayerRecordById(int id);
        void RemovePlayerRecord(PlayerRecord playerRecord);
        IQueryable<PlayerRecord> GetAllPlayerRecords();
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
